using lab4;
using System;
using System.Collections.Generic;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.ProcessCommands();
        }
    }
    }