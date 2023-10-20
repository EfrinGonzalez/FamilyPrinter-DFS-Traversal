# Coding challenge

The `FamilyPrinter` project contains some simple definitions of the classes `Person`, `Child`, `Parent` and `Ancestor`.
You are to implement the `Print` method in the `FamilyPrinter` class which, given an instance of the `Ancestor` class, prints the family tree into a string which is to be formatted like the one in the example below.

On this example:

```cs
Ancestor myAncestor =
    new Ancestor { Name = "GrandDad",
        Children = new List<Person> { 
            new Child { Name = "Aunt" },
            new Child { Name = "Uncle" },
            new Parent { Name = "Dad", 
                Children = new List<Person> { 
                    new Child { Name = "Me" }, 
                    new Child { Name = "Sister" } }
            }
        }
    };
```

The `FamilyPrinter.Print(myAncestor)` should return:

```
*GrandDad
  -Aunt
  -Uncle
  *Dad
    -Me
    -Sister
```

Along with that, you are to add tests including the example above and a few more examples of your choice to demonstrate the correctness of the solution.

Note, the result string indentation is relevant, where a child should have +2 space characters of indentation compared to its parent.

Create a Pull Request to the `main` branch with your proposed changes.
