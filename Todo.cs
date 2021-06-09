using System;

namespace TODOLIST
{
    class Todo
{
    public int Id;
    public string description; 
    public DateTime date; 
    public bool status;

    public Todo(int Id, string description, DateTime date, bool status)
    {
        this.Id = Id;
        this.description = description;
        this.date = date;
        this.status= status;
    }

}


}
