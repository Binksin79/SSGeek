using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();


        public void AddToCart(Product p, int quantity)
        {

            if (quantity > 0)
            {

                var shoppingCartItem = Items.FirstOrDefault(i => i.Product.ProductId == p.ProductId);

                if (shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCartItem() { Product = p, Quantity = 0 };
                    Items.Add(shoppingCartItem);
                }

                shoppingCartItem.Quantity += quantity;
            }

        }


        public double GetGrandTotal()
        {
            double result = 0;

            foreach (var item in Items)
            {
                result += (item.Quantity * item.Product.Price);
            }

            return result;
        }
    }
}