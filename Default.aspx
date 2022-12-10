<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stock_Market._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="text-center">
            <h1>Stock Market</h1>
           <p style ="font-size:24px; font-weight:bolder; color:darkgray"><asp:Literal ID="date" runat="server"></asp:Literal></p> 
        </div>

   
    <asp:GridView ID="GridView1" class="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand1" GridLines="none">
        <Columns>
            <asp:BoundField DataField="Symbol" HeaderText="Symbol" SortExpression="Symbol">
            <ControlStyle/>
            </asp:BoundField>
            <asp:BoundField DataField="StockName" HeaderText="Name" SortExpression="StockName" />
            <asp:BoundField DataField="CurrentPrice" HeaderText="Current Price" SortExpression="CurrentPrice" />
            <asp:BoundField DataField="WeeklyPrice" HeaderText="Weekly Price" SortExpression="WeeklyPrice" />
            <asp:BoundField DataField="MonthlyPrice" HeaderText="Monthly Price" SortExpression="MonthlyPrice" />
            <asp:BoundField DataField="ThreeMonthPrice" HeaderText="Three Month Price" SortExpression="ThreeMonthPrice"></asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Trade" Text="Trade">           
            <ControlStyle  CssClass="btn btn-primary"  Width="80px"/>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" CommandName="SetLimit" Text="Set Limit">
            <ControlStyle  CssClass="btn btn-success"  Width="80px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>

    </div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarketConnectionString %>" SelectCommand="SELECT * FROM [Stocks]"></asp:SqlDataSource>



</asp:Content>
