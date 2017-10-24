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

        // initialize fieldService with list_id
        var campaignService = new LapostaCampaignService();

        // create empty field object
        LapostaCampaign campaign = new LapostaCampaign();

        // fill
        campaign.Type = "regular";
        campaign.Name = "testcampaign";
        campaign.Subject = "subject";
        campaign.From.Name = "test";
        campaign.From.Email = "test@example.com";
        campaign.ListIds[0] = "g0jxfa_1zw";

        // save
        try
        {
            campaign = campaignService.Create(campaign);
        }
        catch (LapostaException lapostaException)
        {
            // handle the exception
            Response.Write("Exception: " + lapostaException.LapostaError.Message);
        }

        // field object is now saved, and Id is populated
        Response.Write("Naam veld: " + campaign.Name);
        Response.Write("<br>Id veld: " + campaign.CampaignId);
    %>
</body>
</html>
