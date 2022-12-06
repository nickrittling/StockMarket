<%@ Page Title="Current User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Stock_Market.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>.</h3>

    <asp:Literal ID="curUser" runat="server"></asp:Literal>


</asp:Content>
