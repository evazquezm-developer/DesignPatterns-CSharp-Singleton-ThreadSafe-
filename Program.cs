using System;
using DesignPatterns;

class Program {

    /// <summary>
    /// 
    /// </summary>
    static void Main() {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        var result = object.ReferenceEquals(logger1, logger2);

        Console.WriteLine($"logger1 == logger2 ? {result}");

        logger1.Log("This is the first message.");
        logger2.Log("This is the second message.");
    }
}