<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="Laposta" %>
<%@ Import Namespace="Laposta.Services" %>
<%@ Import Namespace="Laposta.Entities" %>
<!DOCTYPE html>
<html>
<head>
    <title></title>
</head>
<body>
    <%
    // set api key
    LapostaConfig.apiKey = "JdMtbsMq2jqJdQZD9AHC";

    // initialize fieldService with list_id
    var fieldService = new LapostaFieldService("g0jxfa_1zw");
    
    // get specific field
    LapostaField field = new LapostaField();
    try
    {
        field = fieldService.Get("EsCQeHDf_E");  
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // field object is now populated
    Response.Write("Naam veld: " + field.Name);
    Response.Write("<br>Datatype: " + field.Datatype);
    if (field.Datatype == "select_single" || field.Datatype == "select_multiple")
    {
        foreach (var item in field.Options)
        {
            Response.Write("<br>Optie: " + item);
        }
    }   
    %>
</body>
</html>
