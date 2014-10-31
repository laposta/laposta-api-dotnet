<%@ Page Language="C#" %>
<%@ Import Namespace="Laposta" %>
<%@ Import Namespace="Laposta.Services" %>
<%@ Import Namespace="Laposta.Entities" %>
<%@ Import Namespace="System.Collections.Generic" %>
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

    // initialize memberService with list_id
    var memberService = new LapostaMemberService("mzn6waeob2");
           
    // get all members, in IEnumerable
    var members = Enumerable.Empty<LapostaMember>();
    try
    {
        members = memberService.All(); 
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // members object is now populated
    foreach (LapostaMember member in members)
    {
        Response.Write("Email relatie: " + member.Email + "<br>");
    }
    %>
</body>
</html>