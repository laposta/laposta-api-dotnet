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

        // save
        try
        {
            //campaign = campaignService.Get("ffbxvtqxb4");
            campaign.Subject = "subject";
            campaign = campaignService.Update("94wb6pucra",campaign);
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
