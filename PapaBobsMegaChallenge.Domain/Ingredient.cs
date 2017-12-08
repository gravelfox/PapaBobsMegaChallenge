using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Domain
{
    public class Ingredient
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public Ingredient(string name, double price)
        {
            this.Type = name;
            this.Price = price;
        }
    }
}
