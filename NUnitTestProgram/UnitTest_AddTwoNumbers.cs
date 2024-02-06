using CSLibraryExtension.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProgram
{
    public class UnitTest_AddTwoNumbers
    {
        ListNode l1, l2;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test] public void Test_l1HighLength()
        {
            // setup
            l1 = new ListNode() // l1 = [9,9,9]
            {
                val = 9,
                next = new ListNode()
                {
                    val = 9,
                    next = new ListNode()
                    {
                        val = 9,
                        next = null
                    }
                }
            };
            l2 = new ListNode() // l2 = [9,9]
            {
                val = 9,
                next = new ListNode()
                {
                    val = 9,
                    next = null
                }
            };

            // assign
            ListNode lAct = AddTwoNumbersSolution.AddTwoNumbers(l1, l2);

            // act
            StringBuilder ints = new StringBuilder();
            while (lAct != null)
            {
                ints.Append($"{lAct.val} ");
                lAct = lAct.next;
            }
            // assert
            Assert.AreEqual("8 9 0 1 ", ints.ToString());

        }

        [Test]
        public void Test_l2HighLength()
        {
            // setup
            l1 = new ListNode() // l1 = [9,9]
            {
                val = 9,
                next = new ListNode()
                {
                    val = 9,
                    next = null
                }
            };
            l2 = new ListNode() // l2 = [9,9,9]
            {
                val = 9,
                next = new ListNode()
                {
                    val = 9,
                    next = new ListNode()
                    {
                        val = 9,
                        next = null
                    }
                }
            };

            // assign
            ListNode lAct = AddTwoNumbersSolution.AddTwoNumbers(l1, l2);

            // act
            StringBuilder ints = new StringBuilder();
            while (lAct != null)
            {
                ints.Append($"{lAct.val} ");
                lAct = lAct.next;
            }
            // assert
            Assert.AreEqual("8 9 0 1 ", ints.ToString());

        }
    }
}
