<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="Laposta" %>
<%@ Import Namespace="Laposta.Services" %>
<%@ Import Namespace="Laposta.Entities" %>
<%@ Import Namespace="System.Collections.Generic" %>


<!DOCTYPE html>
<html>
<head>
    <title></title>
</head>
<body>
    <%
    // set api key
    LapostaConfig.apiKey = "JdMtbsMq2jqJdQZD9AHC";

    // initialize memberService with list_id
    var memberService = new LapostaMemberService("g0jxfa_1zw");
    
    // get specific member
    LapostaMember member = new LapostaMember();
    try
    {
        member = memberService.Get("vw32ht3qwp");
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // member object is now populated
    Response.Write("Email member: " + member.Email);
    
    // eventuele eigen velden
    if (member.CustomFields != null)
    {
        foreach (KeyValuePair<string, string> kvp in member.CustomFields)
        {
            Response.Write("<br>Veld: " + kvp.Key + " heeft waarde: " + kvp.Value);
        }
    }
    else
    {
        Response.Write("<br>Geen eigen velden");
    }
    %>
</body>
</html>
