using System;

namespace IDEPlugin
{
    public class Plugin
    {
        public string Name { get; } = "Test IDE Plugin";

        public void Initialize()
        {
            Console.WriteLine("Plugin initialized");
        }
    }
}
