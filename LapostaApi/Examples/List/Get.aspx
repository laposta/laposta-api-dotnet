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

    // initialize listService
    var listService = new LapostaListService();
    
    // get specific list
    LapostaList list = new LapostaList();
    try
    {
        list = listService.Get("g0jxfa_1zw");  
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // list object is now populated
    Response.Write("Naam lijst: " + list.Name);
    Response.Write("<br>Aantal actieve relaties: " + list.Membercount.active);
    
    %>
</body>
</html>
