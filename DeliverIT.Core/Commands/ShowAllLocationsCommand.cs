using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DeliverIT.Contracts;
using DeliverIT.Core.Contracts;
using DeliverIT.Core.IOUtilities.Contracts;
using DeliverIT.Models.Countries;

namespace DeliverIT.Core.Commands
{
    public class ShowAllLocationsCommand : ICommand
    {
        public string Execute()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("--- Delivery locations ---");

            var countries = FindDerivedTypes(Assembly.GetAssembly(typeof(ICountry)), typeof(Country));
            foreach (var country in countries)
            {
                strBuilder.AppendLine($" -- {country.Name}");
            }

            return strBuilder.ToString();
        }

        public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }
    }
}
