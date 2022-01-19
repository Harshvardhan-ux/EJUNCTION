using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductInitialiser : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }
        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category {CategoryID = 1, CategoryName = "Cars" },
                new Category {CategoryID = 2, CategoryName = "Planes" },
                new Category {CategoryID = 3, CategoryName = "Trucks" },
                new Category {CategoryID = 4, CategoryName = "Boats" },
                new Category {CategoryID = 5, CategoryName = "Rockets" }
            };
            return categories;
        }
        private static List<Product> GetProducts()
        {
            var products=new List<Product>
            {
                new Product {ID = 1, ProductName = "BMW M3 COUPE ", Description = "This car is fast! The engine is powered by a neutrino based battery.", ImagePath = "c1.jpeg", UnitPrice = 222.50, CategoryID = 1},
                new Product {ID = 2, ProductName = "Old-time Car", Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.", ImagePath = "c2.jpeg", UnitPrice = 155.95, CategoryID = 1},
                new Product {ID = 3, ProductName = "Innovador Porsche 911 GT3 RSR", Description = "Yes this car is fast, but it also floats in water.", ImagePath = "c3.jpeg", UnitPrice = 332.99, CategoryID = 1},
                new Product {ID = 4, ProductName = " BMW F32 4 Series Coupe M Sports ", Description = "Use this super fast car to entertain guests. Lights and doors work!", ImagePath = "c4.jpeg", UnitPrice = 788.95, CategoryID = 1},
                new Product {ID = 5, ProductName = "Old Style Racer", Description = "This old style racer can fly (with user assistance). Gravity controls flight duration." + "No batteries required", ImagePath = "p1.jpeg", UnitPrice = 34.95, CategoryID = 1},
                new Product {ID = 6, ProductName = "Ace Plane", Description ="Authentic airplane toy. Features realistic color and details.", ImagePath = "p2.jpeg", UnitPrice = 95.00, CategoryID = 2},
                new Product {ID = 7, ProductName = "Glider", Description ="This fun glider is made from real balsa wood. Some assembly required", ImagePath = "p3.jpeg", UnitPrice = 4.95, CategoryID = 2},
                new Product {ID = 8, ProductName = "Paper Plane", Description ="This paper plane is like no other plane. Some folding required", ImagePath = "p4.jpeg", UnitPrice = 2.95, CategoryID = 2},
                new Product {ID = 9, ProductName = "Propeller Plane", Description ="Rubber band powered plane features two wheels.", ImagePath = "p5.jpeg", UnitPrice = 32.95, CategoryID = 2},
                new Product {ID = 10, ProductName = "JCB TRACTOR RIDE ON", Description ="This toy truck has a real gas powerd engine. Requires regular tune ups.", ImagePath = "t1.jpeg", UnitPrice = 15.00, CategoryID = 3},
                new Product {ID = 11, ProductName = "Dinotrux Load Luggin Ton-ton", Description ="You will have endless fun with this one quarter sized fire truck.", ImagePath = "t2.jpeg", UnitPrice = 26.00, CategoryID = 3},
                new Product {ID = 12, ProductName = "JCB 7 EXCAVATOR", Description ="This fun toy truck can be used to tow other trucks that are not as big.", ImagePath = "t3.jpeg", UnitPrice = 29.00, CategoryID = 3},
                new Product {ID = 13, ProductName = "Big Ship", Description ="Is it a boat or a ship. Let this floating vehicle decide by using its artifically intelligent computer brain!", ImagePath = "b4.jpeg", UnitPrice = 95.00, CategoryID = 4},
                new Product {ID = 14, ProductName = "Paper Boat", Description ="Floating fun for all! This toy boat can be assembled in seconds Floats for minutes! Some folding required", ImagePath = "b3.jpeg", UnitPrice = 4.95, CategoryID = 4},
                new Product {ID = 15, ProductName = "Sail Boat", Description ="Put this fun toy sail boat in the water and let it go!", ImagePath = "b1.jpeg", UnitPrice = 42.95, CategoryID = 4},
                new Product {ID = 16, ProductName = "Rocket", Description ="This fun rocket will travel up to height of 200 feet.", ImagePath = "b2.jpeg", UnitPrice = 122.95, CategoryID = 5}
            };
            return products;
        }
    }
}