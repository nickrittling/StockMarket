<%@ Page Title="Stock trading:" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Stock_Market.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top:25px">
     <h2 class="text-center"><%: Title %></h2>
    
    <asp:GridView ID ="GridView" runat="server" AutoGenerateColumns="True" class="table table-hover" GridLines="none"></asp:GridView>

  <div class="row">
   
    <div class="col-sm-4" style="display:inline" >
         <label for="formGroupExampleInput">Select action:</label>
           <asp:DropDownList id="ColorList"
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
         <label for="formGroupExampleInput">Enter amount:</label>
        <asp:TextBox class="form-control" ID="amount" runat="server" Text="0.00"></asp:TextBox>
    </div>
    <div class="col-sm-4"  style="display:inline">
         <label for="formGroupExampleInput">Total:</label>
         <asp:TextBox class="form-control" ID="total" runat="server" Text="0.00"></asp:TextBox>
    </div>
  </div>
  
   <div style="margin:30px" >
       <asp:Button CssClass="btn btn-primary" ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server"/>

  </div>
         

         
         

        
        <asp:Literal ID="msg" runat="server"></asp:Literal>

    </div>

   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarketConnectionString %>" 
    ></asp:SqlDataSource>
</asp:Content>



