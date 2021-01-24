using System;

using Xunit;
using Xunit.Abstractions;


namespace BMTest.Engine.Tests.UnitTests.Core
{
    public class TestClassTests
    {
        #region Fields
        private readonly ITestOutputHelper _output;
        #endregion _Fields

        
        #region Ctors
        public TestClassTests(ITestOutputHelper output)
        {
            _output = output;
        }
        #endregion

        
        #region Test Methods
        [Fact]
        public void PingMethod_ReturnsPongForPing()
        {
            var result = TestClass.PingMethod(@"ping");
            
            Assert.Equal(TestClass.PongMessage, result);
            
            _output.WriteLine(result ?? "NULL");
        }
        
        
        [Fact]
        public void PingMethod_ReturnsNullForNonPing()
        {
            var result = TestClass.PingMethod(@"noping");
            
            Assert.NotEqual(TestClass.PongMessage, result);
            Assert.Null(result);

            _output.WriteLine(result ?? "NULL");
        }
        
        
        [Fact]
        public void PingMethod_ArgumentNullExceptionForNullArgument()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => TestClass.PingMethod(null!));
            
            _output.WriteLine(exception.Message);
        }
        #endregion _Test Methods
    }
}