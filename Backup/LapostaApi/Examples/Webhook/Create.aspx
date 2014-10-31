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

    // initialize webhookService with webhook_id
    var webhookService = new LapostaWebhookService("g0jxfa_1zw");
    
    // create empty webhook object
    LapostaWebhook webhook = new LapostaWebhook();
    
    // fill
    webhook.Event = "modified";
    webhook.Url = "https://www.example.net/laposta";

    // save
    try
    {
        webhook = webhookService.Create(webhook);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // webhook object is now saved, and Id is populated
    Response.Write("Url webhook: " + webhook.Url);
    Response.Write("<br>Id webhook: " + webhook.Id);
    %>
</body>
</html>
