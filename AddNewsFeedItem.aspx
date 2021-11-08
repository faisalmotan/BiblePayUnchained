<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewsFeedItem.aspx.cs" Inherits="Unchained.AddNewsFeedItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                       <h3>Add New Ticket <small>v1.1</small></h3>
            </td>
        </tr>

    </table>





        <asp:Label ID="lblSubject" runat="server" Text="Feed Name:" ></asp:Label>
        <br />
        <asp:TextBox ID="txtSubject" width="400px" runat="server"></asp:TextBox>
        <br />
        <br />

            <asp:Label ID="Label1" runat="server" Text="Ticket Body:"></asp:Label>
    <br />

        <asp:CheckBox ID="CheckBox1" runat="server" />
      <asp:Label ID="lblBody" runat="server" Text="Ticket Body:"></asp:Label>
        <br />

        <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine"  Rows="10" class='pc90'>
        </asp:TextBox>
        <br />
    <br />


    <br />
    <asp:Button ID="btnSave" runat="server" Text="Submit Ticket" OnClick="btnSave_Click" />
    


</asp:Content>
