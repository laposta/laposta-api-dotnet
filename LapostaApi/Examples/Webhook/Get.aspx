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

    // initialize webhookService with list_id
    var webhookService = new LapostaWebhookService("g0jxfa_1zw");
    
    // get specific webhook
    LapostaWebhook webhook = new LapostaWebhook();
    try
    {
        webhook = webhookService.Get("qnvuopES7a");  
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // webhook object is now populated
    Response.Write("Url webhook: " + webhook.Url);
    Response.Write("<br>Event: " + webhook.Event);   
    %>
</body>
</html>
