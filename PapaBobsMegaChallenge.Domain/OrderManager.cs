using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge;
using PapaBobsMegaChallenge.Domain.Exceptions;


namespace PapaBobsMegaChallenge.Domain
{
   public class OrderManager
    {
        public static List<DTO.DTOOrder> GetOrders()
        {
            var orders = Persistence.OrderRepository.GetOrders();
            return orders;
        }

        public static void CreateOrder(DTO.DTOOrder dtoOrder)
        {
            if (dtoOrder.CustomerName.Trim().Length == 0) throw new NullNameException();
            if (dtoOrder.CustomerAddress.Trim().Length == 0) throw new NullAddressException();
            if (dtoOrder.CustomerPhone.Trim().Length == 0) throw new NullPhoneException();
            if (dtoOrder.CustomerZip == 0) throw new NullZipException();
            Persistence.OrderRepository.CreateOrder(dtoOrder);
        }

        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrderRepository.CompleteOrder(orderId);
        }

        public static DTO.Payment CheckPayment(bool cashChecked, bool creditChecked)
        {
            DTO.Payment payment;
            if (cashChecked) payment = DTO.Payment.Cash;
            else if (creditChecked) payment = DTO.Payment.Credit;
            else throw new NoPaymentSelectedException();
            return payment;
        }
    }
}
