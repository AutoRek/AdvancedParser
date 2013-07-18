using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ApiSoftware.Library35;
using ApiSoftware.Library35.TextProcessing;
using ApiSoftware.Library35.DataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TokeniserTest
{
[TestMethod]
public void Test_Tokenise_Expression()
{
	var expression = "LOCALHOST";
	var testResult = Tokeniser.Tokenise(expression);
	Assert.IsInstanceOfType(testResult, typeof(String[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_Tokenise_ExpressionNotTokensLongTokensDelims()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var expression = "LOCALHOST";
	var notTokens = "LOCALHOST";
	var longTokens = "LOCALHOST";
	var delims = "LOCALHOST";
	var testResult = Tokeniser.Tokenise(expression, notTokens, longTokens, delims);
	});
}

}

[TestClass]
public class CommandTest
{
}

[TestClass]
public class ReplaceTest
{
[TestMethod]
public void Test_get_Pattern()
{
	var testObject = new Replace();
	var testResult = testObject.get_Pattern();
}

[TestMethod]
public void Test_set_Pattern_Value()
{
	var testObject = new Replace();
	var value = "LOCALHOST";
	testObject.set_Pattern(value);
}

[TestMethod]
public void Test_get_Replacement()
{
	var testObject = new Replace();
	var testResult = testObject.get_Replacement();
}

[TestMethod]
public void Test_set_Replacement_Value()
{
	var testObject = new Replace();
	var value = "LOCALHOST";
	testObject.set_Replacement(value);
}

[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new Replace();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class ExpressionTest
{
}

[TestClass]
public class DataSetHelperTest
{
[TestMethod]
public void Test_NameTables_DataSetNameTableIndexRemoveNameTableNameColumn()
{
	var dataSet = new DataTable("TestTable").DataSet;
	var nameTableIndex = -1;
	var removeNameTable = true;
	var nameColumn = "LOCALHOST";
	DataSetHelper.NameTables(dataSet, nameTableIndex, removeNameTable, nameColumn);
}

[TestMethod]
public void Test_CountRows_DataSet()
{
	var dataSet = new DataTable("TestTable").DataSet;
	var testResult = DataSetHelper.CountRows(dataSet);
	// Collection
}

[TestMethod]
public void Test_CopyRows_ToFromRows()
{
	var to = new DataTable("TestTable");
	var from = new DataTable("TestTable");
	var rows = -1;
	DataSetHelper.CopyRows(to, from, rows);
}

[TestMethod]
public void Test_CopyColumns_ToFromDeleteFirst()
{
	var to = new DataTable("TestTable");
	var from = new DataTable("TestTable");
	var deleteFirst = true;
	DataSetHelper.CopyColumns(to, from, deleteFirst);
}

[TestMethod]
public void Test_ReadDelimitedData_TableTextOptions()
{
	var table = new DataTable("TestTable");
	var text = "LOCALHOST";
	var options = new Options();
	DataSetHelper.ReadDelimitedData(table, text, options);
}

[TestMethod]
public void Test_WriteDelimitedData_TableFileNameColumnDelimiterHeaderFieldDelimiterLineDelimiter()
{
	var table = new DataTable("TestTable");
	var fileName = "LOCALHOST";
	var columnDelimiter = "LOCALHOST";
	var header = true;
	var fieldDelimiter = "LOCALHOST";
	var lineDelimiter = "LOCALHOST";
	DataSetHelper.WriteDelimitedData(table, fileName, columnDelimiter, header, fieldDelimiter, lineDelimiter);
}

}

[TestClass]
public class DataGeneratorTest
{
}

[TestClass]
public class NetworkTest
{
[TestMethod]
public void Test_GetSqlServers()
{
	var testResult = Network.GetSqlServers();
	Assert.IsInstanceOfType(testResult, typeof(String[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

}

[TestClass]
public class DictionariesTest
{
[TestMethod]
public void Test_AddKeyValues_DictText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	Dictionaries.AddKeyValues(dict, text);
	});
}

[TestMethod]
public void Test_AddKeyValues_DictTextItemDelim()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	var itemDelim = "LOCALHOST";
	Dictionaries.AddKeyValues(dict, text, itemDelim);
	});
}

[TestMethod]
public void Test_AddKeyValues_DictTextValueSepItemDelim()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	var valueSep = "LOCALHOST";
	var itemDelim = "LOCALHOST";
	Dictionaries.AddKeyValues(dict, text, valueSep, itemDelim);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictUrl()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var url = new Uri("http://www.google.com");
	Dictionaries.SetKeyValues(dict, url);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictNameValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var nameValues = new NameValueCollection();
	Dictionaries.SetKeyValues(dict, nameValues);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	Dictionaries.SetKeyValues(dict, text);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictTextItemDelimMapping()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	var itemDelim = "LOCALHOST";
	var mapping = new Dictionary<string, object>();
	Dictionaries.SetKeyValues(dict, text, itemDelim, mapping);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictTextItemDelim()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	var itemDelim = "LOCALHOST";
	Dictionaries.SetKeyValues(dict, text, itemDelim);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictTextValueSepItemDelim()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var text = "LOCALHOST";
	var valueSep = "LOCALHOST";
	var itemDelim = "LOCALHOST";
	Dictionaries.SetKeyValues(dict, text, valueSep, itemDelim);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var item = new DataRow();
	Dictionaries.SetKeyValues(dict, item);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var record = new IDataRecord();
	Dictionaries.SetKeyValues(dict, record);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictXml()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var xml = new XmlDocument();
	Dictionaries.SetKeyValues(dict, xml);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var item = new Object();
	Dictionaries.SetKeyValues(dict, item);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictItemPrefixRecursive()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var item = new Object();
	var prefix = "LOCALHOST";
	var recursive = true;
	Dictionaries.SetKeyValues(dict, item, prefix, recursive);
	});
}

[TestMethod]
public void Test_SetKeyValues_DictDictionary()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var dictionary = new IDictionary();
	Dictionaries.SetKeyValues(dict, dictionary);
	});
}

[TestMethod]
public void Test_Merge_DictInputs()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var inputs = new IDictionary[]();
	Dictionaries.Merge(dict, inputs);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_Add_TargetInput()
{
	var target = new Dictionary<string,object>();
	var input = new NameValueCollection();
	Dictionaries.Add(target, input);
}

[TestMethod]
public void Test_Add_TargetUrl()
{
	var target = new Dictionary<string,object>();
	var url = new Uri("http://www.google.com");
	Dictionaries.Add(target, url);
	// Dictionaries.Add
	// Index was outside the bounds of the array.
}

[TestMethod]
public void Test_SetValuesFromUrl_DictUrl()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dict = new IDictionary();
	var url = "LOCALHOST";
	Dictionaries.SetValuesFromUrl(dict, url);
	});
}

[TestMethod]
public void Test_Format_DictTemplatePrefixSuffix()
{
	var dict = new IDictionary<string, object>();
	var template = "LOCALHOST";
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Dictionaries.Format(dict, template, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ToEnumerable_Collection()
{
	var collection = new NameValueCollection();
	var testResult = Dictionaries.ToEnumerable(collection);
	Assert.AreEqual([, ], testResult.Current);
}

}

[TestClass]
public class UrlUtilitiesTest
{
[TestMethod]
public void Test_InferParameterMapping_Url()
{
	var url = new Uri("http://www.google.com");
	var testResult = UrlUtilities.InferParameterMapping(url);
	Assert.AreEqual(-1, testResult.Count);
	// Parameter count mismatch.
}

[TestMethod]
public void Test_AddInferParameterMapping_DictionaryUrl()
{
	var dictionary = new Dictionary<string,object>();
	var url = new Uri("http://www.google.com");
	UrlUtilities.AddInferParameterMapping(dictionary, url);
}

[TestMethod]
public void Test_AddQuerystringParameters_DictionaryUrlIgnoreParams()
{
	var dictionary = new Dictionary<string,object>();
	var url = new Uri("http://www.google.com");
	var ignoreParams = new IList<string>();
	UrlUtilities.AddQuerystringParameters(dictionary, url, ignoreParams);
}

[TestMethod]
public void Test_AddQuerystringParameters_DictionaryUrlIgnoreParams()
{
	var dictionary = new IDictionary<string, object>();
	var url = new Uri("http://www.google.com");
	var ignoreParams = new IList<string>();
	UrlUtilities.AddQuerystringParameters(dictionary, url, ignoreParams);
}

[TestMethod]
public void Test_AddQuerystringParameters_DictionaryUrlIgnoreParams()
{
	var dictionary = new Dictionary<string,object>();
	var url = new Uri("http://www.google.com");
	var ignoreParams = new IList<string>();
	UrlUtilities.AddQuerystringParameters(dictionary, url, ignoreParams);
}

[TestMethod]
public void Test_AddQuerystringParameters_DictionaryUrlIgnoreParams()
{
	var dictionary = new Dictionary<string, object>();
	var url = new Uri("http://www.google.com");
	var ignoreParams = new IList<string>();
	UrlUtilities.AddQuerystringParameters(dictionary, url, ignoreParams);
}

}

[TestClass]
public class ParametersTest
{
[TestMethod]
public void Test_Add_Value()
{
	var testObject = new Parameters();
	var value = ;
	testObject.Add(value);
}

[TestMethod]
public void Test_Add_NameValue()
{
	var testObject = new Parameters();
	var name = "LOCALHOST";
	var value = new Object();
	testObject.Add(name, value);
}

[TestMethod]
public void Test_Add_Dictionary()
{
	var testObject = new Parameters();
	var dictionary = new Dictionary<string,object>();
	testObject.Add(dictionary);
}

[TestMethod]
public void Test_AddRange_Parameters()
{
	var testObject = new Parameters();
	var parameters = new Parameters();
	testObject.AddRange(parameters);
}

[TestMethod]
public void Test_Merge_Dictionary()
{
	var testObject = new Parameters();
	var dictionary = new Dictionary<string,object>();
	testObject.Merge(dictionary);
}

[TestMethod]
public void Test_get_Names()
{
	var testObject = new Parameters();
	var testResult = testObject.get_Names();
}

[TestMethod]
public void Test_get_Values()
{
	var testObject = new Parameters();
	var testResult = testObject.get_Values();
}

[TestMethod]
public void Test_ToDictionary()
{
	var testObject = new Parameters();
	var testResult = testObject.ToDictionary();
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_op_Implicit_Dictionary()
{
	var dictionary = new Dictionary<string,object>();
	var testResult = Parameters.op_Implicit(dictionary);
	Assert.IsInstanceOfType(testResult, typeof(Parameters));
	Assert.AreEqual("LOCALHOST", testResult.Names);
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_get_Comparer()
{
	var testObject = new Parameters();
	var testResult = testObject.get_Comparer();
}

[TestMethod]
public void Test_get_Item_Key()
{
	var testObject = new Parameters();
	var key = "LOCALHOST";
	var testResult = testObject.get_Item(key);
	// Collection
}

[TestMethod]
public void Test_Contains_Key()
{
	var testObject = new Parameters();
	var key = "LOCALHOST";
	var testResult = testObject.Contains(key);
}

[TestMethod]
public void Test_Remove_Key()
{
	var testObject = new Parameters();
	var key = "LOCALHOST";
	var testResult = testObject.Remove(key);
}

[TestMethod]
public void Test_get_Count()
{
	var testObject = new Parameters();
	var testResult = testObject.get_Count();
}

[TestMethod]
public void Test_get_Item_Index()
{
	var testObject = new Parameters();
	var index = -1;
	var testResult = testObject.get_Item(index);
	// Collection
}

[TestMethod]
public void Test_set_Item_IndexValue()
{
	var testObject = new Parameters();
	var index = -1;
	var value = new Parameter();
	testObject.set_Item(index, value);
}

[TestMethod]
public void Test_Add_Item()
{
	var testObject = new Parameters();
	var item = new Parameter();
	testObject.Add(item);
}

[TestMethod]
public void Test_Clear()
{
	var testObject = new Parameters();
	testObject.Clear();
}

[TestMethod]
public void Test_CopyTo_ArrayIndex()
{
	var testObject = new Parameters();
	var array = new Parameter[]();
	var index = -1;
	testObject.CopyTo(array, index);
}

[TestMethod]
public void Test_Contains_Item()
{
	var testObject = new Parameters();
	var item = new Parameter();
	var testResult = testObject.Contains(item);
}

[TestMethod]
public void Test_GetEnumerator()
{
	var testObject = new Parameters();
	var testResult = testObject.GetEnumerator();
}

[TestMethod]
public void Test_IndexOf_Item()
{
	var testObject = new Parameters();
	var item = new Parameter();
	var testResult = testObject.IndexOf(item);
}

[TestMethod]
public void Test_Insert_IndexItem()
{
	var testObject = new Parameters();
	var index = -1;
	var item = new Parameter();
	testObject.Insert(index, item);
}

[TestMethod]
public void Test_Remove_Item()
{
	var testObject = new Parameters();
	var item = new Parameter();
	var testResult = testObject.Remove(item);
}

[TestMethod]
public void Test_RemoveAt_Index()
{
	var testObject = new Parameters();
	var index = -1;
	testObject.RemoveAt(index);
}

}

[TestClass]
public class IFileErrorHandlerTest
{
}

[TestClass]
public class FixedWidthDataReaderTest
{
[TestMethod]
public void Test_GuessOptions_PathSampleRowNum()
{
	var path = "LOCALHOST";
	var sampleRowNum = -1;
	var testResult = FixedWidthDataReader.GuessOptions(path, sampleRowNum);
	// Collection
}

[TestMethod]
public void Test_GuessOptions_PathSampleRowNumSkipRowsColumnHeaders()
{
	var path = "LOCALHOST";
	var sampleRowNum = -1;
	var skipRows = -1;
	var columnHeaders = true;
	var testResult = FixedWidthDataReader.GuessOptions(path, sampleRowNum, skipRows, columnHeaders);
	// Collection
}

[TestMethod]
public void Test_GuessOptions_ReaderSampleRowNumSkipRowsColumnHeadersTrimWhiteSpaceInferDateFormat()
{
	var reader = new TextReader();
	var sampleRowNum = -1;
	var skipRows = -1;
	var columnHeaders = true;
	var trimWhiteSpace = true;
	var inferDateFormat = true;
	var testResult = FixedWidthDataReader.GuessOptions(reader, sampleRowNum, skipRows, columnHeaders, trimWhiteSpace, inferDateFormat);
	// FixedWidthDataReader.GuessOptions
	// Object reference not set to an instance of an object.
}

[TestMethod]
public void Test_GuessOptions_StreamSampleRowNumSkipRowsColumnHeaders()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var sampleRowNum = -1;
	var skipRows = -1;
	var columnHeaders = true;
	var testResult = FixedWidthDataReader.GuessOptions(stream, sampleRowNum, skipRows, columnHeaders);
	});
}

[TestMethod]
public void Test_InferColumns_ReaderOptions()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var options = new Options();
	FixedWidthDataReader.InferColumns(reader, options);
	});
}

[TestMethod]
public void Test_GuessColumnsHeaders_ReaderOptionsSkipRows()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var options = new Options();
	var skipRows = -1;
	var testResult = FixedWidthDataReader.GuessColumnsHeaders(reader, options, skipRows);
	});
}

}

[TestClass]
public class DiagnosticsTest
{
[TestMethod]
public void Test_WriteToEventLog_ESourceEventLog()
{
	var e = new Exception();
	var source = "LOCALHOST";
	var eventLog = "LOCALHOST";
	Diagnostics.WriteToEventLog(e, source, eventLog);
}

[TestMethod]
public void Test_ToFullString_E()
{
	var e = new Exception();
	var testResult = Diagnostics.ToFullString(e);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Write_CommentArgs()
{
	var comment = "LOCALHOST";
	var args = (object[])null;
	Diagnostics.Write(comment, args);
}

[TestMethod]
public void Test_MethodEnter_MethodNameArgs()
{
	var methodName = "LOCALHOST";
	var args = (object[])null;
	Diagnostics.MethodEnter(methodName, args);
}

[TestMethod]
public void Test_MethodExit_MethodNameArgs()
{
	var methodName = "LOCALHOST";
	var args = (object[])null;
	Diagnostics.MethodExit(methodName, args);
}

[TestMethod]
public void Test_GetDebugInfo_ItemMessage()
{
	var item = new Object();
	var message = "LOCALHOST";
	var testResult = Diagnostics.GetDebugInfo(item, message);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}

[TestClass]
public class ColumnDefinitionTest
{
}

[TestClass]
public class ObjectDictionaryTest
{
[TestMethod]
public void Test_op_Implicit_Value()
{
	var value = new DataRow();
	var testResult = ObjectDictionary.op_Implicit(value);
	Assert.IsInstanceOfType(testResult, typeof(ObjectDictionary));
	// Exception has been thrown by the target of an invocation.
}

}

[TestClass]
public class ConvertValueTest
{
[TestMethod]
public void Test_ToDecimalDays_Eval()
{
	var eval = "LOCALHOST";
	var testResult = ConvertValue.ToDecimalDays(eval);
	// Collection
}

[TestMethod]
public void Test_ToTimeSpan_Value()
{
	var value = -1.23M;
	var testResult = ConvertValue.ToTimeSpan(value);
	// Collection
}

[TestMethod]
public void Test_ToTimeString_Value()
{
	var value = -1.23M;
	var testResult = ConvertValue.ToTimeString(value);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_TryParseDecimalDays_ValueResult()
{
	var value = "LOCALHOST";
	var result = -1.23M;
	var testResult = ConvertValue.TryParseDecimalDays(value, result);
	// Collection
}

[TestMethod]
public void Test_ToHex_Bytes()
{
	var bytes = (byte[])null;
	var testResult = ConvertValue.ToHex(bytes);
}

[TestMethod]
public void Test_FromHex_HexString()
{
	var hexString = "LOCALHOST";
	var testResult = ConvertValue.FromHex(hexString);
	// ConvertValue.FromHex
	// Could not find any recognizable digits.
}

}

[TestClass]
public class ConnectionStringsTest
{
[TestMethod]
public void Test_Build_ConnectionStringValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connectionString = "LOCALHOST";
	var values = (string[])null;
	var testResult = ConnectionStrings.Build(connectionString, values);
	});
}

[TestMethod]
public void Test_BuildSqlConnectionString_Server()
{
	var server = "LOCALHOST";
	var testResult = ConnectionStrings.BuildSqlConnectionString(server);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildSqlConnectionString_ServerDatabase()
{
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var testResult = ConnectionStrings.BuildSqlConnectionString(server, database);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildSqlConnectionString_ServerDatabaseAsync()
{
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var async = true;
	var testResult = ConnectionStrings.BuildSqlConnectionString(server, database, async);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildSqlConnectionString_ServerUserPassword()
{
	var server = "LOCALHOST";
	var user = "LOCALHOST";
	var password = "LOCALHOST";
	var testResult = ConnectionStrings.BuildSqlConnectionString(server, user, password);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildSqlConnectionString_ServerDatabaseUserPassword()
{
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var user = "LOCALHOST";
	var password = "LOCALHOST";
	var testResult = ConnectionStrings.BuildSqlConnectionString(server, database, user, password);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildSqlConnectionString_ServerDatabaseUserPasswordAsync()
{
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var user = "LOCALHOST";
	var password = "LOCALHOST";
	var async = true;
	var testResult = ConnectionStrings.BuildSqlConnectionString(server, database, user, password, async);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildOleDbConnectionString_ProviderServer()
{
	var provider = "LOCALHOST";
	var server = "LOCALHOST";
	var testResult = ConnectionStrings.BuildOleDbConnectionString(provider, server);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildOleDbConnectionString_ProviderServerDatabase()
{
	var provider = "LOCALHOST";
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var testResult = ConnectionStrings.BuildOleDbConnectionString(provider, server, database);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildOleDbConnectionString_ProviderServerUserPassword()
{
	var provider = "LOCALHOST";
	var server = "LOCALHOST";
	var user = "LOCALHOST";
	var password = "LOCALHOST";
	var testResult = ConnectionStrings.BuildOleDbConnectionString(provider, server, user, password);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_BuildOleDbConnectionString_ProviderServerDatabaseUserPassword()
{
	var provider = "LOCALHOST";
	var server = "LOCALHOST";
	var database = "LOCALHOST";
	var user = "LOCALHOST";
	var password = "LOCALHOST";
	var testResult = ConnectionStrings.BuildOleDbConnectionString(provider, server, database, user, password);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}

[TestClass]
public class XmlExtensionsTest
{
[TestMethod]
public void Test_TransformScript_XmlDocScript()
{
	var xmlDoc = new XmlDocument();
	var script = "LOCALHOST";
	var testResult = XmlExtensions.TransformScript(xmlDoc, script);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_TransformScript_XmlDocScriptParamNamesValues()
{
	var xmlDoc = new XmlDocument();
	var script = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = XmlExtensions.TransformScript(xmlDoc, script, paramNames, values);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Transform_XmlDocXslt()
{
	var xmlDoc = new XmlDocument();
	var xslt = "LOCALHOST";
	var testResult = XmlExtensions.Transform(xmlDoc, xslt);
	// XmlExtensions.Transform
	// Data at the root level is invalid. Line 1, position 1.
}

[TestMethod]
public void Test_Transform_XmlDocXsltParamNamesValues()
{
	var xmlDoc = new XmlDocument();
	var xslt = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = XmlExtensions.Transform(xmlDoc, xslt, paramNames, values);
	// XmlExtensions.Transform
	// Data at the root level is invalid. Line 1, position 1.
}

[TestMethod]
public void Test_Transform_XmlDocXsltArgs()
{
	var xmlDoc = new XmlDocument();
	var xslt = "LOCALHOST";
	var args = new XsltArgumentList();
	var testResult = XmlExtensions.Transform(xmlDoc, xslt, args);
	// XmlExtensions.Transform
	// Data at the root level is invalid. Line 1, position 1.
}

[TestMethod]
public void Test_GenerateXslt_ScriptParamNames()
{
	var script = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var testResult = XmlExtensions.GenerateXslt(script, paramNames);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ReadXmlString_DataSetXmlString()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var dataSet = new DataTable("TestTable").DataSet;
	var xmlString = "LOCALHOST";
	XmlExtensions.ReadXmlString(dataSet, xmlString);
	});
}

[TestMethod]
public void Test_CreateArgumentList_ParamNamesValues()
{
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = XmlExtensions.CreateArgumentList(paramNames, values);
}

[TestMethod]
public void Test_Format_Input()
{
	var input = "LOCALHOST";
	var testResult = XmlExtensions.Format(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}

[TestClass]
public class StorageAttributeTest
{
[TestMethod]
public void Test_get_Prefix()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_Prefix();
}

[TestMethod]
public void Test_get_SelectCommand()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_SelectCommand();
}

[TestMethod]
public void Test_set_SelectCommand_Value()
{
	var testObject = new StorageAttribute();
	var value = "LOCALHOST";
	testObject.set_SelectCommand(value);
}

[TestMethod]
public void Test_get_SaveCommand()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_SaveCommand();
}

[TestMethod]
public void Test_set_SaveCommand_Value()
{
	var testObject = new StorageAttribute();
	var value = "LOCALHOST";
	testObject.set_SaveCommand(value);
}

[TestMethod]
public void Test_get_DeleteCommand()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_DeleteCommand();
}

[TestMethod]
public void Test_set_DeleteCommand_Value()
{
	var testObject = new StorageAttribute();
	var value = "LOCALHOST";
	testObject.set_DeleteCommand(value);
}

[TestMethod]
public void Test_get_CommandType()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_CommandType();
}

[TestMethod]
public void Test_set_CommandType_Value()
{
	var testObject = new StorageAttribute();
	var value = CommandType.Text;
	testObject.set_CommandType(value);
}

[TestMethod]
public void Test_get_UseXmlField()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_UseXmlField();
}

[TestMethod]
public void Test_set_UseXmlField_Value()
{
	var testObject = new StorageAttribute();
	var value = true;
	testObject.set_UseXmlField(value);
}

[TestMethod]
public void Test_get_Key()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_Key();
}

[TestMethod]
public void Test_set_Key_Value()
{
	var testObject = new StorageAttribute();
	var value = "LOCALHOST";
	testObject.set_Key(value);
}

[TestMethod]
public void Test_Read_Type()
{
	var type = new Type();
	var testResult = StorageAttribute.Read(type);
}

[TestMethod]
public void Test_get_TableName()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_TableName();
}

[TestMethod]
public void Test_set_TableName_Value()
{
	var testObject = new StorageAttribute();
	var value = "LOCALHOST";
	testObject.set_TableName(value);
}

[TestMethod]
public void Test_get_TypeId()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.get_TypeId();
	// Collection
}

[TestMethod]
public void Test_Match_Obj()
{
	var testObject = new StorageAttribute();
	var obj = new Object();
	var testResult = testObject.Match(obj);
}

[TestMethod]
public void Test_IsDefaultAttribute()
{
	var testObject = new StorageAttribute();
	var testResult = testObject.IsDefaultAttribute();
}

}

[TestClass]
public class Result1Test
{
[TestMethod]
public void Test_get_Value()
{
	var testObject = new Result<string>();
	var testResult = testObject.get_Value();
}

[TestMethod]
public void Test_set_Value_Value()
{
	var testObject = new Result<string>();
	var value = new T();
	testObject.set_Value(value);
}

[TestMethod]
public void Test_get_HasValue()
{
	var testObject = new Result<string>();
	var testResult = testObject.get_HasValue();
}

[TestMethod]
public void Test_get_Exception()
{
	var testObject = new Result<string>();
	var testResult = testObject.get_Exception();
}

[TestMethod]
public void Test_set_Exception_Value()
{
	var testObject = new Result<string>();
	var value = "LOCALHOST";
	testObject.set_Exception(value);
}

}

[TestClass]
public class ToLowerTest
{
[TestMethod]
public void Test_get_Pattern()
{
	var testObject = new ToLower();
	var testResult = testObject.get_Pattern();
}

[TestMethod]
public void Test_set_Pattern_Value()
{
	var testObject = new ToLower();
	var value = "LOCALHOST";
	testObject.set_Pattern(value);
}

[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new ToLower();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class ExcelTest
{
[TestMethod]
public void Test_LoadExcel_PathInferColumnHeaders()
{
	var path = "LOCALHOST";
	var inferColumnHeaders = true;
	var testResult = Excel.LoadExcel(path, inferColumnHeaders);
	// Excel.LoadExcel
	// Could not load file or assembly 'Net.SourceForge.Koogra, Version=3.1.5.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
}

[TestMethod]
public void Test_LoadExcel_StreamInferColumnHeaders()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var inferColumnHeaders = true;
	var testResult = Excel.LoadExcel(stream, inferColumnHeaders);
	});
}

[TestMethod]
public void Test_LoadExcel_DataInferColumnHeaders()
{
	var data = (byte[])null;
	var inferColumnHeaders = true;
	var testResult = Excel.LoadExcel(data, inferColumnHeaders);
	// Excel.LoadExcel
	// Could not load file or assembly 'Net.SourceForge.Koogra, Version=3.1.5.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
}

}

[TestClass]
public class EncryptionTest
{
[TestMethod]
public void Test_Encrypt_TextPassword()
{
	var text = "LOCALHOST";
	var password = "LOCALHOST";
	var testResult = Encryption.Encrypt(text, password);
	Assert.IsInstanceOfType(testResult, typeof(Byte[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_Encrypt_TextPasswordSalt()
{
	var text = "LOCALHOST";
	var password = "LOCALHOST";
	var salt = new Object();
	var testResult = Encryption.Encrypt(text, password, salt);
	Assert.IsInstanceOfType(testResult, typeof(Byte[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_Encrypt_TextPasswordSalt()
{
	var text = "LOCALHOST";
	var password = "LOCALHOST";
	var salt = (byte[])null;
	var testResult = Encryption.Encrypt(text, password, salt);
	Assert.IsInstanceOfType(testResult, typeof(Byte[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_Decrypt_DataPassword()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var data = (byte[])null;
	var password = "LOCALHOST";
	var testResult = Encryption.Decrypt(data, password);
	});
}

[TestMethod]
public void Test_Decrypt_DataPasswordSalt()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var data = (byte[])null;
	var password = "LOCALHOST";
	var salt = new Object();
	var testResult = Encryption.Decrypt(data, password, salt);
	});
}

[TestMethod]
public void Test_Decrypt_DataPasswordSalt()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var data = (byte[])null;
	var password = "LOCALHOST";
	var salt = (byte[])null;
	var testResult = Encryption.Decrypt(data, password, salt);
	});
}

[TestMethod]
public void Test_EncryptText_TextPasswordSalt()
{
	var text = "LOCALHOST";
	var password = "LOCALHOST";
	var salt = new Object();
	var testResult = Encryption.EncryptText(text, password, salt);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_DecryptText_Base64PasswordSalt()
{
	var base64 = "LOCALHOST";
	var password = "LOCALHOST";
	var salt = new Object();
	var testResult = Encryption.DecryptText(base64, password, salt);
	// Encryption.DecryptText
	// Invalid length for a Base-64 char array or string.
}

[TestMethod]
public void Test_DecryptSecure_PasswordData()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var password = "LOCALHOST";
	var data = (byte[])null;
	var testResult = Encryption.DecryptSecure(password, data);
	});
}

[TestMethod]
public void Test_CreateHash_InputSalt()
{
	var input = "LOCALHOST";
	var salt = "LOCALHOST";
	var testResult = Encryption.CreateHash(input, salt);
	Assert.IsInstanceOfType(testResult, typeof(Byte[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_CreateHashString_InputSalt()
{
	var input = "LOCALHOST";
	var salt = "LOCALHOST";
	var testResult = Encryption.CreateHashString(input, salt);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_GeneratePassword_LengthMinCharMaxCharDisallowed()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var length = -1;
	var minChar = "LOCALHOST";
	var maxChar = "LOCALHOST";
	var disallowed = "LOCALHOST";
	var testResult = Encryption.GeneratePassword(length, minChar, maxChar, disallowed);
	});
}

[TestMethod]
public void Test_GenerateFriendlyPassword_MinLengthMaxLength()
{
	var minLength = -1;
	var maxLength = -1;
	var testResult = Encryption.GenerateFriendlyPassword(minLength, maxLength);
	// Encryption.GenerateFriendlyPassword
	// Arithmetic operation resulted in an overflow.
}

}

[TestClass]
public class ColoursTest
{
[TestMethod]
public void Test_ResolveColourValue_ValueDefaultValue()
{
	var value = "LOCALHOST";
	var defaultValue = ;
	var testResult = Colours.ResolveColourValue(value, defaultValue);
	// Collection
}

[TestMethod]
public void Test_ToHexString_ColourHtmlHex()
{
	var colour = ;
	var htmlHex = true;
	var testResult = Colours.ToHexString(colour, htmlHex);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ToRGBString_Colour()
{
	var colour = ;
	var testResult = Colours.ToRGBString(colour);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ToDecimalString_Colour()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var colour = ;
	var testResult = Colours.ToDecimalString(colour);
	});
}

}

[TestClass]
public class ArraysTest
{
[TestMethod]
public void Test_Contains_ListValue()
{
	var list = new IEnumerable();
	var value = new Object();
	var testResult = Arrays.Contains(list, value);
	// Collection
}

[TestMethod]
public void Test_IndexOf_ListValueComparison()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var list = new IEnumerable<string>();
	var value = "LOCALHOST";
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Arrays.IndexOf(list, value, comparison);
	});
}

	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_GetItems_ListIndexes()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var list = new IList();
	var indexes = new IEnumerable();
	var testResult = Arrays.GetItems(list, indexes);
	});
}

	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ToList_List()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var list = new IEnumerable();
	var testResult = Arrays.ToList(list);
	});
}

[TestMethod]
public void Test_RemoveWhere_ListCriteria()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var list = new IList();
	var criteria = new Func<string, object>();
	Arrays.RemoveWhere(list, criteria);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_Array_Items()
{
	var items = (object[])null;
	var testResult = Arrays.Array(items);
}

[TestMethod]
public void Test_Array_Items()
{
	var items = (string[])null;
	var testResult = Arrays.Array(items);
}

[TestMethod]
public void Test_Array_Items()
{
	var items = (int[])null;
	var testResult = Arrays.Array(items);
}

	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ToDataTable_ListItemTypeKeepRowIndexesStoreEnumAsString()
{
	var list = new IEnumerable();
	var itemType = new Type();
	var keepRowIndexes = true;
	var StoreEnumAsString = true;
	var testResult = Arrays.ToDataTable(list, itemType, keepRowIndexes, StoreEnumAsString);
}

[TestMethod]
public void Test_CreateTable_TableNamePropertiesStoreEnumAsString()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var tableName = "LOCALHOST";
	var properties = new PropertyInfo[]();
	var storeEnumAsString = true;
	var testResult = Arrays.CreateTable(tableName, properties, storeEnumAsString);
	});
}

[TestMethod]
public void Test_CreateTable_TypeStoreEnumAsString()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var storeEnumAsString = true;
	var testResult = Arrays.CreateTable(type, storeEnumAsString);
	});
}

[TestMethod]
public void Test_GetMapping_FromTo()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var from = new IList<string>();
	var to = new IList<string>();
	var testResult = Arrays.GetMapping(from, to);
	});
}

}

[TestClass]
public class ExtensionsTest
{
[TestMethod]
public void Test_Process_CommandsTextOptions()
{
	var commands = new IEnumerable<string>();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = Extensions.Process(commands, text, options);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_UnTabify_TextTabSize()
{
	var text = "LOCALHOST";
	var tabSize = -1;
	var testResult = Extensions.UnTabify(text, tabSize);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Tabify_TextTabSize()
{
	var text = "LOCALHOST";
	var tabSize = -1;
	var testResult = Extensions.Tabify(text, tabSize);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_PreProcess_TextMacroTokenCommentCleanUp()
{
	var text = "LOCALHOST";
	var macroToken = "LOCALHOST";
	var comment = "LOCALHOST";
	var cleanUp = true;
	var testResult = Extensions.PreProcess(text, macroToken, comment, cleanUp);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ConvertToNestedLists_LinesIndenting()
{
	var lines = (string[])null;
	var indenting = "LOCALHOST";
	var testResult = Extensions.ConvertToNestedLists(lines, indenting);
	// Extensions.ConvertToNestedLists
	// Object reference not set to an instance of an object.
}

}

[TestClass]
public class DoMatchesTest
{
[TestMethod]
public void Test_get_Pattern()
{
	var testObject = new DoMatches();
	var testResult = testObject.get_Pattern();
}

[TestMethod]
public void Test_set_Pattern_Value()
{
	var testObject = new DoMatches();
	var value = "LOCALHOST";
	testObject.set_Pattern(value);
}

[TestMethod]
public void Test_get_Commands()
{
	var testObject = new DoMatches();
	var testResult = testObject.get_Commands();
	Assert.AreEqual(-1, testResult.Capacity);
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new DoMatches();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class EventArgs1Test
{
}

[TestClass]
public class ExceptionsTest
{
[TestMethod]
public void Test_FullText_Ex()
{
	var ex = new Exception();
	var testResult = Exceptions.FullText(ex);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_SendErrorNotification_ExSubject()
{
	var ex = new Exception();
	var subject = "LOCALHOST";
	Exceptions.SendErrorNotification(ex, subject);
}

[TestMethod]
public void Test_SendErrorNotification_ExSubjectSmtpServerRecipients()
{
	var ex = new Exception();
	var subject = "LOCALHOST";
	var smtpServer = "LOCALHOST";
	var recipients = "LOCALHOST";
	Exceptions.SendErrorNotification(ex, subject, smtpServer, recipients);
}

[TestMethod]
public void Test_SendErrorNotification_Ex()
{
	var ex = new Exception();
	Exceptions.SendErrorNotification(ex);
}

}

[TestClass]
public class RegexTextReaderTest
{
[TestMethod]
public void Test_get_Patterns()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.get_Patterns();
	Assert.AreEqual(-1, testResult.Capacity);
	Assert.AreEqual(-1, testResult.Count);
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Close()
{
	var testObject = new RegexTextReader();
	testObject.Close();
}

[TestMethod]
public void Test_get_Depth()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.get_Depth();
}

[TestMethod]
public void Test_GetSchemaTable()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.GetSchemaTable();
	// Collection
}

[TestMethod]
public void Test_get_IsClosed()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.get_IsClosed();
}

[TestMethod]
public void Test_NextResult()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.NextResult();
}

[TestMethod]
public void Test_Read()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.Read();
}

[TestMethod]
public void Test_get_FieldCount()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.get_FieldCount();
}

[TestMethod]
public void Test_GetBoolean_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetBoolean(i);
}

[TestMethod]
public void Test_GetByte_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetByte(i);
}

[TestMethod]
public void Test_GetBytes_IFieldOffsetBufferBufferoffsetLength()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var fieldOffset = -1L;
	var buffer = (byte[])null;
	var bufferoffset = -1;
	var length = -1;
	var testResult = testObject.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
}

[TestMethod]
public void Test_GetChar_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetChar(i);
}

[TestMethod]
public void Test_GetChars_IFieldOffsetBufferBufferoffsetLength()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var fieldOffset = -1L;
	var buffer = new Char[]();
	var bufferoffset = -1;
	var length = -1;
	var testResult = testObject.GetChars(i, fieldOffset, buffer, bufferoffset, length);
}

[TestMethod]
public void Test_GetData_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetData(i);
}

[TestMethod]
public void Test_GetDataTypeName_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetDataTypeName(i);
}

[TestMethod]
public void Test_GetDateTime_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetDateTime(i);
}

[TestMethod]
public void Test_GetDecimal_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetDecimal(i);
}

[TestMethod]
public void Test_GetDouble_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetDouble(i);
}

[TestMethod]
public void Test_GetFieldType_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetFieldType(i);
}

[TestMethod]
public void Test_GetFloat_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetFloat(i);
}

[TestMethod]
public void Test_GetGuid_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetGuid(i);
}

[TestMethod]
public void Test_GetInt16_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetInt16(i);
}

[TestMethod]
public void Test_GetInt32_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetInt32(i);
}

[TestMethod]
public void Test_GetInt64_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetInt64(i);
}

[TestMethod]
public void Test_GetName_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetName(i);
}

[TestMethod]
public void Test_GetOrdinal_Name()
{
	var testObject = new RegexTextReader();
	var name = "LOCALHOST";
	var testResult = testObject.GetOrdinal(name);
}

[TestMethod]
public void Test_GetString_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetString(i);
}

[TestMethod]
public void Test_GetValue_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.GetValue(i);
	// Collection
}

[TestMethod]
public void Test_GetValues_Values()
{
	var testObject = new RegexTextReader();
	var values = (object[])null;
	var testResult = testObject.GetValues(values);
}

[TestMethod]
public void Test_IsDBNull_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.IsDBNull(i);
}

[TestMethod]
public void Test_get_Item_Name()
{
	var testObject = new RegexTextReader();
	var name = "LOCALHOST";
	var testResult = testObject.get_Item(name);
	// Collection
}

[TestMethod]
public void Test_get_Item_I()
{
	var testObject = new RegexTextReader();
	var i = -1;
	var testResult = testObject.get_Item(i);
	// Collection
}

[TestMethod]
public void Test_get_RecordsAffected()
{
	var testObject = new RegexTextReader();
	var testResult = testObject.get_RecordsAffected();
}

[TestMethod]
public void Test_Dispose()
{
	var testObject = new RegexTextReader();
	testObject.Dispose();
}

}

[TestClass]
public class ValidateTest
{
[TestMethod]
public void Test_IsDateTime_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsDateTime(value);
	// Collection
}

[TestMethod]
public void Test_IsDecimal_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsDecimal(value);
	// Collection
}

[TestMethod]
public void Test_IsFloat_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsFloat(value);
	// Collection
}

[TestMethod]
public void Test_IsDouble_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsDouble(value);
	// Collection
}

[TestMethod]
public void Test_IsInt32_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsInt32(value);
	// Collection
}

[TestMethod]
public void Test_IsEmail_Email()
{
	var email = "LOCALHOST";
	var testResult = Validate.IsEmail(email);
	// Collection
}

[TestMethod]
public void Test_IsUrl_Url()
{
	var url = "LOCALHOST";
	var testResult = Validate.IsUrl(url);
	// Collection
}

[TestMethod]
public void Test_IsDbObjectName_Value()
{
	var value = "LOCALHOST";
	var testResult = Validate.IsDbObjectName(value);
	// Collection
}

[TestMethod]
public void Test_IsSafeText_Text()
{
	var text = "LOCALHOST";
	var testResult = Validate.IsSafeText(text);
	// Collection
}

[TestMethod]
public void Test_IsValidSqlTypeMapping_TypeTargetSqlType()
{
	AssertUtils.RaisesException(typeof(ArgumentException), () => {
	var type = "LOCALHOST";
	var targetSqlType = "LOCALHOST";
	var testResult = Validate.IsValidSqlTypeMapping(type, targetSqlType);
	});
}

}

[TestClass]
public class DelimitedDataReaderTest
{
[TestMethod]
public void Test_GuessOptions_PathSampleRowNum()
{
	var path = "LOCALHOST";
	var sampleRowNum = -1;
	var testResult = DelimitedDataReader.GuessOptions(path, sampleRowNum);
	// DelimitedDataReader.GuessOptions
	// Index was outside the bounds of the array.
}

[TestMethod]
public void Test_GuessOptions_PathSampleRowNumSkipRows()
{
	var path = "LOCALHOST";
	var sampleRowNum = -1;
	var skipRows = -1;
	var testResult = DelimitedDataReader.GuessOptions(path, sampleRowNum, skipRows);
	// DelimitedDataReader.GuessOptions
	// Index was outside the bounds of the array.
}

[TestMethod]
public void Test_GuessOptions_StreamSampleRowNumSkipRows()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var sampleRowNum = -1;
	var skipRows = -1;
	var testResult = DelimitedDataReader.GuessOptions(stream, sampleRowNum, skipRows);
	});
}

[TestMethod]
public void Test_GuessOptions_ReaderSampleRowNumSkipRowsTrimWhiteSpaceInferDateFormat()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var sampleRowNum = -1;
	var skipRows = -1;
	var trimWhiteSpace = true;
	var inferDateFormat = true;
	var testResult = DelimitedDataReader.GuessOptions(reader, sampleRowNum, skipRows, trimWhiteSpace, inferDateFormat);
	});
}

[TestMethod]
public void Test_InferColumns_ReaderOptions()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var options = new Options();
	DelimitedDataReader.InferColumns(reader, options);
	});
}

	// Value cannot be null.
	// Value cannot be null.
}

[TestClass]
public class TypesTest
{
[TestMethod]
public void Test_GetTypeInformation_Type()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var testResult = Types.GetTypeInformation(type);
	});
}

[TestMethod]
public void Test_GetTypeTitle_Type()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var testResult = Types.GetTypeTitle(type);
	});
}

[TestMethod]
public void Test_FindType_TypeNameFolder()
{
	var typeName = "LOCALHOST";
	var folder = "LOCALHOST";
	var testResult = Types.FindType(typeName, folder);
	// Types.FindType
	// The directory name is invalid.

}

[TestMethod]
public void Test_FindType_TypeName()
{
	var typeName = "LOCALHOST";
	var testResult = Types.FindType(typeName);
}

[TestMethod]
public void Test_GetMetaData_Type()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var testResult = Types.GetMetaData(type);
	});
}

}

[TestClass]
public class TitleAttributeTest
{
}

[TestClass]
public class InformationAttributeTest
{
}

[TestClass]
public class MetaDataAttributeTest
{
[TestMethod]
public void Test_get_Title()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_Title();
}

[TestMethod]
public void Test_set_Title_Value()
{
	var testObject = new MetaDataAttribute();
	var value = "LOCALHOST";
	testObject.set_Title(value);
}

[TestMethod]
public void Test_get_Details()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_Details();
}

[TestMethod]
public void Test_set_Details_Value()
{
	var testObject = new MetaDataAttribute();
	var value = "LOCALHOST";
	testObject.set_Details(value);
}

[TestMethod]
public void Test_get_IconName()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_IconName();
}

[TestMethod]
public void Test_set_IconName_Value()
{
	var testObject = new MetaDataAttribute();
	var value = "LOCALHOST";
	testObject.set_IconName(value);
}

[TestMethod]
public void Test_get_Help()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_Help();
}

[TestMethod]
public void Test_set_Help_Value()
{
	var testObject = new MetaDataAttribute();
	var value = "LOCALHOST";
	testObject.set_Help(value);
}

[TestMethod]
public void Test_get_Url()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_Url();
}

[TestMethod]
public void Test_set_Url_Value()
{
	var testObject = new MetaDataAttribute();
	var value = "LOCALHOST";
	testObject.set_Url(value);
}

[TestMethod]
public void Test_get_TypeId()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.get_TypeId();
	// Collection
}

[TestMethod]
public void Test_Match_Obj()
{
	var testObject = new MetaDataAttribute();
	var obj = new Object();
	var testResult = testObject.Match(obj);
}

[TestMethod]
public void Test_IsDefaultAttribute()
{
	var testObject = new MetaDataAttribute();
	var testResult = testObject.IsDefaultAttribute();
}

}

[TestClass]
public class ObjectsTest
{
[TestMethod]
public void Test_ConvertToClrValue_TypeValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var value = new Object();
	var testResult = Objects.ConvertToClrValue(type, value);
	});
}

[TestMethod]
public void Test_ConvertDbValue_TypeValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var value = new Object();
	var testResult = Objects.ConvertDbValue(type, value);
	});
}

[TestMethod]
public void Test_GetProperties_Item()
{
	var item = new Object();
	var testResult = Objects.GetProperties(item);
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_GetPropertyValue_ItemProperty()
{
	var item = new Object();
	var property = "LOCALHOST";
	var testResult = Objects.GetPropertyValue(item, property);
}

[TestMethod]
public void Test_SetProperties_ItemValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var item = new Object();
	var values = new IDictionary();
	Objects.SetProperties(item, values);
	});
}

[TestMethod]
public void Test_SetProperties_ItemValuesMapping()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var item = new Object();
	var values = new IDictionary();
	var mapping = new IDictionary<string, object>();
	Objects.SetProperties(item, values, mapping);
	});
}

[TestMethod]
public void Test_SetProperties_ItemValues()
{
	var item = new Object();
	var values = "LOCALHOST";
	Objects.SetProperties(item, values);
}

[TestMethod]
public void Test_SetProperties_ItemRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var item = new Object();
	var record = new IDataRecord();
	Objects.SetProperties(item, record);
	});
}

[TestMethod]
public void Test_SetProperties_ItemRow()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var item = new Object();
	var row = new DataRow();
	Objects.SetProperties(item, row);
	});
}

[TestMethod]
public void Test_XmlSerialize_Item()
{
	var item = new Object();
	var testResult = Objects.XmlSerialize(item);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

	// Value cannot be null.
[TestMethod]
public void Test_XmlDeserialize_TypeXmlString()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var xmlString = "LOCALHOST";
	var testResult = Objects.XmlDeserialize(type, xmlString);
	});
}

[TestMethod]
public void Test_XmlDeserialize_XmlStringTypes()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var xmlString = "LOCALHOST";
	var types = new Type[]();
	var testResult = Objects.XmlDeserialize(xmlString, types);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_Create_TypeName()
{
	var typeName = "LOCALHOST";
	var testResult = Objects.Create(typeName);
	// Objects.Create
	// The invoked member is not supported in a dynamic assembly.
}

[TestMethod]
public void Test_Create_AssemblyNameTypeName()
{
	var assemblyName = "LOCALHOST";
	var typeName = "LOCALHOST";
	var testResult = Objects.Create(assemblyName, typeName);
	// Objects.Create
	// Could not load file or assembly 'LOCALHOST' or one of its dependencies. The system cannot find the file specified.
}

[TestMethod]
public void Test_GetTypes_BaseType()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var baseType = new Type();
	var testResult = Objects.GetTypes(baseType);
	});
}

[TestMethod]
public void Test_GetTypes_FolderPathBaseType()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var folderPath = "LOCALHOST";
	var baseType = new Type();
	var testResult = Objects.GetTypes(folderPath, baseType);
	});
}

[TestMethod]
public void Test_SetExtendedProperty_ItemKeyValue()
{
	var item = new Object();
	var key = "LOCALHOST";
	var value = new Object();
	Objects.SetExtendedProperty(item, key, value);
}

[TestMethod]
public void Test_GetExtendedProperty_ItemKey()
{
	var item = new Object();
	var key = "LOCALHOST";
	var testResult = Objects.GetExtendedProperty(item, key);
}

}

[TestClass]
public class UnTabifyTest
{
[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new UnTabify();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class OptionsTest
{
}

[TestClass]
public class ReadErrorOptionsTest
{
}

[TestClass]
public class StringsTest
{
[TestMethod]
public void Test_Split_TextDelimiters()
{
	var text = "LOCALHOST";
	var delimiters = (string[])null;
	var testResult = Strings.Split(text, delimiters);
	Assert.IsInstanceOfType(testResult, typeof(String[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

	// Value cannot be null.
[TestMethod]
public void Test_Left_TextDelimiter()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var testResult = Strings.Left(text, delimiter);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Left_TextIndex()
{
	var text = "LOCALHOST";
	var index = -1;
	var testResult = Strings.Left(text, index);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_LastLeft_TextDelimiter()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var testResult = Strings.LastLeft(text, delimiter);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Right_TextDelimiter()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var testResult = Strings.Right(text, delimiter);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_LastRight_TextDelimiter()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var testResult = Strings.LastRight(text, delimiter);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Right_TextIndex()
{
	var text = "LOCALHOST";
	var index = -1;
	var testResult = Strings.Right(text, index);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Divide_TextDelimiterLeftRight()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var left = "LOCALHOST";
	var right = "LOCALHOST";
	Strings.Divide(text, delimiter, left, right);
}

[TestMethod]
public void Test_Divide_TextDelimiter()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var testResult = Strings.Divide(text, delimiter);
	// Collection
}

[TestMethod]
public void Test_LastDivide_TextDelimiterLeftRight()
{
	var text = "LOCALHOST";
	var delimiter = "LOCALHOST";
	var left = "LOCALHOST";
	var right = "LOCALHOST";
	Strings.LastDivide(text, delimiter, left, right);
}

[TestMethod]
public void Test_NullIfEmptyOrWhitespace_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.NullIfEmptyOrWhitespace(text);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionary()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary<string, object>();
	var testResult = Strings.Replace(text, dictionary);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionary()
{
	var text = "LOCALHOST";
	var dictionary = new Dictionary<string,object>();
	var testResult = Strings.Replace(text, dictionary);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryPrefixSuffix()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary<string, object>();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Strings.Replace(text, dictionary, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryPrefixSuffix()
{
	var text = "LOCALHOST";
	var dictionary = new Dictionary<string,object>();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Strings.Replace(text, dictionary, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryPrefixSuffixComparison()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary<string, object>();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Strings.Replace(text, dictionary, prefix, suffix, comparison);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryPrefixSuffixComparison()
{
	var text = "LOCALHOST";
	var dictionary = new Dictionary<string,object>();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Strings.Replace(text, dictionary, prefix, suffix, comparison);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryComparison()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary<string, object>();
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Strings.Replace(text, dictionary, comparison);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionaryComparison()
{
	var text = "LOCALHOST";
	var dictionary = new Dictionary<string,object>();
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Strings.Replace(text, dictionary, comparison);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextObj()
{
	var text = "LOCALHOST";
	var obj = new Object();
	var testResult = Strings.Replace(text, obj);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextObjPrefixSuffix()
{
	var text = "LOCALHOST";
	var obj = new Object();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Strings.Replace(text, obj, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextCollectionPrefixSuffix()
{
	var text = "LOCALHOST";
	var collection = new NameValueCollection();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Strings.Replace(text, collection, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextFindReplaceComparison()
{
	var text = "LOCALHOST";
	var find = "LOCALHOST";
	var replace = "LOCALHOST";
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var testResult = Strings.Replace(text, find, replace, comparison);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDataRemoveUnresolvedTokens()
{
	var text = "LOCALHOST";
	var data = new DataTable("TestTable").DataSet;
	var removeUnresolvedTokens = true;
	var testResult = Strings.Replace(text, data, removeUnresolvedTokens);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ReadLines_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.ReadLines(text);
	Assert.IsInstanceOfType(testResult, typeof(<ReadLines>d__d));
}

[TestMethod]
public void Test_ToLines_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.ToLines(text);
	Assert.IsInstanceOfType(testResult, typeof(String[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

[TestMethod]
public void Test_Escape_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.Escape(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_UnEscape_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.UnEscape(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_EncodeXml_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.EncodeXml(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_DecodeXml_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.DecodeXml(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_EncodeRequestParameter_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.EncodeRequestParameter(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_DecodeRequestParameter_Input()
{
	var input = "LOCALHOST";
	var testResult = Strings.DecodeRequestParameter(input);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_TitleCase_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.TitleCase(text);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_PascalCase_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.PascalCase(text);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_InsertSpacers_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.InsertSpacers(text);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_RegexReplace_TextPatternReplace()
{
	var text = "LOCALHOST";
	var pattern = "LOCALHOST";
	var replace = "LOCALHOST";
	var testResult = Strings.RegexReplace(text, pattern, replace);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Values_TextValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var text = "LOCALHOST";
	var values = (object[])null;
	var testResult = Strings.Values(text, values);
	});
}

[TestMethod]
public void Test_IsEmpty_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.IsEmpty(text);
	// Collection
}

[TestMethod]
public void Test_IsWhiteSpace_Text()
{
	var text = "LOCALHOST";
	var testResult = Strings.IsWhiteSpace(text);
	// Collection
}

[TestMethod]
public void Test_IsWhiteSpace_Text()
{
	var text = new StringBuilder();
	var testResult = Strings.IsWhiteSpace(text);
	// Collection
}

[TestMethod]
public void Test_IsIn_ValueValues()
{
	var value = "LOCALHOST";
	var values = (string[])null;
	var testResult = Strings.IsIn(value, values);
	// Collection
}

[TestMethod]
public void Test_IsIn_ValueComparisonValues()
{
	var value = "LOCALHOST";
	var comparison = StringComparison.InvariantCultureIgnoreCase;
	var values = (string[])null;
	var testResult = Strings.IsIn(value, comparison, values);
	// Collection
}

[TestMethod]
public void Test_ToStringValue_SecureString()
{
	var secureString = new SecureString();
	var testResult = Strings.ToStringValue(secureString);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Repeat_SourceCount()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var source = "LOCALHOST";
	var count = -1;
	var testResult = Strings.Repeat(source, count);
	});
}

[TestMethod]
public void Test_ReadText_Data()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var data = (byte[])null;
	var testResult = Strings.ReadText(data);
	});
}

[TestMethod]
public void Test_ToInt32_TextDefaultValue()
{
	var text = "LOCALHOST";
	var defaultValue = -1;
	var testResult = Strings.ToInt32(text, defaultValue);
	// Collection
}

[TestMethod]
public void Test_ToNullableInt_TextDefaultValue()
{
	var text = "LOCALHOST";
	var defaultValue = ;
	var testResult = Strings.ToNullableInt(text, defaultValue);
}

[TestMethod]
public void Test_ToDecimal_TextDefaultValue()
{
	var text = "LOCALHOST";
	var defaultValue = ;
	var testResult = Strings.ToDecimal(text, defaultValue);
}

[TestMethod]
public void Test_ToDateTime_TextDefaultValue()
{
	var text = "LOCALHOST";
	var defaultValue = ;
	var testResult = Strings.ToDateTime(text, defaultValue);
}

[TestMethod]
public void Test_GetLineNumber_TextIndexLineBreak()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var text = "LOCALHOST";
	var index = -1;
	var lineBreak = 'a';
	var testResult = Strings.GetLineNumber(text, index, lineBreak);
	});
}

[TestMethod]
public void Test_EditDistance_SourceTargetCaseInsensitive()
{
	var source = "LOCALHOST";
	var target = "LOCALHOST";
	var caseInsensitive = true;
	var testResult = Strings.EditDistance(source, target, caseInsensitive);
	// Collection
}

[TestMethod]
public void Test_Join_SeparatorItems()
{
	var separator = "LOCALHOST";
	var items = new IEnumerable();
	var testResult = Strings.Join(separator, items);
}

}

[TestClass]
public class DivideResultTest
{
}

[TestClass]
public class StringsTest
{
[TestMethod]
public void Test_Replace_TextDictionaryPrefixSuffix()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary();
	var prefix = "LOCALHOST";
	var suffix = "LOCALHOST";
	var testResult = Strings.Replace(text, dictionary, prefix, suffix);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Replace_TextDictionary()
{
	var text = "LOCALHOST";
	var dictionary = new IDictionary();
	var testResult = Strings.Replace(text, dictionary);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}

[TestClass]
public class ScriptEngineTest
{
[TestMethod]
public void Test_get_Output()
{
	var testObject = new ScriptEngine();
	var testResult = testObject.get_Output();
}

[TestMethod]
public void Test_set_Output_Value()
{
	var testObject = new ScriptEngine();
	var value = new TextWriter();
	testObject.set_Output(value);
}

[TestMethod]
public void Test_Compile_Script()
{
	var testObject = new ScriptEngine();
	var script = "LOCALHOST";
	testObject.Compile(script);
}

[TestMethod]
public void Test_Execute()
{
	var testObject = new ScriptEngine();
	var testResult = testObject.Execute();
	// Collection
}

[TestMethod]
public void Test_Execute_Script()
{
	var testObject = new ScriptEngine();
	var script = "LOCALHOST";
	var testResult = testObject.Execute(script);
	// Collection
}

[TestMethod]
public void Test_Execute_ScriptVariables()
{
	var testObject = new ScriptEngine();
	var script = "LOCALHOST";
	var variables = new Dictionary<string,object>();
	var testResult = testObject.Execute(script, variables);
	// Collection
}

[TestMethod]
public void Test_write_Arg()
{
	var testObject = new ScriptEngine();
	var arg = new Object();
	testObject.write(arg);
}

[TestMethod]
public void Test_writeline_Arg()
{
	var testObject = new ScriptEngine();
	var arg = new Object();
	testObject.writeline(arg);
}

[TestMethod]
public void Test_Throw_Error()
{
	var testObject = new ScriptEngine();
	var error = "LOCALHOST";
	testObject.Throw(error);
}

}

[TestClass]
public class SyntaxErrorTest
{
}

[TestClass]
public class ParseTest
{
[TestMethod]
public void Test_QueryString_Text()
{
	var text = "LOCALHOST";
	var testResult = Parse.QueryString(text);
	Assert.AreEqual(-1, testResult.Count);
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ConnectionString_Text()
{
	var text = "LOCALHOST";
	var testResult = Parse.ConnectionString(text);
	Assert.AreEqual(-1, testResult.Count);
	// Parameter count mismatch.
}

	// Value cannot be null.
}

[TestClass]
public class ServiceProxy1Test
{
[TestMethod]
public void Test_get_Client()
{
	var testObject = new ServiceProxy<string>();
	var testResult = testObject.get_Client();
}

[TestMethod]
public void Test_get_FactoryState()
{
	var testObject = new ServiceProxy<string>();
	var testResult = testObject.get_FactoryState();
}

[TestMethod]
public void Test_get_ClientChannel()
{
	var testObject = new ServiceProxy<string>();
	var testResult = testObject.get_ClientChannel();
}

[TestMethod]
public void Test_Dispose()
{
	var testObject = new ServiceProxy<string>();
	testObject.Dispose();
}

}

[TestClass]
public class ExpressionBuilderConstantsTest
{
}

[TestClass]
public class ExpressionValidationModeTest
{
}

[TestClass]
public class ArgumentListTest
{
[TestMethod]
public void Test_Apply_Target()
{
	var target = new Object();
	ArgumentList.Apply(target);
}

}

[TestClass]
public class OrmHelperTest
{
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
}

[TestClass]
public class ThreadedServiceHost2Test
{
}

[TestClass]
public class ParameterTest
{
[TestMethod]
public void Test_get_Name()
{
	var testObject = new Parameter();
	var testResult = testObject.get_Name();
}

[TestMethod]
public void Test_set_Name_Value()
{
	var testObject = new Parameter();
	var value = "LOCALHOST";
	testObject.set_Name(value);
}

[TestMethod]
public void Test_get_Value()
{
	var testObject = new Parameter();
	var testResult = testObject.get_Value();
	// Collection
}

[TestMethod]
public void Test_set_Value_Value()
{
	var testObject = new Parameter();
	var value = new Object();
	testObject.set_Value(value);
}

}

[TestClass]
public class TabifyTest
{
[TestMethod]
public void Test_get_TabSize()
{
	var testObject = new Tabify();
	var testResult = testObject.get_TabSize();
}

[TestMethod]
public void Test_set_TabSize_Value()
{
	var testObject = new Tabify();
	var value = -1;
	testObject.set_TabSize(value);
}

[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new Tabify();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class SqlHelperTest
{
[TestMethod]
public void Test_SqlTypeName_Type()
{
	var type = new Type();
	var testResult = SqlHelper.SqlTypeName(type);
}

[TestMethod]
public void Test_InferParameters_CommandText()
{
	var commandText = "LOCALHOST";
	var testResult = SqlHelper.InferParameters(commandText);
	Assert.IsInstanceOfType(testResult, typeof(String[]));
	Assert.AreEqual(-1, testResult.Length);
	Assert.AreEqual(-1L, testResult.LongLength);
	Assert.AreEqual(-1, testResult.Rank);
	Assert.AreEqual(true, testResult.IsReadOnly);
	Assert.AreEqual(true, testResult.IsFixedSize);
	Assert.AreEqual(true, testResult.IsSynchronized);
}

}

[TestClass]
public class MacroExpanderTest
{
[TestMethod]
public void Test_get_CurrentToken()
{
	var testObject = new MacroExpander();
	var testResult = testObject.get_CurrentToken();
}

[TestMethod]
public void Test_get_NextToken()
{
	var testObject = new MacroExpander();
	var testResult = testObject.get_NextToken();
}

[TestMethod]
public void Test_get_Macros()
{
	var testObject = new MacroExpander();
	var testResult = testObject.get_Macros();
	Assert.AreEqual(-1, testResult.Capacity);
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_ExpandMacros_Source()
{
	var testObject = new MacroExpander();
	var source = "LOCALHOST";
	var testResult = testObject.ExpandMacros(source);
}

[TestMethod]
public void Test_GetToken()
{
	var testObject = new MacroExpander();
	var testResult = testObject.GetToken();
}

}

[TestClass]
public class MacroTest
{
[TestMethod]
public void Test_get_Token()
{
	var testObject = new Macro();
	var testResult = testObject.get_Token();
}

[TestMethod]
public void Test_set_Token_Value()
{
	var testObject = new Macro();
	var value = "LOCALHOST";
	testObject.set_Token(value);
}

[TestMethod]
public void Test_get_ExpandsTo()
{
	var testObject = new Macro();
	var testResult = testObject.get_ExpandsTo();
}

[TestMethod]
public void Test_set_ExpandsTo_Value()
{
	var testObject = new Macro();
	var value = "LOCALHOST";
	testObject.set_ExpandsTo(value);
}

[TestMethod]
public void Test_get_ParameterCount()
{
	var testObject = new Macro();
	var testResult = testObject.get_ParameterCount();
}

[TestMethod]
public void Test_set_ParameterCount_Value()
{
	var testObject = new Macro();
	var value = -1;
	testObject.set_ParameterCount(value);
}

[TestMethod]
public void Test_get_Group()
{
	var testObject = new Macro();
	var testResult = testObject.get_Group();
}

[TestMethod]
public void Test_set_Group_Value()
{
	var testObject = new Macro();
	var value = "LOCALHOST";
	testObject.set_Group(value);
}

[TestMethod]
public void Test_get_DisplayText()
{
	var testObject = new Macro();
	var testResult = testObject.get_DisplayText();
}

[TestMethod]
public void Test_set_DisplayText_Value()
{
	var testObject = new Macro();
	var value = "LOCALHOST";
	testObject.set_DisplayText(value);
}

[TestMethod]
public void Test_get_Path()
{
	var testObject = new Macro();
	var testResult = testObject.get_Path();
}

}

[TestClass]
public class EvaluatorTest
{
[TestMethod]
public void Test_Eval_Expression()
{
	var expression = "LOCALHOST";
	var testResult = Evaluator.Eval(expression);
	// Evaluator.Eval
	// Object reference not set to an instance of an object.
}

[TestMethod]
public void Test_Eval_ExpressionValues()
{
	var expression = "LOCALHOST";
	var values = new IDictionary();
	var testResult = Evaluator.Eval(expression, values);
	// Evaluator.Eval
	// Object reference not set to an instance of an object.
}

[TestMethod]
public void Test_Compile_Expression()
{
	var expression = "LOCALHOST";
	var testResult = Evaluator.Compile(expression);
	// Collection
}

}

[TestClass]
public class OperationTest
{
}

[TestClass]
public class TextEncoderTest
{
[TestMethod]
public void Test_Encode_Value()
{
	var value = new Object();
	var testResult = TextEncoder.Encode(value);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Encode_ValueUseMime()
{
	var value = new Object();
	var useMime = true;
	var testResult = TextEncoder.Encode(value, useMime);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_Decode_TypeText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var text = "LOCALHOST";
	var testResult = TextEncoder.Decode(type, text);
	});
}

[TestMethod]
public void Test_Decode_TypeTextPreserveEmpty()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var text = "LOCALHOST";
	var preserveEmpty = true;
	var testResult = TextEncoder.Decode(type, text, preserveEmpty);
	});
}

	// Value cannot be null.
}

[TestClass]
public class DbHelperTest
{
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteBatch_ConnectionSqlScriptSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var sqlScript = "LOCALHOST";
	var separators = (string[])null;
	DbHelper.ExecuteBatch(connection, sqlScript, separators);
	});
}

[TestMethod]
public void Test_ExecuteBatch_ConnectionSqlScriptCommandTimeoutSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var sqlScript = "LOCALHOST";
	var commandTimeout = -1;
	var separators = (string[])null;
	DbHelper.ExecuteBatch(connection, sqlScript, commandTimeout, separators);
	});
}

[TestMethod]
public void Test_ExecuteFile_ConnectionPath()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var path = "LOCALHOST";
	DbHelper.ExecuteFile(connection, path);
	});
}

[TestMethod]
public void Test_ExecuteFile_ConnectionPathCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var path = "LOCALHOST";
	var commandTimeout = -1;
	DbHelper.ExecuteFile(connection, path, commandTimeout);
	});
}

[TestMethod]
public void Test_SetValue_ParamValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var param = new IDataParameter();
	var value = new Object();
	DbHelper.SetValue(param, value);
	});
}

[TestMethod]
public void Test_CreateCommand_ConnectionCommandTypeCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.CreateCommand(connection, commandType, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_CreateCommand_ConnectionCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.CreateCommand(connection, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_CreateCommand_ConnectionCommandTypeCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var testResult = DbHelper.CreateCommand(connection, commandType, commandText);
	});
}

[TestMethod]
public void Test_CreateCommand_ConnectionCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var testResult = DbHelper.CreateCommand(connection, commandText);
	});
}

[TestMethod]
public void Test_GetDataAdapter_Command()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var testResult = DbHelper.GetDataAdapter(command);
	});
}

[TestMethod]
public void Test_GetTableSchema_ConnectionTableName()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var tableName = "LOCALHOST";
	var testResult = DbHelper.GetTableSchema(connection, tableName);
	});
}

[TestMethod]
public void Test_GetDbType_Value()
{
	var value = new Object();
	var testResult = DbHelper.GetDbType(value);
	// Collection
}

[TestMethod]
public void Test_GetDbType_Type()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var type = new Type();
	var testResult = DbHelper.GetDbType(type);
	});
}

[TestMethod]
public void Test_QuoteName_Name()
{
	var name = "LOCALHOST";
	var testResult = DbHelper.QuoteName(name);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_QuoteName_NameOpeningQuoteClosingQuote()
{
	var name = "LOCALHOST";
	var openingQuote = "LOCALHOST";
	var closingQuote = "LOCALHOST";
	var testResult = DbHelper.QuoteName(name, openingQuote, closingQuote);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_SqlIdentifier_Text()
{
	var text = "LOCALHOST";
	var testResult = DbHelper.SqlIdentifier(text);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_GetConfigConnection_Name()
{
	AssertUtils.RaisesException(typeof(ArgumentOutOfRangeException), () => {
	var name = "LOCALHOST";
	var testResult = DbHelper.GetConfigConnection(name);
	});
}

[TestMethod]
public void Test_TestConnection_Connection()
{
	var connection = new IDbConnection();
	var testResult = DbHelper.TestConnection(connection);
	// Collection
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_InferParameters_Command()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new DbCommand();
	DbHelper.InferParameters(command);
	});
}

[TestMethod]
public void Test_BuildBoolean_VariableInputWhereClauseOptions()
{
	var variable = "LOCALHOST";
	var input = "LOCALHOST";
	var whereClause = "LOCALHOST";
	var options = new BuildBooleanOptions();
	var testResult = DbHelper.BuildBoolean(variable, input, whereClause, options);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ConvertToRange_Integers()
{
	var integers = (int[])null;
	var testResult = DbHelper.ConvertToRange(integers);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ConvertToRange_Integers()
{
	var integers = "LOCALHOST";
	var testResult = DbHelper.ConvertToRange(integers);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_SuggestType_ColumnSampleSize()
{
	var column = new DataColumn();
	var sampleSize = -1;
	var testResult = DbHelper.SuggestType(column, sampleSize);
	// DbHelper.SuggestType
	// Object reference not set to an instance of an object.
}

[TestMethod]
public void Test_SuggestType_ValuesSampleSize()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var values = new IEnumerable<string>();
	var sampleSize = -1;
	var testResult = DbHelper.SuggestType(values, sampleSize);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTypeCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteDataSet(connection, commandType, commandText);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTypeCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteDataSet(connection, commandType, commandText, commandTimeout);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTypeCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	DbHelper.ExecuteNonQuery(connection, commandType, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTypeCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	DbHelper.ExecuteNonQuery(connection, commandType, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTypeCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteReader(connection, commandType, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTypeCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteReader(connection, commandType, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTypeCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataSet(connection, commandType, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTypeCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataSet(connection, commandType, commandText, commandTimeout, paramNames, values);
	});
}

	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandTextParameters()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var parameters = new Dictionary<string,object>();
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText, parameters);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTypeCommandTextCommandTimeoutParameters()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var parameters = new Dictionary<string,object>();
	var testResult = DbHelper.ExecuteDataTable(connection, commandType, commandText, commandTimeout, parameters);
	});
}

[TestMethod]
public void Test_GetXml_ConnectionCommandTypeCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.GetXml(connection, commandType, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_GetXml_ConnectionCommandTypeCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.GetXml(connection, commandType, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	DbHelper.ExecuteNonQuery(connection, commandText);
	});
}

[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	DbHelper.ExecuteNonQuery(connection, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteReader(connection, commandText);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteReader(connection, commandText, commandTimeout);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteDataTable(connection, commandText);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteDataTable(connection, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteDataSet(connection, commandText);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteDataSet(connection, commandText, commandTimeout);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	DbHelper.ExecuteNonQuery(connection, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	DbHelper.ExecuteNonQuery(connection, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteReader(connection, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteReader(connection, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataTable(connection, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataTable_ConnectionCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataTable(connection, commandText, commandTimeout, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTextParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataSet(connection, commandText, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_ConnectionCommandTextCommandTimeoutParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataSet(connection, commandText, commandTimeout, paramNames, values);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_AddParameter_CommandNameColumn()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var testResult = DbHelper.AddParameter(command, name, column);
	});
}

[TestMethod]
public void Test_AddParameter_CommandNameColumnValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var value = new Object();
	var testResult = DbHelper.AddParameter(command, name, column, value);
	});
}

[TestMethod]
public void Test_AddParameter_CommandTypeNameColumn()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = ;
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var testResult = DbHelper.AddParameter(command, type, name, column);
	});
}

[TestMethod]
public void Test_AddParameter_CommandTypeNameColumnValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = ;
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var value = new Object();
	var testResult = DbHelper.AddParameter(command, type, name, column, value);
	});
}

[TestMethod]
public void Test_AddParameter_CommandTypeNameColumn()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = new Type();
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var testResult = DbHelper.AddParameter(command, type, name, column);
	});
}

[TestMethod]
public void Test_AddParameter_CommandTypeNameColumnValue()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = new Type();
	var name = "LOCALHOST";
	var column = "LOCALHOST";
	var value = new Object();
	var testResult = DbHelper.AddParameter(command, type, name, column, value);
	});
}

[TestMethod]
public void Test_AddParameter_CommandNameValueDirectionSize()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var name = "LOCALHOST";
	var value = new Object();
	var direction = ;
	var size = -1;
	var testResult = DbHelper.AddParameter(command, name, value, direction, size);
	});
}

[TestMethod]
public void Test_CreateParameters_CommandTablePrefix()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var table = new DataTable("TestTable");
	var prefix = "LOCALHOST";
	DbHelper.CreateParameters(command, table, prefix);
	});
}

[TestMethod]
public void Test_CreateParameters_CommandTypePrefix()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = new Type();
	var prefix = "LOCALHOST";
	DbHelper.CreateParameters(command, type, prefix);
	});
}

[TestMethod]
public void Test_CreateParameters_CommandTypePrefixPropertyNames()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var type = new Type();
	var prefix = "LOCALHOST";
	var propertyNames = "LOCALHOST";
	DbHelper.CreateParameters(command, type, prefix, propertyNames);
	});
}

[TestMethod]
public void Test_CreateParameters_CommandParamNames()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	DbHelper.CreateParameters(command, paramNames);
	});
}

[TestMethod]
public void Test_AddParameters_CommandParamNamesParamValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	var paramValues = (object[])null;
	DbHelper.AddParameters(command, paramNames, paramValues);
	});
}

[TestMethod]
public void Test_AddParameters_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new IDictionary();
	DbHelper.AddParameters(command, record);
	});
}

[TestMethod]
public void Test_AddParameters_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new Dictionary<string,object>();
	DbHelper.AddParameters(command, record);
	});
}

[TestMethod]
public void Test_SetParameters_CommandParamNamesParamValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	var paramValues = (object[])null;
	DbHelper.SetParameters(command, paramNames, paramValues);
	});
}

[TestMethod]
public void Test_SetParameters_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new IDataRecord();
	DbHelper.SetParameters(command, record);
	});
}

[TestMethod]
public void Test_SetParameters_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new DataRow();
	DbHelper.SetParameters(command, record);
	});
}

[TestMethod]
public void Test_SetParameters_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new IDictionary();
	DbHelper.SetParameters(command, record);
	});
}

[TestMethod]
public void Test_SetParameters_CommandItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var item = new Object();
	DbHelper.SetParameters(command, item);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_Command()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var testResult = DbHelper.ExecuteDataTable(command);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_Command()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var testResult = DbHelper.ExecuteDataSet(command);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteReader_CommandParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteReader(command, paramNames, values);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_CommandParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataTable(command, paramNames, values);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_CommandParamNamesValues()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var paramNames = "LOCALHOST";
	var values = (object[])null;
	var testResult = DbHelper.ExecuteDataSet(command, paramNames, values);
	});
}

	// Value cannot be null.
	// Value cannot be null.
[TestMethod]
public void Test_ExecuteReader_CommandItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var item = new Object();
	var testResult = DbHelper.ExecuteReader(command, item);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new Object();
	var testResult = DbHelper.ExecuteDataTable(command, record);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new Object();
	var testResult = DbHelper.ExecuteDataSet(command, record);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteReader_CommandItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var item = new Dictionary<string,object>();
	var testResult = DbHelper.ExecuteReader(command, item);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new Dictionary<string,object>();
	var testResult = DbHelper.ExecuteDataTable(command, record);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new Dictionary<string,object>();
	var testResult = DbHelper.ExecuteDataSet(command, record);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteReader_CommandItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var item = new IDataRecord();
	var testResult = DbHelper.ExecuteReader(command, item);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new IDataRecord();
	var testResult = DbHelper.ExecuteDataTable(command, record);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new IDataRecord();
	var testResult = DbHelper.ExecuteDataSet(command, record);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteReader_CommandItem()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var item = new DataRow();
	var testResult = DbHelper.ExecuteReader(command, item);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteDataTable_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new DataRow();
	var testResult = DbHelper.ExecuteDataTable(command, record);
	});
}

[TestMethod]
public void Test_ExecuteDataSet_CommandRecord()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var command = new IDbCommand();
	var record = new DataRow();
	var testResult = DbHelper.ExecuteDataSet(command, record);
	});
}

	// Value cannot be null.
[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTypeCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	DbHelper.ExecuteNonQuery(connection, commandType, commandText);
	});
}

[TestMethod]
public void Test_ExecuteNonQuery_ConnectionCommandTypeCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	DbHelper.ExecuteNonQuery(connection, commandType, commandText, commandTimeout);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTypeCommandText()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var testResult = DbHelper.ExecuteReader(connection, commandType, commandText);
	});
}

[TestMethod]
public void Test_ExecuteReader_ConnectionCommandTypeCommandTextCommandTimeout()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var connection = new IDbConnection();
	var commandType = CommandType.Text;
	var commandText = "LOCALHOST";
	var commandTimeout = -1;
	var testResult = DbHelper.ExecuteReader(connection, commandType, commandText, commandTimeout);
	});
}

}

[TestClass]
public class BuildBooleanOptionsTest
{
}

[TestClass]
public class IDataValueTest
{
}

[TestClass]
public class IDataListTest
{
}

[TestClass]
public class ISupportsReadOnlyTest
{
}

[TestClass]
public class ReadOnlyModeTest
{
}

[TestClass]
public class FileIOTest
{
[TestMethod]
public void Test_XCopy_FromPathToPathOptions()
{
	var fromPath = "LOCALHOST";
	var toPath = "LOCALHOST";
	var options = ;
	FileIO.XCopy(fromPath, toPath, options);
	// FileIO.XCopy
	// The process cannot access the file 'LOCALHOST' because it is being used by another process.
}

[TestMethod]
public void Test_FolderCopy_FromPathToPathOptions()
{
	AssertUtils.RaisesException(typeof(ArgumentException), () => {
	var fromPath = "LOCALHOST";
	var toPath = "LOCALHOST";
	var options = ;
	FileIO.FolderCopy(fromPath, toPath, options);
	});
}

[TestMethod]
public void Test_FileCopy_FromPathToPathOptions()
{
	var fromPath = "LOCALHOST";
	var toPath = "LOCALHOST";
	var options = ;
	FileIO.FileCopy(fromPath, toPath, options);
	// FileIO.FileCopy
	// The process cannot access the file 'LOCALHOST' because it is being used by another process.
}

[TestMethod]
public void Test_CreateContainingFolder_FilePath()
{
	AssertUtils.RaisesException(typeof(ArgumentException), () => {
	var filePath = "LOCALHOST";
	FileIO.CreateContainingFolder(filePath);
	});
}

[TestMethod]
public void Test_EnsureFolderExists_FolderPath()
{
	var folderPath = "LOCALHOST";
	FileIO.EnsureFolderExists(folderPath);
	// FileIO.EnsureFolderExists
	// Cannot create "C:\Users\kemals\SkyDrive\Projects\Compare\GenerateTests\bin\Debug\LOCALHOST" because a file or directory with the same name already exists.
}

[TestMethod]
public void Test_GetRelativePath_FromPathToPath()
{
	var fromPath = "LOCALHOST";
	var toPath = "LOCALHOST";
	var testResult = FileIO.GetRelativePath(fromPath, toPath);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

[TestMethod]
public void Test_ConcatenateFiles_Paths()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var paths = (string[])null;
	var testResult = FileIO.ConcatenateFiles(paths);
	});
}

[TestMethod]
public void Test_ConcatenateFiles_OutputPathPathsDelimiterReplacements()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var outputPath = "LOCALHOST";
	var paths = (string[])null;
	var delimiter = "LOCALHOST";
	var replacements = new IDictionary<string, object>();
	FileIO.ConcatenateFiles(outputPath, paths, delimiter, replacements);
	});
}

[TestMethod]
public void Test_ConcatenateFiles_OutputPathPaths()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var outputPath = "LOCALHOST";
	var paths = (string[])null;
	FileIO.ConcatenateFiles(outputPath, paths);
	});
}

[TestMethod]
public void Test_DeleteFile_Path()
{
	var path = "LOCALHOST";
	FileIO.DeleteFile(path);
}

[TestMethod]
public void Test_OpenTextReader_Stream()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var testResult = FileIO.OpenTextReader(stream);
	});
}

[TestMethod]
public void Test_OpenTextReader_Data()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var data = (byte[])null;
	var testResult = FileIO.OpenTextReader(data);
	});
}

[TestMethod]
public void Test_OpenTextReader_Path()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var path = "LOCALHOST";
	var testResult = FileIO.OpenTextReader(path);
	});
}

[TestMethod]
public void Test_ReadDelimitedRecords_Reader()
{
	var reader = new TextReader();
	var testResult = FileIO.ReadDelimitedRecords(reader);
	Assert.IsInstanceOfType(testResult, typeof(<ReadDelimitedRecords>d__0));
}

[TestMethod]
public void Test_ReadDelimitedRecord_ReaderColumnSeparatorValueDelimiterNullTokenTrimRowSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var columnSeparator = "LOCALHOST";
	var valueDelimiter = "LOCALHOST";
	var nullToken = "LOCALHOST";
	var trim = true;
	var rowSeparators = (string[])null;
	var testResult = FileIO.ReadDelimitedRecord(reader, columnSeparator, valueDelimiter, nullToken, trim, rowSeparators);
	});
}

[TestMethod]
public void Test_ReadDelimitedRecord_ReaderColumnSeparatorValueDelimiter()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var columnSeparator = "LOCALHOST";
	var valueDelimiter = "LOCALHOST";
	var testResult = FileIO.ReadDelimitedRecord(reader, columnSeparator, valueDelimiter);
	});
}

[TestMethod]
public void Test_ReadFixedWidthRecord_ReaderColumnsWidthEmptyAsNullTrimRowSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var columnsWidth = (int[])null;
	var emptyAsNull = true;
	var trim = true;
	var rowSeparators = (string[])null;
	var testResult = FileIO.ReadFixedWidthRecord(reader, columnsWidth, emptyAsNull, trim, rowSeparators);
	});
}

[TestMethod]
public void Test_ReadFixedWidthRecord_ReaderColumnsWidthEmptyAsNullTrimAlertOnErrorErrorsRowSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var columnsWidth = (int[])null;
	var emptyAsNull = true;
	var trim = true;
	var alertOnError = ;
	var errors = new String();
	var rowSeparators = (string[])null;
	var testResult = FileIO.ReadFixedWidthRecord(reader, columnsWidth, emptyAsNull, trim, alertOnError, errors, rowSeparators);
	});
}

[TestMethod]
public void Test_ReadFixedWidthRecord_LineColumnsWidthEmptyAsNullTrimAlertOnErrorErrors()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var line = "LOCALHOST";
	var columnsWidth = (int[])null;
	var emptyAsNull = true;
	var trim = true;
	var alertOnError = ;
	var errors = new String();
	var testResult = FileIO.ReadFixedWidthRecord(line, columnsWidth, emptyAsNull, trim, alertOnError, errors);
	});
}

[TestMethod]
public void Test_ReadFixedWidthRecord_ReaderColumnsWidth()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var columnsWidth = (int[])null;
	var testResult = FileIO.ReadFixedWidthRecord(reader, columnsWidth);
	});
}

[TestMethod]
public void Test_ReadLine_ReaderRowSeparators()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var rowSeparators = (string[])null;
	var testResult = FileIO.ReadLine(reader, rowSeparators);
	});
}

[TestMethod]
public void Test_ReadLines_ReaderLines()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var reader = new TextReader();
	var lines = -1;
	var testResult = FileIO.ReadLines(reader, lines);
	});
}

[TestMethod]
public void Test_WriteDelimited_WriterDataColumnDelimiterHeaderFieldDelimiterLineDelimiter()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var writer = new TextWriter();
	var data = new DataTable("TestTable");
	var columnDelimiter = "LOCALHOST";
	var header = true;
	var fieldDelimiter = "LOCALHOST";
	var lineDelimiter = "LOCALHOST";
	FileIO.WriteDelimited(writer, data, columnDelimiter, header, fieldDelimiter, lineDelimiter);
	});
}

[TestMethod]
public void Test_DetectEncoding_Path()
{
	var path = "LOCALHOST";
	var testResult = FileIO.DetectEncoding(path);
	// FileIO.DetectEncoding
	// Could not find file 'C:\Users\kemals\SkyDrive\Projects\Compare\GenerateTests\bin\Debug\LOCALHOST'.
}

[TestMethod]
public void Test_DetectEncoding_Stream()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var testResult = FileIO.DetectEncoding(stream);
	});
}

[TestMethod]
public void Test_DetectEncoding_Buffer()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var buffer = (byte[])null;
	var testResult = FileIO.DetectEncoding(buffer);
	});
}

[TestMethod]
public void Test_ReadAllBytes_Stream()
{
	AssertUtils.RaisesException(typeof(ArgumentNullException), () => {
	var stream = new Stream();
	var testResult = FileIO.ReadAllBytes(stream);
	});
}

[TestMethod]
public void Test_GetContentType_Path()
{
	var path = "LOCALHOST";
	var testResult = FileIO.GetContentType(path);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}

[TestClass]
public class XCopyOptionTest
{
}

[TestClass]
public class ToUpperTest
{
[TestMethod]
public void Test_get_Pattern()
{
	var testObject = new ToUpper();
	var testResult = testObject.get_Pattern();
}

[TestMethod]
public void Test_set_Pattern_Value()
{
	var testObject = new ToUpper();
	var value = "LOCALHOST";
	testObject.set_Pattern(value);
}

[TestMethod]
public void Test_Process_TextOptions()
{
	var testObject = new ToUpper();
	var text = "LOCALHOST";
	var options = RegexOptions.Singleline;
	var testResult = testObject.Process(text, options);
}

}

[TestClass]
public class CommandListTest
{
[TestMethod]
public void Test_get_Commands()
{
	var testObject = new CommandList();
	var testResult = testObject.get_Commands();
	Assert.AreEqual(-1, testResult.Capacity);
	Assert.AreEqual(-1, testResult.Count);
}

[TestMethod]
public void Test_LoadXml_Xml()
{
	var xml = "LOCALHOST";
	var testResult = CommandList.LoadXml(xml);
	// CommandList.LoadXml
	// There is an error in XML document (1, 1).
}

[TestMethod]
public void Test_LoadScript_ScriptToken()
{
	var testObject = new CommandList();
	var script = "LOCALHOST";
	var token = "LOCALHOST";
	testObject.LoadScript(script, token);
}

[TestMethod]
public void Test_Process_Text()
{
	var testObject = new CommandList();
	var text = "LOCALHOST";
	var testResult = testObject.Process(text);
}

[TestMethod]
public void Test_ConvertScriptToXml_ScriptToken()
{
	var script = "LOCALHOST";
	var token = "LOCALHOST";
	var testResult = CommandList.ConvertScriptToXml(script, token);
	Assert.IsInstanceOfType(testResult, typeof(String));
	// Parameter count mismatch.
}

}


	/// <summary>
	/// Extra assert methods
	/// </summary>
	static class AssertUtils
	{
		/// <summary>
		/// Ensures that the code in the action raises the exception.
		/// </summary>
		/// <param name="requiredType">The exception.</param>
		/// <param name="action">The action.</param>
		public static void RaisesException(Type requiredType, Action action)
		{
			try
			{
				action();
				Assert.Fail("Exception should have been raised.");
			}
			catch (AssertFailedException e)
			{
				throw e;
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, requiredType);
			}
		}
	}
