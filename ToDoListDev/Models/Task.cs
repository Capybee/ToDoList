using System;
using System.Collections.Generic;

namespace ToDoListDev.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string CompletionDate { get; set; } = null!;

    public int IsFinal { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is Task other)
        {
            return this.Title == other.Title && this.Description == other.Title && this.IsFinal == other.IsFinal;
        }
        else
        {
            return false;
        } 
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Description, Title, IsFinal);
    }

    public static bool operator ==(Task LeftTask, Task RightTask)
    {
        return LeftTask.Title == RightTask.Title && LeftTask.Description == RightTask.Title && LeftTask.IsFinal == RightTask.IsFinal;
    }

    public static bool operator !=(Task LeftTask, Task RightTask)
    {
        return !(LeftTask == RightTask);
    }
}
