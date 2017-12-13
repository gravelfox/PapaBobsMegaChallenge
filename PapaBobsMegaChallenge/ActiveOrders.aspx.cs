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
            List<DTO.Order> Orders = Domain.OrderManager.GetOrders();
            activeOrdersGridView.DataSource = Orders.Where(p => p.OrderFilled == false).ToList();
            activeOrdersGridView.DataBind();
        }

        protected void activeOrdersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Guid orderId = new Guid();
            if(!Guid.TryParse(activeOrdersGridView.Rows[index].Cells[1].Text, out orderId))
                throw new Exception("Order ID invalid");
            Domain.OrderManager.CompleteOrder(orderId);
            displayOrders();
        }
        
    }
}