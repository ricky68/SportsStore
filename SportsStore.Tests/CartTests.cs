using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SportsStore.Tests {
    public class CartTests {
        [Fact]
        public void Can_Add_New_Lines() {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            //Araange - Create a new cart
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines() {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            //Araange - Create a new cart
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line() {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            //Araange - Create a new cart
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.RemoveLine(p1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Single(results);
            Assert.Equal(p2, results[0].Product);
        }

        [Fact]
        public void Can_Calculate_Total_Cost() {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price=50M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price=74M };

            //Araange - Create a new cart
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 4);
            target.AddItem(p2, 1);
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.Equal(274M, result);
        }

        [Fact]
        public void Can_Clear_Contents() {
            // Arrange - Create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 50M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 74M };

            //Araange - Create a new cart
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 4);
            target.AddItem(p2, 1);
            target.Clear();

            // Assert
            Assert.Empty(target.Lines);
        }
    }
}
