using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyPrinter.Utils
{
    internal class FamilyTreeUtils
    {
        public static string PrintFamilyTree(Person person, string indentation)
        {
            string result = indentation;

            if (person is Parent)
            {
                result += "*" + person.Name + "\n";
                indentation += "  ";
                /*(person as Parent): This is a type casting operation. 
                 * It attempts to cast the person object to a Parent type. 
                 * If the cast is successful, it returns the Parent object; 
                 * otherwise, it returns null.*/
                foreach (var child in (person as Parent).Children)
                {
                    result += PrintFamilyTree(child, indentation);                   
                }
            }
            else
            {
                result += "-" + person.Name + "\n";
            }

            return result;
        }

    }
}
