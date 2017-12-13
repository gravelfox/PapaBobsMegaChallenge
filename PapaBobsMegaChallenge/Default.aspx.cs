using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) updateTotal();
         }

        private void updateTotal()
        {
            if (crustDropDown.SelectedValue != "0" && sizeDropDown.SelectedValue != "0")
            {
                Domain.Pizza Pizza = new Domain.Pizza(
                    sizeDropDown.SelectedValue,
                    crustDropDown.SelectedValue,
                    sausageCheckBox.Checked,
                    pepperoniCheckBox.Checked,
                    onionsCheckBox.Checked,
                    gPeppersCheckBox.Checked);
                totalLabel.Text = string.Format("{0:C}", Pizza.Price);
            }
            else totalLabel.Text = "";
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            var dtoOrder = new DTO.Order() { };
            Domain.Pizza pizza = new Domain.Pizza(
                    sizeDropDown.SelectedValue,
                    crustDropDown.SelectedValue,
                    sausageCheckBox.Checked,
                    pepperoniCheckBox.Checked,
                    onionsCheckBox.Checked,
                    gPeppersCheckBox.Checked);
            dtoOrder = populateOrder(pizza);

            Domain.OrderManager.CreateOrder(dtoOrder);
            Response.Redirect("./Success.aspx");
        }

        private DTO.Order populateOrder(Domain.Pizza pizza)
        {
            DTO.Order dtoOrder = new DTO.Order() { };
            dtoOrder.OrderId = Guid.NewGuid();
            dtoOrder.CustomerName = nameTextBox.Text;
            dtoOrder.CustomerAddress = addressTextBox.Text;
            dtoOrder.CustomerZip = int.Parse(zipTextBox.Text);
            dtoOrder.CustomerPhone = phoneTextBox.Text;
            dtoOrder.OrderFilled = false;
            dtoOrder.Crust = (int)pizza.Crust;
            dtoOrder.Size = (int)pizza.Size;
            dtoOrder.Sausage = sausageCheckBox.Checked;
            dtoOrder.Pepperoni = pepperoniCheckBox.Checked;
            dtoOrder.Onions = onionsCheckBox.Checked;
            dtoOrder.GPeppers = gPeppersCheckBox.Checked;
            dtoOrder.Price = pizza.Price;
            dtoOrder.Payment = Domain.OrderManager.CheckPayment(cashRadioButton.Checked, creditRadioButton.Checked);

            return dtoOrder;
        }
    }
}