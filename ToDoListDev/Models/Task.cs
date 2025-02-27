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
}
