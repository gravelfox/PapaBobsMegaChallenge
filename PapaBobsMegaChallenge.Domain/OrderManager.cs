using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge;


namespace PapaBobsMegaChallenge.Domain
{
   public class OrderManager
    {
        public static List<DTO.Order> GetOrders()
        {
            var orders = Persistence.OrderRepository.GetOrders();
            return orders;
        }

        public static void CreateOrder(DTO.Order dtoOrder)
        {
            Persistence.OrderRepository.CreateOrder(dtoOrder);
        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
        }

        public static bool CheckPayment(bool cashChecked, bool creditChecked)
        {
            bool payment;
            if (cashChecked) payment = true;
            else if (creditChecked) payment = false;
            else throw new Exception("No form of Payment has been selected.");
            return payment;
        }
    }
}
