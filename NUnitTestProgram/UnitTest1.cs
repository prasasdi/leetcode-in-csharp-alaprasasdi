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
        public void GetRomanToInt_Test_01()
        {
            // assign
         
            // act

            // assert
            Assert.AreEqual("III", CSLib.IntToRoman(3));
        }
        [Test]
        public void GetRomanToInt_CaseEasyJoinRomans()
        {
            // assign

            // act

            // assert
            Assert.AreEqual("IV", CSLib.IntToRoman(4));
        }
        [Test]
        public void GetRomanToInt_JoinRomansAndOneRoman()
        {
            // assign

            // act

            // assert
            Assert.AreEqual("VI", CSLib.IntToRoman(6));
        }
        [Test]
        public void GetRomanToInt_CaseHardJoinRomans()
        {
            // assign

            // act

            // assert
            Assert.AreEqual("MCMXCIV", CSLib.IntToRoman(1994));
        }
    }
}