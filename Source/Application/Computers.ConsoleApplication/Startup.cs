﻿using System;
using Computers.Models.ComputerTypes;
using Computers.Models.Manufacturers;

namespace Computers.ConsoleApplication
{
    internal class Startup
    {
        private const string InvalidCommandMessage = "Invalid command!";
        private const string ExitCommandName = "Exit";
        private const string ChargeCommandName = "Charge";
        private const string ProcessCommandName = "Process";
        private const string PlayCommandName = "Play";

        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        private static void Main()
        {
            CreateComputers();
            ProcessCommands();
        }

        private static void CreateComputers()
        {
            var manufacturerFactory = new ManufacturersFactory();

            var manufacturerName = Console.ReadLine();
            IComputerFactory computerFactory =
                manufacturerFactory.GetManufacturer(manufacturerName);

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    break;
                }

                if (userInput.StartsWith(ExitCommandName))
                {
                    break;
                }

                var commandParts = userInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParts.Length != 2)
                {
                    throw new ArgumentException(InvalidCommandMessage);
                }

                var commandName = commandParts[0];
                var commandArgument = int.Parse(commandParts[1]);

                if (commandName == ChargeCommandName)
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommandName)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommandName)
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine(InvalidCommandMessage);
                }
            }
        }
    }
}
