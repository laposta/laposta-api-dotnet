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

    // initialize memberService with member_id
    var memberService = new LapostaMemberService("g0jxfa_1zw");
    
    // create empty member object
    LapostaMember member = new LapostaMember();
    
    // fill attributes that have to be updated
    member.Email = "anderadres@example.com";
    member.CustomFields = new Dictionary<string, string>()
    {
        {"achternaam", "Boterse"}
    };
    
    // save
    try
    {
        member = memberService.Update("1k9jbdwabr", member);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // member object is now saved, and Id is populated
    Response.Write("Email relatie: " + member.Email);
    Response.Write("<br>Id relatie: " + member.Id);
    %>
</body>
</html>
