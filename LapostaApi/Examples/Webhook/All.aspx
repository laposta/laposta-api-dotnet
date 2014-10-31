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

    // initialize webhookService with list_id
    var webhookService = new LapostaWebhookService("g0jxfa_1zw");
           
    // get all webhooks, in IEnumerable
    var webhooks = Enumerable.Empty<LapostaWebhook>();
    try
    {
        webhooks = webhookService.All(); 
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // webhooks object is now populated
    foreach (LapostaWebhook webhook in webhooks)
    {
        Response.Write("Url webhook: " + webhook.Url + "<br>");
    }
    %>
</body>
</html>