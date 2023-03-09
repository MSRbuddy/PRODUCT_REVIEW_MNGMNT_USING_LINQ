using System;
using System.Collections.Generic;
using ProductReviewManagement;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prodcut Review Management Problem UC-1!");
            Console.WriteLine("Adding a Prodcut Review In list");
            Console.WriteLine("Enter Option : ");
            int option = Convert.ToInt32(Console.ReadLine());
            //Creating a list for Product Review
            List<ProductReview> productReviews = new List<ProductReview>();
            switch (option)
            {
                case 1:
                    ProductReviewManager.AddingProductReview(productReviews);
                    break;
            }
        }
    }
}
