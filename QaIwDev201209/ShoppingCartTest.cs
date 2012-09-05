using System;
using IwDev201209;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QaIwDev201209
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void TestCart()
        {
            var emptyCart = ShoppingCart<string>.NewCart();
            emptyCart.Display();

            var cartA = emptyCart.Add("A");  //one item
            cartA.Display();

            var cartAb = cartA.Add("B");  //two items
            cartAb.Display();

            var cartB = cartAb.Remove("A"); //one item
            cartB.Display();

            var emptyCart2 = cartB.Remove("B"); //empty
            emptyCart2.Display();

            Console.WriteLine("Removing from emptyCart");
            emptyCart.Remove("B"); //error


            //  try to pay for cartA
            Console.WriteLine("paying for cartA");
            var paidCart = cartA.Do(
                state => cartA,
                state => state.Pay(100),
                state => cartA);
            paidCart.Display();

            Console.WriteLine("Adding to paidCart");
            paidCart.Add("C");

            //  try to pay for emptyCart
            Console.WriteLine("paying for emptyCart");
            var emptyCartPaid = emptyCart.Do(
                state => state.Pay(100),
                state => state.Pay(100),
                state => emptyCart);
            emptyCartPaid.Display();
        }
    }


}
