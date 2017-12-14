<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Papa Bob's Pizza</h1>
            <p class="lead">Pizza to Code By</p>
        </div>
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="sizeDropDown">Size:</label><br />
                <asp:DropDownList ID="sizeDropDown" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Value="">Select Size...</asp:ListItem>
                    <asp:ListItem Value="Small">Small (12in - $12)</asp:ListItem>
                    <asp:ListItem Value="Medium">Medium (14in - $14)</asp:ListItem>
                    <asp:ListItem Value="Large">Large (16in - $16)</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="crustDropDown">Crust:</label><br />
                <asp:DropDownList ID="crustDropDown" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Value="">Select Crust...</asp:ListItem>
                    <asp:ListItem Value="Regular">Regular</asp:ListItem>
                    <asp:ListItem Value="Thin">Thin</asp:ListItem>
                    <asp:ListItem Value="Thick">Thick (+$2.00)</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="checkbox">
            <label for="sausageCheckBox">
                <asp:CheckBox ID="sausageCheckBox" runat="server" AutoPostBack="True"/>
                Sausage
            </label>
        </div>
        <div class="checkbox">
            <label for="pepperoniCheckBox">
                <asp:CheckBox ID="pepperoniCheckBox" runat="server" AutoPostBack="True"/>
                Pepperoni
            </label>
        </div>        
        <div class="checkbox">
            <label for="onionsCheckBox">
                <asp:CheckBox ID="onionsCheckBox" runat="server" AutoPostBack="True"/>
                Onions
            </label>
        </div>        
        <div class="checkbox">
            <label for="gPeppersCheckBox">
                <asp:CheckBox ID="gPeppersCheckBox" runat="server" AutoPostBack="True"/>
                Green Peppers
            </label>
        </div> 

        <h3>Deliver To:</h3>
        
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="nameTextBox">Name:</label><br />
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>        
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="addressTextBox">Address:</label><br />
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>        
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="zipTextBox">Zip:</label><br />
                <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>        
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="phoneTextBox">Phone:</label><br />
                <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <h3>Payment:</h3>
        <div class="radio">
            <label for="cashRadioButton">
                <asp:RadioButton ID="cashRadioButton" runat="server" GroupName="payment" />
                Cash
            </label>
        </div>
        <div class="radio">
            <label for="creditRadioButton">
                <asp:RadioButton ID="creditRadioButton" runat="server" GroupName="payment" />
                Credit
            </label>
        </div>
        <asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn-lg btn-primary" OnClick="orderButton_Click"/>
        &nbsp;<br />
        <asp:Label ID="errorLabel" runat="server" CssClass="bg-danger"></asp:Label>
        <h3>Total Cost:</h3>
        <h4><asp:Label ID="totalLabel" runat="server"></asp:Label></h4>
        <p>&nbsp;</p>
    </div>
    </form>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
</body>
</html>
