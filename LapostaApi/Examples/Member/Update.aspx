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
    var memberService = new LapostaMemberService("mzn6waeob2");
    
    // create empty member object
    LapostaMember member = new LapostaMember();
    
    // fill fields that have to be updated
    member.Email = "anderadres@example.com";
    member.CustomFields = new Dictionary<string, object>()
    {
        {"achternaam", "Boterse"},
        
        // handle list field with single choice
        {"meerkeuzeenkel", "optie3"},
                
        // handle list field with multiple selections like this
        {"meerkeuze", new List<string>() { "a", "c" }}
    };    
    
    // save
    try
    {
        // use member_id here
        member = memberService.Update("zz8cqvzvem", member);
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
