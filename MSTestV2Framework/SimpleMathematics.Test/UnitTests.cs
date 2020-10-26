using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMathematics.Test
{
    [TestClass]
    public class UnitTests
    {

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            Console.WriteLine("Runs before all the tests.");
        }
        [ClassCleanup]
        public static void ClassCleanupMethod()
        {
            Console.WriteLine("Runs after all the tests.");
        }
        [TestInitialize]
        public void TestInitializeMethod()
        {
            Console.WriteLine("Runs before each and every test in the class.");
        }
        [TestCleanup]
        public void TestCleanupMethod()
        {
            Console.WriteLine("Runs after each and every test in the class.");
        }
        [TestMethod]
        [TestCategory("AssertTests")]
        public void AssertTests()
        {
            Assert.AreEqual(10.0, 10.0);
            Assert.AreNotEqual(10.0, 10.2);
            Assert.AreSame(this, this);
            Assert.AreNotSame(this, null);
            //Assert.Equals(this, this); //throws error. Should not be used
            try
            {
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {

            }
            try
            {
                Assert.Inconclusive();
            }
            catch (AssertInconclusiveException ex)
            {

            }
            Assert.IsFalse(false);
            Assert.IsInstanceOfType((int)1, typeof(int));
            Assert.IsNotInstanceOfType("Hello", typeof(int));
            Assert.IsNotNull(1);
            Assert.IsNull(null);
            var stringWONullChars = Assert.ReplaceNullChars("Some input string with null chars");
            Assert.ThrowsException<AssertFailedException>(() => { throw new AssertFailedException(); });
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void StringAssertTests()
        {
            StringAssert.Contains("Hello World", "World");
            StringAssert.DoesNotMatch("Hello World", new System.Text.RegularExpressions.Regex(".*Earth"));
            StringAssert.EndsWith("Hello World", "World");
            StringAssert.Matches("Hello World", new System.Text.RegularExpressions.Regex(".*"));
            StringAssert.StartsWith("Hello World", "Hello");
        }
        [TestMethod]
        public void CollectionAssertTests()
        {
            List<int> collections = new List<int> { 1, 2, 3 };
            CollectionAssert.AllItemsAreInstancesOfType(collections, typeof(int));
            CollectionAssert.AllItemsAreNotNull(collections);
            CollectionAssert.AllItemsAreUnique(collections);
            CollectionAssert.AreEqual(collections, new List<int> { 1, 2, 3 });
            CollectionAssert.AreEquivalent(collections, new List<int> { 3, 2, 1 });
            CollectionAssert.AreNotEqual(collections, new List<int> { 3, 2, 1 });
            CollectionAssert.AreNotEquivalent(collections, new List<int> { 3, 2 });
            CollectionAssert.Contains(collections, 1);
            CollectionAssert.DoesNotContain(collections, 4);
            CollectionAssert.IsSubsetOf(new List<int> { 2, 3 }, collections);
            CollectionAssert.IsNotSubsetOf(new List<int> { 4, 3 }, collections);
        }
        [Ignore]
        [TestMethod]
        public void IgnoreTest()
        {

        }

        [TestMethod]
        [Timeout(100)]
        public void TimeOutTest()
        {
            Thread.Sleep(1000);
        }


        [TestMethod()]
        [TestProperty("MyProperty1", "Big")]
        public void MyTestMethod()
        {
            Type t = GetType();
            MethodInfo mi = t.GetMethod("MyTestMethod");
            Type MyType = typeof(TestPropertyAttribute);
            object[] attributes = mi.GetCustomAttributes(MyType, false);

            for (int i = 0; i < attributes.Length; i++)
            {
                string name = ((TestPropertyAttribute)attributes[i]).Name;
                string val = ((TestPropertyAttribute)attributes[i]).Value;

                string mystring = string.Format("Property Name: {0}, Value: {1}", name, val);
                Console.WriteLine(mystring);
            }
        }
    }
}
