using PapaBobsMegaChallenge.Domain;
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
                Pizza Pizza = new Pizza(
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

        }
    }
}