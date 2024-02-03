using CSLibraryExtension;

namespace NUnitTestProgram
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetRomanToInt_Test01()
        {
            // assign
            string s = "CMLII";
         
            // act

            // assert
            Assert.AreEqual(952, CSLib.RomanToInt(s));
        }
    }
}