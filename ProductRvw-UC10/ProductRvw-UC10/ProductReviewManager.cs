using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagement
{
    public class ProductReviewManager
    {
        // UC1-Adding a values in a list
        public static int AddingProductReview(List<ProductReview> products)
        {
            products.Add(new ProductReview() { productId = 1, userId = 1, review = "Good", rating = 14, isLike = true });
            products.Add(new ProductReview() { productId = 2, userId = 2, review = "Average", rating = 12, isLike = true });
            products.Add(new ProductReview() { productId = 3, userId = 4, review = "Good", rating = 19, isLike = true });
            products.Add(new ProductReview() { productId = 2, userId = 5, review = "Bad", rating = 7, isLike = false });
            products.Add(new ProductReview() { productId = 1, userId = 1, review = "Very Good", rating = 19, isLike = true });
            products.Add(new ProductReview() { productId = 2, userId = 6, review = "Average", rating = 10, isLike = true });
            products.Add(new ProductReview() { productId = 4, userId = 7, review = "Good", rating = 15, isLike = true });
            products.Add(new ProductReview() { productId = 9, userId = 8, review = "Average", rating = 11, isLike = true });
            products.Add(new ProductReview() { productId = 3, userId = 9, review = "Bad", rating = 6, isLike = false });
            products.Add(new ProductReview() { productId = 5, userId = 4, review = "Average", rating = 13, isLike = true });
            products.Add(new ProductReview() { productId = 7, userId = 10, review = "Very Good", rating = 18, isLike = true });
            products.Add(new ProductReview() { productId = 9, userId = 5, review = "Very Good", rating = 17, isLike = true });
            products.Add(new ProductReview() { productId = 10, userId = 3, review = "Bad", rating = 9, isLike = false });
            products.Add(new ProductReview() { productId = 1, userId = 2, review = "Bad", rating = 8, isLike = false });
            products.Add(new ProductReview() { productId = 5, userId = 9, review = "Average", rating = 11, isLike = true });
            products.Add(new ProductReview() { productId = 3, userId = 11, review = "Good", rating = 15, isLike = true });
            products.Add(new ProductReview() { productId = 12, userId = 3, review = "Bad", rating = 6, isLike = false });
            products.Add(new ProductReview() { productId = 14, userId = 15, review = "Very Good", rating = 19, isLike = true });
            products.Add(new ProductReview() { productId = 18, userId = 9, review = "Bad", rating = 7, isLike = false });
            products.Add(new ProductReview() { productId = 13, userId = 1, review = "Very Good", rating = 20, isLike = true });
            products.Add(new ProductReview() { productId = 2, userId = 6, review = "Average", rating = 10, isLike = true });
            products.Add(new ProductReview() { productId = 4, userId = 7, review = "Good", rating = 15, isLike = true });
            products.Add(new ProductReview() { productId = 19, userId = 8, review = "Average", rating = 11, isLike = true });
            products.Add(new ProductReview() { productId = 3, userId = 9, review = "Bad", rating = 6, isLike = false });
            products.Add(new ProductReview() { productId = 5, userId = 4, review = "Average", rating = 13, isLike = true });
            //IterateThroughList(products);
            return products.Count;
        }
        // Display the details in list
        public static void IterateThroughList(List<ProductReview> products)
        {
            foreach (ProductReview product in products)
            {
                Console.WriteLine("ProductId:{0}\t UserId:{1}\t Review:{2}\tRating:{3}\tIsLike:{4}\t", product.productId, product.userId, product.review, product.rating, product.isLike);
            }
        }
        // UC2--->Retrieve Top Three Records Whose Rating is High
        public static int RetrieveTopThreeRating(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n-----Retrieving Top Three Records Based On Rating-----");
            var res = (from product in products orderby product.rating descending select product).Take(3).ToList();
            IterateThroughList(res);
            return res.Count;
        }
        // UC3-->Retrieve  records from list based on productid and rating > 3 
        public static int[] RetrieveRecordsBasedOnRatingAndProductId(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n-----Retrieve Records Based On Rating and Product Id-----");
            var res = (from product in products where product.rating > 3 && (product.productId == 1 || product.productId == 4 || product.productId == 9) select product.productId).ToArray();
            return res;
        }
        //  UC4-->Retrived the count of productId
        public static string CountingProductId(List<ProductReview> products)
        {
            string res = null;
            AddingProductReview(products);
            var data = products.GroupBy(x => x.productId).Select(a => new { ProductId = a.Key, count = a.Count() });
            Console.WriteLine(data);
            foreach (var ele in data)
            {
                Console.WriteLine("ProductId " + ele.ProductId + " " + "Count " + " " + ele.count);
                Console.WriteLine("-------------");
                res += ele.ProductId + " " + ele.count + " ";
            }
            return res;
        }
        // UC5---->Retrieving the product id in list
        public static string RetrieveOnlyProductIdAndReviews(List<ProductReview> products)
        {
            string result = null;
            AddingProductReview(products);
            var res = products.Select(product => new { ProductId = product.productId, Review = product.review }).ToList();
            foreach (var ele in res)
            {
                Console.WriteLine("ProductId " + ele.ProductId + " " + "Review " + " " + ele.Review);
                result += ele.ProductId + " ";
            }
            return result;
        }
        // UC6--->Skip Top five records
        public static int SkipTopFiveRecords(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n-----Skip Top Five records in list-----");
            var res = (from product in products orderby product.rating descending select product).Skip(5).ToList();
            IterateThroughList(res);
            return res.Count;
        }
        // UC8-->Using DataTable
        public static DataTable CreateDataTable(List<ProductReview> products)
        {
            AddingProductReview(products);
            DataTable dt = new DataTable();
            dt.Columns.Add("productId");
            dt.Columns.Add("userId");
            dt.Columns.Add("rating");
            dt.Columns.Add("review");
            dt.Columns.Add("isLike", typeof(bool));

            foreach (var data in products)
            {
                dt.Rows.Add(data.productId, data.userId, data.rating, data.review, data.isLike);
            }
            //IterateTable(dt);
            return dt;
        }
        // Iterate Thorugh Table
        public static void IterateTable(DataTable table)
        {
            foreach (DataRow p in table.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
            }
        }
        // UC9-retrieve the records whose column islike has true using (DataTable)
        public static int ReturnsOnlyIsLikeFieldAsTrue()
        {
            List<ProductReview> products = new List<ProductReview>();
            DataTable table = CreateDataTable(products);
            int count = 0;
            var res = from t in table.AsEnumerable() where t.Field<bool>("isLike") == true select t;
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
                count++;
            }
            return count;
        }
        // Finding the average rating value
        public static double AverageOfRating()
        {
            List<ProductReview> products = new List<ProductReview>();
            DataTable table1 = CreateDataTable(products);
            double result = (double)table1.Select().Where(p => p["rating"] != DBNull.Value).Select(c => Convert.ToDecimal(c["rating"])).Average();
            Console.WriteLine(result);
            return result;
        }
    }
}