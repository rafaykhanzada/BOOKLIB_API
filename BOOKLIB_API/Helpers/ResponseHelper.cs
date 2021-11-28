using System.Collections.Generic;

namespace BOOKLIB_API.Helpers
{
    public class ResponseHelper
    { 
    public ResponseHelper()
    {

    }
    public ResponseHelper(int _status, object _data, ErrorDef _err)
    {
        status = _status;
        data = _data;
        error = _err;
    }

    public int status;
    public object data { get; set; }
    public ErrorDef error { get; set; }

    public static object getObject(string key, string value)
    {
        Dictionary<string, string> dicObj = new Dictionary<string, string>();
        dicObj.Add(key, value);
        return dicObj;
    }
    public static object getBlankObject()
    {
        return new object();
    }
}

public class ErrorDef
{
    public ErrorDef()
    {

    }
    public ErrorDef(int _errID, string _errType, string _errMsg, string _addMsg = "")
    {
        errorID = _errID;
        errorType = _errType;
        errorMessage = _errMsg;
        additonalMessage = _addMsg;
    }

    public int errorID { get; set; } = 0;
    public string errorType { get; set; } = "[]";
    public string errorMessage { get; set; } = "[]";
    public string additonalMessage { get; set; } = "[]";
}
}
