using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromicPermutation
{
    [TestClass]
    public class PalindromicPermutationsTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Inputs.csv", "Inputs#csv", DataAccessMethod.Sequential)]
        public void IsTherePalindormicPermutation()
        {
            string input = TestContext.DataRow["Input"].ToString();
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"].ToString());
            Assert.AreEqual(expectedResult, StringAnalyzer.IsPermutationPalindrome(input));
        }
    }
}
