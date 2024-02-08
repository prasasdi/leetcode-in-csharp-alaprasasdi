using CSLibraryExtension;
using CSLibraryExtension.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProgram
{
    public class IsPalindromeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test_isPalindromeTrue()
        {
            // assign

            // act

            // assert
            Assert.AreEqual(true, PalindromeNumberSolution.IsPalindrome(1441));
        }

        [Test]
        public void test02_caseMinus()
        {
            // assign

            // act

            // assert
            Assert.AreEqual(false, PalindromeNumberSolution.IsPalindrome(-1441));
        }

        [Test]
        public void test02_caseNotPalindrome()
        {
            // assign

            // act

            // assert
            Assert.AreEqual(false, PalindromeNumberSolution.IsPalindrome(11441));
        }

        [Test]
        public void test_caseOneOnly()
        {
            Assert.AreEqual(true, PalindromeNumberSolution.IsPalindrome(9));
        }

        [Test]
        public void test_oddLength_isPalindromeTrue()
        {
            Assert.AreEqual(true, PalindromeNumberSolution.IsPalindrome(131));
        }

        [Test]
        public void test_oddLength_isPalindromeFalse()
        {
            Assert.AreEqual(false, PalindromeNumberSolution.IsPalindrome(12341));
        }
    }
}
