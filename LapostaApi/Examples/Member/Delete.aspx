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

    // initialize memberService with list_id
    var memberService = new LapostaMemberService("g0jxfa_1zw");
    
    // delete member
    LapostaMember member = new LapostaMember();
    try
    {
        member = memberService.Delete("p8gv0pp4cc");  
    }
    catch (LapostaException lapostaException)
    {
        // handle the exception
        Response.Write("Exception: " + lapostaException.LapostaError.Message);
    }
    
    // member object is now populated
    Response.Write("Email relatie: " + member.Email);
    Response.Write("<br>Status: " + member.State);
    %>
</body>
</html>