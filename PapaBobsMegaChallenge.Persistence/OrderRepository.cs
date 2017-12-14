using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Persistence
{
    public class OrderRepository
    {
        public static List<DTO.DTOOrder> GetOrders()
        {
            BobsPizzaEntities db = new BobsPizzaEntities();
            var dbOrders = db.Orders.ToList();
            var dtoOrders = new List<DTO.DTOOrder> { };

            foreach (var dbOrder in dbOrders)
            {
                var dtoOrder = new DTO.DTOOrder();
                dtoOrder.OrderId = dbOrder.OrderId;
                dtoOrder.OrderFilled = dbOrder.OrderFilled;
                dtoOrder.Crust = dbOrder.Crust;
                dtoOrder.Size = dbOrder.Size;
                dtoOrder.Sausage = dbOrder.Sausage;
                dtoOrder.Pepperoni = dbOrder.Pepperoni;
                dtoOrder.Onions = dbOrder.Onions;
                dtoOrder.GPeppers = dbOrder.GPeppers;
                dtoOrder.CustomerName = dbOrder.CustomerName;
                dtoOrder.CustomerAddress = dbOrder.CustomerAddress;
                dtoOrder.CustomerZip = dbOrder.CustomerZip;
                dtoOrder.CustomerPhone = dbOrder.CustomerPhone;
                dtoOrder.Price = dbOrder.Price;
                dtoOrder.Payment = dbOrder.Payment;
                dtoOrders.Add(dtoOrder);
            }

            return dtoOrders;
        }

        public static void CompleteOrder(Guid orderId)
        {
            BobsPizzaEntities db = new BobsPizzaEntities();
            var completedOrder = db.Orders.Find(orderId);
            completedOrder.OrderFilled = true;
            db.SaveChanges();
        }

        public static void CreateOrder(DTO.DTOOrder dtoOrder)
        {
            BobsPizzaEntities db = new BobsPizzaEntities();
            Order dbOrder = new Order();

            dbOrder.OrderId = dtoOrder.OrderId;
            dbOrder.OrderFilled = dtoOrder.OrderFilled;
            dbOrder.Crust = dtoOrder.Crust;
            dbOrder.Size = dtoOrder.Size;
            dbOrder.Sausage = dtoOrder.Sausage;
            dbOrder.Pepperoni = dtoOrder.Pepperoni;
            dbOrder.Onions = dtoOrder.Onions;
            dbOrder.GPeppers = dtoOrder.GPeppers;
            dbOrder.CustomerName = dtoOrder.CustomerName;
            dbOrder.CustomerAddress = dtoOrder.CustomerAddress;
            dbOrder.CustomerZip = dtoOrder.CustomerZip;
            dbOrder.CustomerPhone = dtoOrder.CustomerPhone;
            dbOrder.Price = dtoOrder.Price;
            dbOrder.Payment = dtoOrder.Payment;


            db.Orders.Add(dbOrder);
            db.SaveChanges();
        }

    }
}
