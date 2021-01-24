using System;

namespace BMTest.Engine
{
    public static class TestClass
    {
        #region Fields & Consts
        internal const string PongMessage = @"PONG!";
        #endregion _Fields & Consts
        
        
        #region Methods
        public static string? PingMethod(string pingMessage)
        {
            return pingMessage.Equals(@"ping", StringComparison.CurrentCultureIgnoreCase) 
                ? PongMessage 
                : null;
        }
        #endregion
    }
}