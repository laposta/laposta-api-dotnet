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
    var campaignService = new LapostaCampaignService();
    
    // get specific list
    LapostaCampaign campaign = new LapostaCampaign();
    try
    {
        campaign = campaignService.Get("94wb6pucra");  
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // list object is now populated
    Response.Write("Naam campagne: " + campaign.Name);
    
    %>
</body>
</html>
