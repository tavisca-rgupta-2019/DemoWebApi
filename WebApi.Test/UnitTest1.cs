using System;
using Xunit;
using WebApi.Controllers;

namespace WebApi.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Respond_hey_Corresponding_to_hi()
        {
            var user = new ValuesController();
            var result = user.Get("hi").Value;
            Assert.Equal("hey", result);
        }
        [Fact]
        public void Respond_hi_Corresponding_to_hey()
        {
            var user = new ValuesController();
            var result = user.Get("hey").Value;
            Assert.Equal("hi", result);
        }
        [Fact]
        public void Respond_ByeGuys_On_Getting_Anything_else_of_hi_Hey()
        {
            var user = new ValuesController();
            var result = user.Get("hello").Value;
            Assert.Equal("Bye Guys", result);
        }

    }
}
