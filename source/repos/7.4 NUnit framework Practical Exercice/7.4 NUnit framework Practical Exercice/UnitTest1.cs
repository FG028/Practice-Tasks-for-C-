using System;
using NUnit.Framework;

namespace _7._4_NUnit_framework_Practical_Exercise
{
    public class AssertionsTest
    {
        [Test]
        public void IdenticalStringsAreEqual() 
        {
            var string1 = "Hello";
            var string2 = "Hello";

            Assert.AreEqual(string1, string2); // Classic model
            Assert.That (string1, Is.EqualTo(string2)); //Constraint model
        }

        [Test]
        public void IdenticalListAreEqual()
        {
            var list1 = new List<string> { "a", "b", "c"};
            var list2 = new List<string> { "a", "b", "c" };

            Assert.AreEqual(list1, list2);
            CollectionAssert.AreEquivalent(list1, list2);
            Assert.That(list1, Is.EqualTo(list2));
        }

        [Test]
        public void StringInList()
        {
            var a = 10;
            var b = 5;

            Assert.IsTrue(a > b);
            Assert.That(a > b);
        }
    }
}