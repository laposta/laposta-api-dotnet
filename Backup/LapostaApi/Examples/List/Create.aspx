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
    
    // create empty list object
    LapostaList list = new LapostaList();
    
    // fill
    list.Name = "Een nieuwe lijst";
    list.Remarks = "Om te testen";

    // save
    try
    {
        list = listService.Create(list);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // list object is now saved, and Id is populated
    Response.Write("Naam lijst: " + list.Name);
    Response.Write("<br>Id lijst: " + list.Id);
    %>
</body>
</html>
