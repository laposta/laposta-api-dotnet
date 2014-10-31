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
    
    // fill attributes that have to be updated
    webhook.Event = "deactivated";
    webhook.Blocked = true;
    
    // save
    try
    {
        webhook = webhookService.Update("qnvuopES7a", webhook);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // webhook object is now saved, and Id is populated
    Response.Write("Url webhook: " + webhook.Url);
    Response.Write("<br>Event webhook: " + webhook.Event);
    Response.Write("<br>Id webhook: " + webhook.Id);
    %>
</body>
</html>
