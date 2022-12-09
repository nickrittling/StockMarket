<%@ Page Title="Set up the limit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetUpLimit.aspx.cs" Inherits="Stock_Market.SetUpLimit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top:25px"></div>
     <h2 class="text-center"><%: Title %></h2>
    
    <asp:GridView ID ="GridView" runat="server" AutoGenerateColumns="True" class="table table-hover" GridLines="none"></asp:GridView>

  <div class="row">
   
    <div class="col-sm-4" style="display:inline" >
         <label for="formGroupExampleInput">Select action:</label>
           <asp:DropDownList id="ActionList"
             AutoPostBack="True"
             OnSelectedIndexChanged="SelectedIndexChanged"             
             class="form-control"
             runat="server">
           <asp:ListItem Selected="True"></asp:ListItem>           
           <asp:ListItem Selected="False" Value="Buy"> Buy </asp:ListItem>
           <asp:ListItem Value="Sell"> Sell </asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-sm-4"  style="display:inline">
         <label for="formGroupExampleInput">Limit price</label>
        <asp:TextBox class="form-control" ID="amount" runat="server" Text="0.00"></asp:TextBox>
    </div>
    <div class="col-sm-4"  style="display:inline">
         <label for="formGroupExampleInput">Total:</label>
         <asp:TextBox class="form-control" ID="total" runat="server" Text="0.00"></asp:TextBox>
    </div>
  </div>
  
   <div style="margin:30px" >
       <asp:Button CssClass="btn btn-info" ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server"/>

  </div>
   <div style ="margin-top:50px" >
      <asp:Literal ID="msg" runat="server"></asp:Literal>
    </div>

   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarketConnectionString %>" 
    ></asp:SqlDataSource>
</asp:Content>

