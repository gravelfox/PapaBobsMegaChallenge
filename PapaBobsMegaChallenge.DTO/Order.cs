using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.DTO
{
    public class Order
    {
        public System.Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerZip { get; set; }
        public string CustomerPhone { get; set; }
        public bool OrderFilled { get; set; }
        public int Crust { get; set; }
        public int Size { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperoni { get; set; }
        public bool Onions { get; set; }
        public bool GPeppers { get; set; }
        public double Price { get; set; }
        public bool Payment { get; set; }
    }
}
