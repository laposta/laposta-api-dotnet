<%@ Page Language="C#" %>
<%@ Import Namespace="Laposta" %>
<%@ Import Namespace="Laposta.Services" %>
<%@ Import Namespace="Laposta.Entities" %>
<%@ Import Namespace="System.Linq" %>

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
           
    // get all fields, in IEnumerable
    var fields = Enumerable.Empty<LapostaField>();
    try
    {
        fields = fieldService.All(); 
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // fields object is now populated
    foreach (LapostaField field in fields)
    {
        Response.Write("Naam veld: " + field.Name + "<br>");
    }
    %>
</body>
</html>