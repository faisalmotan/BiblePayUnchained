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

    <asp:Repeater ID="Repeater1" runat="server" >  
        <ItemTemplate> 
        <table> 
          <tr>
              <td>
                    <a target='_blank' href='<%#Eval("URL")%>'><h2 class='headline'><%#Eval("Title")%></h2></a><br>
                  <img width='100%' height='500px' src='<%#Eval("ImageURL")%>' />
                  <br>
                    <span class='headline'><%#Eval("Body")%></span><br><br>
                    <a target='_blank' href='<%#Eval("URL")%>' style='text-decoration: underline;'>Read more</a><br><br>
              </td>
         
          </tr>
        </table>
        </ItemTemplate>
    </asp:Repeater>

    <%--<asp:DataList ID="DataList1" runat="server" DataKeyField="id" RepeatDirection="Horizontal"
    EnableViewState="False">
        <ItemTemplate>
         <table> 
          <tr>
              <td>
                  <a target='_blank' href='<%#Eval("URL")%>'><h2 class='headline'><%#Eval("Title")%></h2></a><br>
                  <img width='100%' height='500px' src='<%#Eval("ImageURL")%>' />
                  <br>
                    <span class='headline'><%#Eval("Body")%></span><br><br>
                  <a target='_blank' href='<%#Eval("URL")%>' style='text-decoration: underline;'>Read more</a><br><br>
              </td>

         
          </tr>
        </table>
            </ItemTemplate>
        </asp:DataList>--%>
   <br />  
        <div style="text-align:center">  
            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">  
                <ItemTemplate>  
                    <asp:LinkButton ID="lnkPage"  
                        Style="padding: 8px; margin: 2px; background: lightgray; border: solid 1px #666; color: black; font-weight: bold"  
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                    </asp:LinkButton>  
                </ItemTemplate>  
            </asp:Repeater>  
        </div>  
 



</asp:Content>
