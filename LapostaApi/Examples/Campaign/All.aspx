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
        var campaignService = new LapostaCampaignService();

        // get all fields, in IEnumerable
        var campaigns = Enumerable.Empty<LapostaCampaign>();
        try
        {
            campaigns = campaignService.All();
        }
        catch (LapostaException lapostaException)
        {
            // handle the exception
            Response.Write("Exception: " + lapostaException.LapostaError.Message);
        }

        // fields object is now populated
        foreach (LapostaCampaign campaign in campaigns)
        {
            Response.Write("Naam : " + campaign.Name + "<br>");
            Response.Write("id : " + campaign.CampaignId + "<br>");
            Response.Write("type : " + campaign.Type + "<br>");
            Response.Write("plaintext: " + campaign.PlainText + "<br>");
        }
    %>
</body>
</html>