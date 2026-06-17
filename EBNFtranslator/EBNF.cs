using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;

namespace EBNFtranslator
{
    /// <summary>
    /// Translates EBNF grammar to Parser Library grammar and back
    /// </summary>
    public class EBNF
    {
        /// <summary>
        /// Parses an ISO 14977 EBNF grammar string and returns an equivalent
        /// Parser Library rule list, ready to use.
        /// </summary>
        /// <remarks>
        /// Supported EBNF constructs:
        ///   rule = expression ;         — rule definition (first rule is the start rule)
        ///   a , b                       — concatenation  → SequenceRule
        ///   a | b                       — alternation    → ChoiceRule
        ///   [ expression ]              — optional       → OptionalRule
        ///   { expression }              — zero or more   → OptionalRule(OneOrMoreRule)
        ///   ( expression )              — grouping
        ///   "literal" or 'literal'      — terminal       → SymbolRule (Regex.Escape applied)
        ///   ? regex pattern ?           — special seq.   → SymbolRule (raw regex)
        ///   rule-name                   — rule reference → ReferenceRule
        ///   (* comment *)              — block comment (ignored)
        /// </remarks>
        public IRuleList TranslateToParserGrammar(string ebnfGrammar)
        {
            if (ebnfGrammar == null) throw new ArgumentNullException("ebnfGrammar");

            var tokens = Tokenize(ebnfGrammar);
            var parser = new Parser();
            int pos = 0;

            while (Peek(tokens, pos) != TokenType.EOF)
            {
                var rule = ParseRuleDefinition(tokens, ref pos);
                parser.Rules.Add(rule);
            }

            parser.Initialize();
            return parser;
        }

        /// <summary>
        /// Converts a Parser Library rule list back to an ISO 14977 EBNF grammar string.
        /// Regex patterns are expressed as EBNF special sequences: <c>? pattern ?</c>.
        /// </summary>
        /// <remarks>
        /// UNSUPPORTED / PARTIALLY SUPPORTED RULE TYPES:
        /// <list type="bullet">
        ///   <item><term>BackReferenceRule</term>
        ///     <description>Context-sensitive — matches a previously saved value at runtime.
        ///     There is no EBNF equivalent. A comment placeholder is emitted.</description></item>
        ///   <item><term>SaveRule</term>
        ///     <description>The regex pattern is preserved as a special sequence, but the
        ///     back-reference stack-push side-effect cannot be expressed in EBNF.
        ///     A warning comment is prepended.</description></item>
        ///   <item><term>IfRule</term>
        ///     <description>The lookahead condition (<c>Pattern</c>) has no EBNF equivalent.
        ///     The body is approximated as an optional group <c>[ body ]</c> with the
        ///     lookahead pattern noted in a comment.</description></item>
        /// </list>
        /// </remarks>
        public string TranslateToEBNF(IRuleList parserLibraryGrammar)
        {
            if (parserLibraryGrammar == null) throw new ArgumentNullException("parserLibraryGrammar");

            var sb = new StringBuilder();
            var emitted = new HashSet<string>(StringComparer.Ordinal);

            sb.AppendLine("(* Generated EBNF grammar — regex patterns are expressed as ? pattern ? special sequences *)");
            if (parserLibraryGrammar.Rules.Count > 0 && !string.IsNullOrEmpty(parserLibraryGrammar.Rules[0].Name))
                sb.AppendLine("(* Start rule: " + EbnfIdentifier(parserLibraryGrammar.Rules[0].Name) + " *)");
            sb.AppendLine();

            foreach (var rule in parserLibraryGrammar.Rules)
                AppendRuleDefinition(sb, rule, emitted);

            return sb.ToString();
        }

        // ── EBNF emission helpers ────────────────────────────────────────────────

        private static void AppendRuleDefinition(StringBuilder sb, RuleBase rule, HashSet<string> emitted)
        {
            var name = EbnfIdentifier(rule.Name ?? rule.GetType().Name);
            if (!emitted.Add(name)) return;

            sb.Append(name);
            sb.Append(" = ");
            sb.Append(RuleBodyToEbnf(rule, emitted));
            sb.AppendLine(" ;");
            sb.AppendLine();
        }

        /// <summary>
        /// Returns the EBNF expression describing the body of a rule.
        /// Named child rules are emitted as identifier references; unnamed ones are inlined.
        /// </summary>
        private static string RuleBodyToEbnf(RuleBase rule, HashSet<string> emitted)
        {
            if (rule is SymbolRule sym)
                return SpecialSeq(sym.Pattern);

            if (rule is SequenceRule seq)
                return SequenceToEbnf(seq.Rules, emitted);

            if (rule is ChoiceRule ch)
                return ChoiceToEbnf(ch.Rules, emitted);

            if (rule is OptionalRule opt)
                return "[ " + ChildRef(opt.Rule, emitted) + " ]";

            if (rule is OneOrMoreRule oom)
                return OneOrMoreToEbnf(oom, emitted);

            if (rule is WhitespaceRule)
                // Fixed regex: one or more whitespace characters (including line breaks)
                return SpecialSeq(@"\s+");

            if (rule is CrlfRule)
                // Fixed regex: Windows-style line ending
                return SpecialSeq(@"\r\n");

            if (rule is UntilRule until)
                // Lazy match of everything up to (but not consuming) the stop pattern.
                return SpecialSeq(@".*?(?=" + until.Pattern + ")");

            if (rule is IntegerRule intRule)
                return SpecialSeq(intRule.Pattern);

            if (rule is DecimalRule decRule)
                return SpecialSeq(decRule.Pattern);

            if (rule is DateTimeRule dtRule)
                return SpecialSeq(dtRule.Pattern);

            if (rule is StringRule)
                // Fixed regex: double-quoted string, doubled-quote escaping (e.g. "say ""hi""")
                return SpecialSeq("\\s*\"(\"\"|[^\"])*\"");

            if (rule is SqlStringRule)
                // Fixed regex: single-quoted string, doubled-single-quote escaping (e.g. 'it''s')
                return SpecialSeq("\\s*'(''|[^'])*'");

            if (rule is SaveRule save)
                // ⚠ PARTIAL: the regex pattern is preserved, but the back-reference
                // stack-push side-effect cannot be represented in EBNF.
                return "(* SAVE \u2014 back-reference stack-push not expressible in EBNF *) " + SpecialSeq(save.Pattern);

            if (rule is BackReferenceRule)
                // ✗ UNSUPPORTED: matches text captured at runtime by a preceding SaveRule.
                // Context-sensitive behaviour has no EBNF equivalent.
                return "(* BACK-REFERENCE \u2014 context-sensitive; not expressible in EBNF *)";

            if (rule is IfRule ifRule)
                // ⚠ PARTIAL: the lookahead Pattern condition has no EBNF equivalent.
                // Body is approximated as optional; the condition is preserved as a comment.
                return "(* IF lookahead: " + ifRule.Pattern + " *) [ " + ChildRef(ifRule.Rule, emitted) + " ]";

            if (rule is RuleListBase ruleList)
                // Fallback for any other RuleListBase subtype — treat as a sequence.
                return SequenceToEbnf(ruleList.Rules, emitted);

            return "(* unsupported rule type: " + rule.GetType().Name + " *)";
        }

        /// <summary>
        /// Returns either the rule's EBNF identifier (for named rules) or its fully
        /// inlined expression (for anonymous sub-rules).
        /// Compound anonymous rules are parenthesised to preserve operator precedence.
        /// </summary>
        private static string ChildRef(RuleBase rule, HashSet<string> emitted)
        {
            // Named rules are referenced by name; their definitions are emitted at the top level.
            if (!string.IsNullOrEmpty(rule.Name))
                return EbnfIdentifier(rule.Name);

            var expr = RuleBodyToEbnf(rule, emitted);

            // In EBNF, concatenation (,) binds tighter than alternation (|).
            // Wrap both compound types in parens for unambiguous inline use.
            if (rule is SequenceRule || rule is ChoiceRule)
                return "( " + expr + " )";

            return expr;
        }

        private static string SequenceToEbnf(List<RuleBase> rules, HashSet<string> emitted)
        {
            var parts = new List<string>(rules.Count);
            foreach (var r in rules)
                parts.Add(ChildRef(r, emitted));
            return string.Join(" , ", parts);
        }

        private static string ChoiceToEbnf(List<RuleBase> rules, HashSet<string> emitted)
        {
            var parts = new List<string>(rules.Count);
            foreach (var r in rules)
                parts.Add(ChildRef(r, emitted));
            return string.Join(" | ", parts);
        }

        private static string OneOrMoreToEbnf(OneOrMoreRule oom, HashSet<string> emitted)
        {
            // EBNF has no native one-or-more operator.
            // Express as: first-occurrence , { additional-occurrences }
            var child = ChildRef(oom.Rule, emitted);

            if (oom.Separator != null)
            {
                // item , { separator , item }
                var sep = SpecialSeq(oom.Separator.Pattern);
                return child + " , { " + sep + " , " + child + " }";
            }

            // item , { item }
            return child + " , { " + child + " }";
        }

        /// <summary>Returns an ISO 14977 EBNF special sequence wrapping a regex pattern.</summary>
        private static string SpecialSeq(string pattern) => "? " + pattern + " ?";

        /// <summary>
        /// Converts a rule name to a valid EBNF meta-identifier.
        /// Keeps letters, digits, underscores and hyphens; replaces anything else with a hyphen.
        /// </summary>
        private static string EbnfIdentifier(string name)
            => Regex.Replace(name ?? "unknown-rule", @"[^\w\-]", "-");

        // ── Token model ──────────────────────────────────────────────────────────

        private enum TokenType
        {
            Identifier,
            Equals, Semicolon, Pipe, Comma,
            OpenBracket, CloseBracket,
            OpenBrace, CloseBrace,
            OpenParen, CloseParen,
            String, Special,
            EOF
        }

        private struct Token
        {
            public readonly TokenType Type;
            public readonly string Value;
            public Token(TokenType type, string value) { Type = type; Value = value; }
            public override string ToString() => $"{Type}(\"{Value}\")";
        }

        // ── Tokenizer ────────────────────────────────────────────────────────────

        private static List<Token> Tokenize(string input)
        {
            var tokens = new List<Token>();
            int i = 0;

            while (i < input.Length)
            {
                // Skip whitespace
                if (char.IsWhiteSpace(input[i])) { i++; continue; }

                // Block comment  (* ... *)
                if (i + 1 < input.Length && input[i] == '(' && input[i + 1] == '*')
                {
                    i += 2;
                    while (i + 1 < input.Length && !(input[i] == '*' && input[i + 1] == ')')) i++;
                    i += 2;
                    continue;
                }

                char c = input[i];
                switch (c)
                {
                    case '=': tokens.Add(new Token(TokenType.Equals,        "=")); i++; break;
                    case ';': tokens.Add(new Token(TokenType.Semicolon,     ";")); i++; break;
                    case '|': tokens.Add(new Token(TokenType.Pipe,          "|")); i++; break;
                    case ',': tokens.Add(new Token(TokenType.Comma,         ",")); i++; break;
                    case '[': tokens.Add(new Token(TokenType.OpenBracket,   "[")); i++; break;
                    case ']': tokens.Add(new Token(TokenType.CloseBracket,  "]")); i++; break;
                    case '{': tokens.Add(new Token(TokenType.OpenBrace,     "{")); i++; break;
                    case '}': tokens.Add(new Token(TokenType.CloseBrace,    "}")); i++; break;
                    case '(': tokens.Add(new Token(TokenType.OpenParen,     "(")); i++; break;
                    case ')': tokens.Add(new Token(TokenType.CloseParen,    ")")); i++; break;

                    case '"':
                    case '\'':
                    {
                        char quote = c; i++;
                        var sb = new StringBuilder();
                        while (i < input.Length && input[i] != quote)
                        {
                            // basic escape: \" or \'
                            if (input[i] == '\\' && i + 1 < input.Length) sb.Append(input[++i]);
                            else sb.Append(input[i]);
                            i++;
                        }
                        if (i < input.Length) i++; // consume closing quote
                        tokens.Add(new Token(TokenType.String, sb.ToString()));
                        break;
                    }

                    case '?': // special sequence  ? raw-regex ?
                    {
                        i++;
                        var sb = new StringBuilder();
                        while (i < input.Length && input[i] != '?') sb.Append(input[i++]);
                        if (i < input.Length) i++; // consume closing '?'
                        tokens.Add(new Token(TokenType.Special, sb.ToString().Trim()));
                        break;
                    }

                    default:
                        if (char.IsLetter(c) || c == '_')
                        {
                            var sb = new StringBuilder();
                            while (i < input.Length &&
                                   (char.IsLetterOrDigit(input[i]) || input[i] == '_' || input[i] == '-'))
                                sb.Append(input[i++]);
                            tokens.Add(new Token(TokenType.Identifier, sb.ToString()));
                        }
                        else
        {
                            throw new FormatException(
                                $"Unexpected character '{c}' at position {i} in EBNF grammar.");
                        }
                        break;
                }
            }

            tokens.Add(new Token(TokenType.EOF, string.Empty));
            return tokens;
        }

        // ── Recursive-descent parser ─────────────────────────────────────────────
        //
        //  grammar         = { rule_definition }
        //  rule_definition = identifier "=" expression ";"
        //  expression      = term { "|" term }
        //  term            = factor { "," factor }
        //  factor          = "[" expression "]"
        //                  | "{" expression "}"
        //                  | "(" expression ")"
        //                  | terminal_string
        //                  | special_sequence
        //                  | identifier

        // rule_definition = identifier "=" expression ";"
        private static RuleBase ParseRuleDefinition(List<Token> tokens, ref int pos)
        {
            var name = Expect(tokens, ref pos, TokenType.Identifier).Value;
            Expect(tokens, ref pos, TokenType.Equals);
            var rule = ParseExpression(tokens, ref pos);
            Expect(tokens, ref pos, TokenType.Semicolon);

            // A bare ReferenceRule would be replaced (losing its name) during
            // Parser.Initialize(). Wrap it so the name survives resolution.
            if (rule is ReferenceRule)
            {
                var wrapper = new SequenceRule();
                wrapper.Rules.Add(rule);
                rule = wrapper;
            }

            rule.Name = name;
            return rule;
        }

        // expression = term { "|" term }
        private static RuleBase ParseExpression(List<Token> tokens, ref int pos)
        {
            var first = ParseTerm(tokens, ref pos);
            if (Peek(tokens, pos) != TokenType.Pipe) return first;

            var choice = new ChoiceRule();
            choice.Rules.Add(first);
            while (Peek(tokens, pos) == TokenType.Pipe)
            {
                pos++; // consume '|'
                choice.Rules.Add(ParseTerm(tokens, ref pos));
            }
            return choice;
        }

        // term = factor { "," factor }
        private static RuleBase ParseTerm(List<Token> tokens, ref int pos)
        {
            var first = ParseFactor(tokens, ref pos);
            if (Peek(tokens, pos) != TokenType.Comma) return first;

            var seq = new SequenceRule();
            seq.Rules.Add(first);
            while (Peek(tokens, pos) == TokenType.Comma)
            {
                pos++; // consume ','
                seq.Rules.Add(ParseFactor(tokens, ref pos));
            }
            return seq;
        }

        // factor = "[" expr "]" | "{" expr "}" | "(" expr ")" | string | special | identifier
        private static RuleBase ParseFactor(List<Token> tokens, ref int pos)
        {
            switch (Peek(tokens, pos))
            {
                case TokenType.OpenBracket: // [ expr ]  →  OptionalRule
                {
                    pos++;
                    var inner = ParseExpression(tokens, ref pos);
                    Expect(tokens, ref pos, TokenType.CloseBracket);
                    return new OptionalRule { Rule = inner };
                }

                case TokenType.OpenBrace: // { expr }  →  zero-or-more = OptionalRule(OneOrMoreRule)
                {
                    pos++;
                    var inner = ParseExpression(tokens, ref pos);
                    Expect(tokens, ref pos, TokenType.CloseBrace);
                    return new OptionalRule { Rule = new OneOrMoreRule { Rule = inner } };
                }

                case TokenType.OpenParen: // ( expr )  →  grouping (no extra wrapper)
                {
                    pos++;
                    var inner = ParseExpression(tokens, ref pos);
                    Expect(tokens, ref pos, TokenType.CloseParen);
                    return inner;
                }

                case TokenType.String: // "text" / 'text'  →  escaped regex literal
                    return new SymbolRule(Regex.Escape(tokens[pos++].Value));

                case TokenType.Special: // ? regex ?  →  raw regex pattern
                    return new SymbolRule(tokens[pos++].Value);

                case TokenType.Identifier: // rule-name  →  resolved later by Parser.Initialize()
                    return new ReferenceRule(tokens[pos++].Value);

                default:
                    var bad = tokens[pos];
                    throw new FormatException(
                        $"Unexpected token '{bad.Value}' ({bad.Type}) in EBNF expression.");
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static TokenType Peek(List<Token> tokens, int pos)
            => pos < tokens.Count ? tokens[pos].Type : TokenType.EOF;

        private static Token Expect(List<Token> tokens, ref int pos, TokenType expected)
        {
            var token = pos < tokens.Count ? tokens[pos] : new Token(TokenType.EOF, string.Empty);
            if (token.Type != expected)
                throw new FormatException(
                    $"Expected {expected} but found '{token.Value}' ({token.Type}).");
            return tokens[pos++];
        }
    }
}
