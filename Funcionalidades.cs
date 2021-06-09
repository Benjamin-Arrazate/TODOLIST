using System; 
using System.Collections.Generic; 
using System.IO;

namespace TODOLIST
{
    class TodoCRUD 
    {
        List<Todo> todos = new List<Todo>(); 

        public void Create(string description)
        {
            int id; 
            DateTime currentime = DateTime.Now;
            Boolean status = false;

            id = this.todos.Count == 0 ? 1 : this.todos[this.todos.Count - 1].Id + 1;

            Todo newTodo = new Todo (id, description, currentime, status);
            this.todos.Add(newTodo); 
        }

        public string Delete(int id)
        {
            int index = todos.FindIndex(e => e.Id == id);

            if (index > -1)
            {
                this.todos.RemoveAt(index);
                return "To-do successufully deleted";  
            }
            else
            {
                return "There is no To-do"; 
            }
        }

        public void Update(int id)
        {
            int index = todos.FindIndex(e => e.Id == id); 

            if (index > -1)
            {
                Todo todo = todos[index];
                this.todos[index] = new Todo(todo.Id, todo.description, todo.date, !todo.status);
                Console.WriteLine("To-do successufully updated"); 
            }
            else
            {
                Console.WriteLine("There is no To-do"); 
            }


        }

        public void Read()
        {
            
            if (this.todos.Count == 0)
            {
                Console.WriteLine("There is no To-Do´s");
            }
            else
            {
                List<Todo> todos = this.todos;
                
                todos.Sort(delegate(Todo x, Todo y) {
                    return x.status.CompareTo(y.status);
                }); 

                Console.WriteLine(
                    "ID" + "\t" + 
                    "DATE" + "\t" + 
                    "STATUS" + "\t" + 
                    "DESCRIPTION" + "\t" 
                ); 

                for (int i = todos.Count - 1; i >= 0; i--)
                {
                    string description = todos[i].description;
                    string status = todos[i].status ? "[C]" : "[X]";
                    string date = todos[i].date.ToString("dddd, dd MMMM yyyy");
                    int id = todos[i].Id; 

                    Console.WriteLine(
                        $"{id}" + "\t" + 
                        $"{date}" + "\t" + 
                        $"{status}" + "\t" + 
                        $"{description}" + "\t" 
                    ); 
                }  
                
            }   
                   
        }
        public void Export()
        {
            List<Todo> todos = this.todos;
            List<string> stringList = new List<string>();
                
            todos.Sort(delegate(Todo x, Todo y) {
                return x.status.CompareTo(y.status);
            });


            for (int i = 0; i < todos.Count; i++)
            {
                string description = todos[i].description;
                string status = todos[i].status ? "[C]" : "[X]";
                string date = todos[i].date.ToString("dddd, dd MMMM yyyy");
                int id = todos[i].Id; 
                
                string line = 
                    $"{id}" + "\t" + 
                    $"{date}" + "\t" + 
                    $"{status}" + "\t" + 
                    $"{description}" + "\t";
                
                stringList.Add(line);
            }

            TextWriter tw = new StreamWriter("SaveTodoList.txt");
            
            tw.WriteLine(
                "ID" + "\t" + 
                "DATE" + "\t" + 
                "STATUS" + "\t" + 
                "DESCRIPTION" + "\t" 
            ); 

            for (int i = 0; i < stringList.Count; i++)
            {
                tw.WriteLine(stringList[i]);
            }

            tw.Close();
        }

        
    }
}