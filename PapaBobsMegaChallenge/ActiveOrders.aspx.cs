using PapaBobsMegaChallenge.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public partial class ActiveOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayOrders();
        }

        private void displayOrders()
        {
            try
            {
                List<DTO.DTOOrder> Orders = Domain.OrderManager.GetOrders();
                activeOrdersGridView.DataSource = Orders.Where(p => p.OrderFilled == false).ToList();
                activeOrdersGridView.DataBind();
            }
            catch (Exception)
            {
                errorLabel.Text = "An unknown error occured displaying the orders.";   
            }

        }

        protected void activeOrdersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Guid orderId = new Guid();
                if (!Guid.TryParse(activeOrdersGridView.Rows[index].Cells[1].Text, out orderId))
                    throw new OrderIdInvalidException();
                Domain.OrderManager.CompleteOrder(orderId);
                displayOrders();
            }
            catch (OrderIdInvalidException)
            {
                errorLabel.Text = "The order ID is not in a valid format.";
            }
            catch (Exception)
            {
                errorLabel.Text = "An unknown error occured.";
            }

        }
        
    }
}