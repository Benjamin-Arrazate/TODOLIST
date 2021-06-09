using System;

namespace TODOLIST
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TodoCRUD Operations = new TodoCRUD();



            string opcion = "";
            while (opcion != "5")
            {

                opcion = "";
                while (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6")
                {   
                    Console.WriteLine("1) Create a To-Do");
                    Console.WriteLine("2) Print To-Do´s");
                    Console.WriteLine("3) Mark as Complete/Incomplete");
                    Console.WriteLine("4) Delete a To-Do´s");
                    Console.WriteLine("5) Export");
                    Console.WriteLine("6) Exit");


                    Console.WriteLine("Please Select an Option");
                    opcion = Console.ReadLine();

                    if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6")
                    {
                        Console.WriteLine("This option is incorrect");
                    }
                }


                if (opcion == "1")
                {
                    Console.WriteLine("Type a new To-Do");
                    string description = Console.ReadLine(); 
                    Operations.Create(description);

                }
                else if (opcion == "2")
                {
                    Operations.Read();  
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("Type the ID of the To-Do you want to Update");

                    string id = Console.ReadLine();
                    
                    Operations.Update(Int32.Parse(id)); 
                }
                else if (opcion == "4")
                {
                    Console.WriteLine("Type the ID of the To-Do you want to delete");
                    
                    string id = Console.ReadLine();

                    Operations.Delete(Int32.Parse(id)); 
                }
                else if (opcion == "5")
                {
                    Operations.Export();
                }
                else if (opcion == "6")
                {
                    Console.WriteLine("See you later Alligator!");
                }

            }
        }

    }

}
