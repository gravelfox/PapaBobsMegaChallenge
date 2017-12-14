using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.Domain.Exceptions;

namespace PapaBobsMegaChallenge.Domain
{



    public class Pizza
    {

        public DTO.Size Size { get; set; }
        public DTO.Crust Crust { get; set; }
        public List<Ingredient> toppings { get; set; }
        public double Price { get; set; }

        public Pizza(string size, string crust, bool sausage, bool pepperoni, bool onions, bool gpeppers)
        {
            this.toppings = new List<Ingredient> { };
            DTO.Size selectedSize;
            if (!Enum.TryParse(size, out selectedSize)) throw new NoSizeSelectedException();
            else this.Size = selectedSize;
            DTO.Crust selectedCrust;
            if (!Enum.TryParse(crust,out selectedCrust)) throw new NoCrustSelectedException();
            else this.Crust = selectedCrust;
            if (sausage) this.toppings.Add(new Ingredient("Sausage", 2d));
            if (pepperoni) this.toppings.Add(new Ingredient("Pepperoni", 1.5));
            if (onions) this.toppings.Add(new Ingredient("Onions", 1d));
            if (gpeppers) this.toppings.Add(new Ingredient("Green Peppers", 1d));
            this.Price = calculatePrice();
        }

        private double calculatePrice()
        {
            double price = 0d;
            price += getSizePrice();
            price += getCrustPrice();
            price += getIngredientPrice();
            return price;
        }

        private double getIngredientPrice()
        {
            double price = 0d;
            price += this.toppings.Sum(p => p.Price);
            return price;
        }

        private double getCrustPrice()
        {
            double price = 0d;
            if (this.Crust == DTO.Crust.Thick) price = 2;
            return price;
        }

        private double getSizePrice()
        {
            double price = 0d;
            switch (this.Size)
            {
                case DTO.Size.Small:
                    price += 12;
                    break;
                case DTO.Size.Medium:
                    price += 14;
                    break;
                case DTO.Size.Large:
                    price += 16;
                    break;
            }
            return price;
        }
    }
}
