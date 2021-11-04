<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsProofOfConcept.aspx.cs" Inherits="Unchained.NewsProofOfConcept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
<style>
    .fetched-posts {
    font-family: inherit;
    font-size: 12px;
}
ul {
    list-style: disc;
    padding: 0px;
}
.fetched-posts li {
    list-style: none;
    background: #F7F7F7;
    padding: 5px 0px;
    margin-bottom: 0px;
    border-bottom: 1px solid gainsboro;
}
.fetched-posts a {
    color: #000;
    font-weight: 500;
}
.fetched-posts p {
    font-size: 12px;
    display:none;
}
</style>
 

     <table>

        <tr>
            <td>  
                <img width='150px' height='100px' src="Images/news_icon3.png" />

            </td> <td>              <h1>News Proof Of Concept:</h1>  
            <td><img width='150px' height='100px' src="Images/news_icon3.png" />
        </tr>
    </table>
    <hr />


    <%=GetNews() %>



</asp:Content>
