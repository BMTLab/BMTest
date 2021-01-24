using System;
using System.Reflection;

using JetBrains.Annotations;


namespace BMTest.Engine.Sample.Infrastructures.Interceptors
{
    [UsedImplicitly]
    public static class MethodTimeLogger
    {
        [UsedImplicitly]
        public static void Log(MethodBase methodBase, long milliseconds, string? message)
        {
            Console.WriteLine($"{methodBase.Name}: took {milliseconds.ToString()} ms. {message}");
        }
    }
}