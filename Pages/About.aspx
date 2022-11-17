<%@ Page Title="Stock trading:" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Stock_Market.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

     <h2 class="text-center"><%: Title %></h2>
   
    
    <asp:GridView ID ="GridView" runat="server" AutoGenerateColumns="True" class="table table-hover" GridLines="none"></asp:GridView>
   
    
   <div class="col6"> 
        <asp:DropDownList id="ColorList"
             AutoPostBack="True"
             OnSelectedIndexChanged="SelectedIndexChanged"
             Width="120px"
             Height="40px" 
             runat="server">
           <asp:ListItem Selected="True"></asp:ListItem>           
           <asp:ListItem Selected="False" Value="Buy"> Buy </asp:ListItem>
           <asp:ListItem Value="Sell"> Sell </asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox class="form-control" ID="textBox" runat="server" Text="0.00"></asp:TextBox>
         
     <p> Total price :</p>
    <asp:TextBox  class="form-control" ID="total" runat="server" Text="0.00"></asp:TextBox>
    
       </div>
         <asp:Button CssClass="btn btn-primary" ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server"/>
         

        
        <asp:Literal ID="msg" runat="server"></asp:Literal>

    </div>

   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarketConnectionString %>" 
    ></asp:SqlDataSource>
</asp:Content>



