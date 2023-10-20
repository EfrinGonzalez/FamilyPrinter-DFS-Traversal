
using System.Collections.Generic;
using FamilyPrinter; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FamilyPrinter.Services;

namespace FamilyPrinterTest
{    
    [TestClass]
    public class FamilyPrinterTests
    {
        IFamilyPrinter familyPrinter;
        [TestInitialize]
        public void TestInitialize()
        {
           familyPrinter = new FamilyPrinterService();

        }


        [TestMethod]
        public void TestPrintFamilyTreeForGrandDad()
        {            
            // Arrange
            Ancestor GrandDad = new Ancestor
            {
                Name = "GrandDad",
                Children = new List<Person> {
                    new Child { Name = "Aunt" },
                    new Child { Name = "Uncle" },
                    new Parent {
                        Name = "Dad",
                        Children = new List<Person> {
                            new Child { Name = "Me" },
                            new Child { Name = "Sister" }
                        }
                    }
                }
            };

            string expectedOutput = "*GrandDad\n  -Aunt\n  -Uncle\n  *Dad\n    -Me\n    -Sister\n";
            // Act
            string result = familyPrinter.Print(GrandDad);
            Console.WriteLine(result);
            // Assert
            Assert.AreEqual(expectedOutput, result);       

        }



        [TestMethod]
        public void TestPrintFamilyTreeForGreatGrandDad()
        {
            // Arrange
            Ancestor GreatGrandDad = new Ancestor
            {
                Name = "GreatGrandDad",
                Children = new List<Person> {
                    new Parent {
                        Name = "GrandDad",
                        Children = new List<Person> {
                            new Parent {
                                Name = "Dad",
                                Children = new List<Person> {
                                    new Child { Name = "Me" }
                                }
                            }
                        }
                    }
                }
            };

            string expectedOutput = "*GreatGrandDad\n  *GrandDad\n    *Dad\n      -Me\n";

            // Act           
            string result = familyPrinter.Print(GreatGrandDad);
            Console.WriteLine(result);
            // Assert
            Assert.AreEqual(expectedOutput, result);
        }


        [TestMethod]
        public void TestPrintFamilyTreeForGreatGreatGranddad()
        {
            // Arrange
            Ancestor GreatGreatGranddad = new Ancestor
            {
                Name = "GreatGreatGranddad",
                Children = new List<Person> {
                    new Parent {
                        Name = "GreatGranddad1",
                        Children = new List<Person> {
                            new Parent {
                                Name = "Granddad1",
                                Children = new List<Person> {
                                    new Parent {
                                        Name = "Dad",
                                        Children = new List<Person> {
                                            new Child { Name = "Me" },
                                            new Child { Name = "MySister" },
                                            new Child { Name = "MyBrother" }
                                        }
                                    },
                                    new Parent {
                                        Name = "Uncle",
                                        Children = new List<Person> {
                                            new Child { Name = "Cousin1" },
                                            new Child { Name = "Cousin2" }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            string expectedOutput = "*GreatGreatGranddad\n" +
                                    "  *GreatGranddad1\n" +
                                    "    *Granddad1\n" +
                                    "      *Dad\n" +
                                    "        -Me\n" +
                                    "        -MySister\n" +
                                    "        -MyBrother\n" +
                                    "      *Uncle\n" +
                                    "        -Cousin1\n" +
                                    "        -Cousin2\n";

            // Act          
            string result = familyPrinter.Print(GreatGreatGranddad);
            Console.WriteLine(result);
            // Assert
            Assert.AreEqual(expectedOutput, result);
        }



        [TestMethod]
        public void TestPrintFamilyTreeSeveralLevels()
        {
                Ancestor myAncestor = new Ancestor
                {
                    Name = "GreatGreatGrandparent",
                    Children = new List<Person>
        {
            new Parent
            {
                Name = "GreatGrandparent1",
                Children = new List<Person>
                {
                    new Parent
                    {
                        Name = "Grandparent1",
                        Children = new List<Person>
                        {
                            new Parent
                            {
                                Name = "Parent1",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child1" },
                                    new Child { Name = "Child2" }
                                }
                            },
                            new Parent
                            {
                                Name = "Parent2",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child3" },
                                    new Child { Name = "Child4" }
                                }
                            }
                        }
                    },
                    new Parent
                    {
                        Name = "Grandparent2",
                        Children = new List<Person>
                        {
                            new Parent
                            {
                                Name = "Parent3",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child5" },
                                    new Child { Name = "Child6" }
                                }
                            },
                            new Parent
                            {
                                Name = "Parent4",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child7" },
                                    new Child { Name = "Child8" }
                                }
                            }
                        }
                    },
                    new Parent
                    {
                        Name = "Grandparent3",
                        Children = new List<Person>
                        {
                            new Parent
                            {
                                Name = "Parent5",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child9" },
                                    new Child { Name = "Child10" }
                                }
                            },
                            new Parent
                            {
                                Name = "Parent6",
                                Children = new List<Person>
                                {
                                    new Child { Name = "Child11" },
                                    new Child { Name = "Child12" }
                                }
                            }
                        }
                    }
                }
            },
            new Parent
            {
                Name = "GreatGrandparent2",
                Children = new List<Person>
                {
                    new Parent
                    {
                        Name = "Grandparent4",
                        Children = new List<Person>
                        {
                            new Child { Name = "Child13" },
                            new Child { Name = "Child14" }
                        }
                    }
                }
            }
        }
                };


            string expected = "*GreatGreatGrandparent\n" +
                           "  *GreatGrandparent1\n" +
                           "    *Grandparent1\n" +
                           "      *Parent1\n" +
                           "        -Child1\n" +
                           "        -Child2\n" +
                           "      *Parent2\n" +
                           "        -Child3\n" +
                           "        -Child4\n" +
                           "    *Grandparent2\n" +
                           "      *Parent3\n" +
                           "        -Child5\n" +
                           "        -Child6\n" +
                           "      *Parent4\n" +
                           "        -Child7\n" +
                           "        -Child8\n" +
                           "    *Grandparent3\n" +
                           "      *Parent5\n" +
                           "        -Child9\n" +
                           "        -Child10\n" +
                           "      *Parent6\n" +
                           "        -Child11\n" +
                           "        -Child12\n" +
                           "  *GreatGrandparent2\n" +
                           "    *Grandparent4\n" +
                           "      -Child13\n" +
                           "      -Child14\n";



            string result = familyPrinter.Print(myAncestor);
            Console.WriteLine(result);

            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }
    }
}
