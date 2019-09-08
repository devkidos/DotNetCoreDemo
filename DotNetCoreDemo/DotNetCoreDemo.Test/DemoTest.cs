using DotNetCoreDemo.Entities;
using DotNetCoreDemo.Service;
using NUnit.Framework;

namespace Tests
{
    public class DemoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var demoService = new DemoService();
            var result = demoService.Add(5, 5);

            Assert.AreEqual(10, result);
        } 

    }
}