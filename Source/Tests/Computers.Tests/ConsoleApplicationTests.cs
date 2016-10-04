using System;
using System.IO;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class ConsoleApplicationTests
    {
        private const string TestInput = "HP\r\n" + "Charge 10\r\n";
        private const string TestOutput = "Battery status: 60%\r\n";

        [Test]
        public void TestPlayCommand()
        {
            using (StringReader input = new StringReader(TestInput))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);
                    ConsoleApplication.Startup.Main();

                    Assert.AreEqual(TestOutput, output.ToString());
                }
            }
        }
    }
}
