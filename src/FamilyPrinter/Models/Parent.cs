using System.Collections.Generic;

namespace FamilyPrinter {
    public class Parent : Person {
        public List<Person> Children { get; set; }
    }
}