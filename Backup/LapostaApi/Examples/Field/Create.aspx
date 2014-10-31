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

    // initialize fieldService with field_id
    var fieldService = new LapostaFieldService("g0jxfa_1zw");
    
    // create empty field object
    LapostaField field = new LapostaField();
    
    // fill
    field.Name = "Een nieuw veld";
    field.Datatype = "text";
    field.Required = true;

    // save
    try
    {
        field = fieldService.Create(field);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // field object is now saved, and Id is populated
    Response.Write("Naam veld: " + field.Name);
    Response.Write("<br>Id veld: " + field.Id);
    %>
</body>
</html>
