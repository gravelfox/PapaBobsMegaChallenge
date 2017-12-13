<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveOrders.aspx.cs" Inherits="PapaBobsMegaChallenge.ActiveOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="activeOrdersGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="activeOrdersGridView_RowCommand">
            <Columns>
                <asp:ButtonField Text="Order Complete" />
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                <asp:BoundField DataField="Size" HeaderText="Size" />
                <asp:BoundField DataField="Crust" HeaderText="Crust" />
                <asp:CheckBoxField DataField="Sausage" HeaderText="Sausage" />
                <asp:CheckBoxField DataField="Pepperoni" HeaderText="Pepperoni" />
                <asp:CheckBoxField DataField="Onions" HeaderText="Onion" />
                <asp:CheckBoxField DataField="GPeppers" HeaderText="G Peppers" />
                <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="Price" />
                <asp:BoundField DataField="CustomerName" HeaderText="Name" />
                <asp:BoundField DataField="CustomerAddress" HeaderText="Address" />
                <asp:BoundField DataField="CustomerZip" HeaderText="Zip" />
                <asp:BoundField DataField="CustomerPhone" HeaderText="Phone" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
