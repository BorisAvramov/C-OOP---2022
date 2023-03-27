using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {

            string [] input = args.Split();
            string commandName = input[0];
            string [] value = input.Skip(1).ToArray();

            //ICommand command = default;

            //Find Type (HelloCommand) by Name)
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command" );

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }
            //Instance
            var command = Activator.CreateInstance(type) as ICommand;



            //if (commandName == "HelloCommand")
            //{
            //    command = new HelloCommand();

            //}
            //else if (commandName == "ExitCommand")
            //{
            //    command = new ExitCommand();
            //}

            string result = command.Execute(value);
            return result;
        }
    }
}
