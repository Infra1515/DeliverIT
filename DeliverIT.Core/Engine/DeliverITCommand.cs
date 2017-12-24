using System.Collections.Generic;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace DeliverIT.Core.Engine
{
    using System;
    using DeliverIT.Core.Contracts;

    /// <summary>
    /// Class for implementation of different commands
    /// </summary>

    public class DeliverITCommand : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string commandName;
        private List<string> parameters;


        public DeliverITCommand(string currLine)
        {
            
        }

        public string CommandName
        {
            get { return this.commandName; }
            private set
            {
                //validation needed
                this.commandName = value;
            }
            
        }
        
        public List<string> Parameters 
        {
            get { return this.parameters; }
            private set
            {
                //validation
                this.parameters = value;
            }
        }

        //private void ExecuteCommand(string input)
        //{
        //    var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
        //    Regex regex = new Regex("{{.+(?=}})}}");

        //    if (indexOfFirstSeparator < 0)
        //    {
        //        this.CommandName = input;
        //        return;
        //    }

        //    this.CommandName = input.Substring(0, indexOfFirstSeparator);

        //    if (indexOfFirstSeparator >= 0)
        //    {
        //        this.Parameters.Add(input.Substring(indexOfFirstSeparator + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
        //        input = regex.Replace(input, string.Empty);
        //    }

        //    this.Parameters.AddRange(input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));
        //}
    }
}
