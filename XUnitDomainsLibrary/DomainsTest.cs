using System;
using System.Collections.Generic;
using System.Text;
using Domains.Library;
using Xunit;

namespace XUnitDomainsLibrary
{
    public class DomainsTest
    {
        [Theory]
        [InlineData(1.00, 1, 1)]
        [InlineData(0.89,3,1)]
        [InlineData(1.00, 1, 2)]
        [InlineData(2.99, 60, 2)]
        [InlineData(5.10, 0, 1)]
        [InlineData(0.89, 0, 2)]
        public void CalculateCostOfBasketCalculatesCorrectly(decimal price, int quanity, int numOfTests)
        {
            //arrange
            var cust = new Customer("Greg", "Favrot", "street");
            var prod1 = new Product("Coke", "drink", 1, price);
            var prod2 = new Product("Pepsi", "drink", 2, price);
            var loc = new Location("Walmart", "road", 1);
            var ord = new Order(cust, loc, 1);

            if (numOfTests == 1)
            {
                ord.basket.Add(prod1, quanity);
            }
            if(numOfTests == 2)
            {
                ord.basket.Add(prod1, quanity);
                ord.basket.Add(prod2, quanity);
            }

            //act
            decimal cost = ord.CalculateCostOfBasket();

            //assert
            Assert.Equal(expected: price * quanity * numOfTests, actual: cost);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(82, 1)]
        [InlineData(1, 2)]
        [InlineData(60, 2)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        public void CalculateNumberOfItemsInBasketCalculatesCorrectly(int quanity, int numOfTests)
        {
            //arrange
            var cust = new Customer("Greg", "Favrot", "street");
            var prod1 = new Product("Coke", "drink", 1, 1);
            var prod2 = new Product("Pepsi", "drink", 2, 1);
            var loc = new Location("Walmart", "road", 1);
            var ord = new Order(cust, loc, 1);

            if (numOfTests == 1)
            {
                ord.basket.Add(prod1, quanity);
            }
            if (numOfTests == 2)
            {
                ord.basket.Add(prod1, quanity);
                ord.basket.Add(prod2, quanity);
            }

            //act
            int num = ord.CalculateNumberOfItemsInBasket();

            //assert
            Assert.Equal(expected: quanity * numOfTests, actual: num);
        }


    }
}
