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

    // initialize listService
    var listService = new LapostaListService();
            
    // get all lists, in IEnumerable
    var lists = Enumerable.Empty<LapostaList>();
    try
    {
        lists = listService.All(); 
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // lists object is now populated
    foreach (LapostaList list in lists)
    {
        Response.Write("Naam lijst: " + list.Name + "<br>");
    }
    %>
</body>
</html>