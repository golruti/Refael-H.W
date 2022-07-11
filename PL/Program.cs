using System;

namespace PL
{
    class Program
    {
        enum Options { VIEW_ALL = 1, VIEW_TYPE, VIEW_SORTED, ADD, REMOVE, VIEW_SPECIAL, EXIT }
        static public PlService Pl { get; set; } = new PlService();
        static void Main(string[] args)
        {
            while(true)
            {
                PrintMenu();
                Activate();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Press as following:");
            Console.WriteLine("1- View all list");
            Console.WriteLine("2- View list of specific type");
            Console.WriteLine("3- View sorted list");
            Console.WriteLine("4- Add item");
            Console.WriteLine("5- Remove item");
            Console.WriteLine("6- View Item with limited sight and maximal range");
            Console.WriteLine("================================");
        }


        static void Activate()
        {
            Options choice = (Options)int.Parse(Console.ReadLine());

            switch (choice)
            {
                case Options.VIEW_ALL:
                    {
                        Pl.PrintList(Pl.GetList());
                        break;
                    }

                case Options.VIEW_TYPE:
                    {
                        Types t = TypeInput();
                        Pl.PrintList(Pl.GetItemsFromType(t));
                        break;
                    }

                case Options.VIEW_SORTED:
                    {
                        Pl.PrintList(Pl.GetSortedList());
                        break;
                    }

                case Options.ADD:
                    {
                        GetDetailsAndAdd();
                        break;
                    }
                case Options.REMOVE:
                    {
                        Console.WriteLine("Enter type and Id of item:");
                        Types t = TypeInput();
                        int id = int.Parse(Console.ReadLine());
                        Pl.Remove(id, t);
                        break;
                    }
                case Options.VIEW_SPECIAL:
                    {
                        Console.WriteLine("Enter minimum sight:");
                        Pl.PrintItem(Pl.GetLargestRange(DoubleInput()));
                        break;
                    }

                default:
                    break;

            }


            void GetDetailsAndAdd()
            {
                Console.WriteLine("Enter details in this order:");
                Console.WriteLine("Id (a round number),\nType (A/B/C),\nRange (a decimal number),\nSight (a decimal number)");

                int id = int.Parse(Console.ReadLine());
                Types t = TypeInput();
                double range = DoubleInput();
                double sight = DoubleInput();

                Pl.Add(id, t, range, sight);
            }

            Types TypeInput()
            {
                Console.WriteLine("Enter type: 1- A, 2- B, 3- C");
                while (true)
                {
                    int typeNum;
                    int.TryParse(Console.ReadLine(), out typeNum);
                    if (Enum.IsDefined(typeof(Types), typeNum))
                    {
                        return (Types)typeNum;
                    }
                    Console.WriteLine("Input is not valid. Try again.");
                    Console.WriteLine("Enter type: 1- A, 2- B, 3- C");
                }
            }

            double DoubleInput()
            {
                while (true)
                {
                    try
                    {
                        return double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Input is not valid. Try again.");
                    }
                }
            }

        }
    }
}
