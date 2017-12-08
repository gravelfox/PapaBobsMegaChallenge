using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Domain
{

    public enum Size { small, medium, large }
    public enum Crust { regular, thin, thick }

    public class Pizza
    {

        public Size Size { get; set; }
        public Crust Crust { get; set; }
        public List<Ingredient> toppings { get; set; }
        public double Price { get; set; }

        public Pizza(string size, string crust, bool sausage, bool pepperoni, bool onions, bool gpeppers)
        {
            this.toppings = new List<Ingredient> { };
            this.Size = (Size)Enum.Parse(typeof(Size), size);
            this.Crust = (Crust)Enum.Parse(typeof(Crust), crust);
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
            if (this.Crust == Crust.thick) price = 2;
            return price;
        }

        private double getSizePrice()
        {
            double price = 0d;
            switch (this.Size)
            {
                case Size.small:
                    price += 12;
                    break;
                case Size.medium:
                    price += 14;
                    break;
                case Size.large:
                    price += 16;
                    break;
            }
            return price;
        }
    }
}
