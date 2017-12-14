using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsMegaChallenge.Domain.Exceptions;

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
            if (crustDropDown.SelectedValue != "" && sizeDropDown.SelectedValue != "")
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
            try
            {
                var dtoOrder = new DTO.DTOOrder() { };
                if (sizeDropDown.SelectedValue == "") throw new NoSizeSelectedException();
                if (crustDropDown.SelectedValue == "") throw new NoCrustSelectedException();
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
            catch (NoSizeSelectedException)
            {
                errorLabel.Text = "You must select a size.";
            }
            catch (NoCrustSelectedException)
            {
                errorLabel.Text = "You must select a crust.";
            }
            catch (NullNameException)
            {
                errorLabel.Text = "You must enter a name.";
            }
            catch (NullAddressException)
            {
                errorLabel.Text = "You must enter an address.";
            }
            catch (NullZipException)
            {
                errorLabel.Text = "You must enter a zipcode.";
            }
            catch (InvalidZipException)
            {
                errorLabel.Text = "You must enter a valid zipcode with no special characters.";
            }
            catch (NullPhoneException)
            {
                errorLabel.Text = "You must enter a phone number.";
            }
            catch (NoPaymentSelectedException)
            {
                errorLabel.Text = "You must select a payment type.";
            }

        }

        private DTO.DTOOrder populateOrder(Domain.Pizza pizza)
        {
            DTO.DTOOrder dtoOrder = new DTO.DTOOrder() { };
            dtoOrder.OrderId = Guid.NewGuid();
            dtoOrder.CustomerName = nameTextBox.Text;
            dtoOrder.CustomerAddress = addressTextBox.Text;
            int zip = 0;
            if(!int.TryParse(zipTextBox.Text, out zip)) throw new InvalidZipException();
            dtoOrder.CustomerZip = zip;
            dtoOrder.CustomerPhone = phoneTextBox.Text;
            dtoOrder.OrderFilled = false;
            dtoOrder.Crust = pizza.Crust;
            dtoOrder.Size = pizza.Size;
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