using ProductReviewManagement;

namespace TestValidation
{
    [TestClass]
    public class UnitTest1
    {
        List<ProductReview> productList;
        [TestInitialize]
        public void SetUp()
        {
            productList = new List<ProductReview>();
        }
        // UC1--->Adding a Productreview details in list and returns the count
        [TestMethod]
        public void TestMethodForAddingDetailsInList()
        {
            int expected = 25;
            int actual = ProductReviewManager.AddingProductReview(productList);
            Assert.AreEqual(expected, actual);
        }
        // UC2--->Retrieve Top Three Records Whose Rating is High
        [TestMethod]
        public void TestMethodForRetrieveTopThreeRecord()
        {
            int expected = 3;

            var actual = ProductReviewManager.RetrieveTopThreeRating(productList);
            Assert.AreEqual(expected, actual);
        }
        // UC3-->Retrieve  records from list based on productid and rating > 3 
        [TestMethod]
        public void TestMethodForRetrieveRecordsBasedOnRatingAndProductId()
        {
            int[] expected = { 1, 4, 9};
            var actual = ProductReviewManager.RetrieveRecordsBasedOnRatingAndProductId(productList);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
