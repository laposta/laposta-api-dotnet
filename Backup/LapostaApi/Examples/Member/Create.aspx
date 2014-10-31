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
    
    // fill
    member.Email = "stijn@laposta.nl";
    member.IP = "65.195.36.173";
    member.SourceUrl = "http://www.example.net/source";
    member.CustomFields = new Dictionary<string, string>()
    {
        {"achternaam", "Verheije"}
    };
        
    // save
    try
    {
        member = memberService.Create(member);
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // member object is now saved, and Id is populated
    Response.Write("Email relatie: " + member.Email);
    Response.Write("<br>Id veld: " + member.Id);
    %>
</body>
</html>
