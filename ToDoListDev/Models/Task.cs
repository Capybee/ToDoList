using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ToDoListDev.Repository;

namespace ToDoListDev.Models;

public partial class Task : INotifyPropertyChanged
{
    private int _Id;
    public int Id
    {
        get { return _Id; }
        set { _Id = value; OnPropertyChanged(nameof(Id));}
    }

    private string _Title = null!;
    public string Title 
    {
        get { return _Title; }
        set { _Title = value; OnPropertyChanged(nameof(Title)); } 
    }

    private string _Description = null!;
    public string Description 
    {
        get { return _Description; }
        set { _Description = value; OnPropertyChanged(nameof(Description)); } 
    }

    private string _CreateDate = null!;
    public string CreateDate 
    {
        get { return _CreateDate; }
        set { _CreateDate = value; OnPropertyChanged(nameof(CreateDate)); } 
    }

    private string _CompletionDate = null!;
    public string CompletionDate 
    {
        get { return _CompletionDate; }
        set { _CompletionDate = value; OnPropertyChanged(nameof(CompletionDate)); } 
    }

    private int _IsFinal;
    public int IsFinal 
    {
        get { return _IsFinal; }
        set { _IsFinal = value ; OnPropertyChanged(nameof(IsFinal));} 
    }

    private bool _IsFinalBool;
    [NotMapped]
    public bool IsFinalBool
    {
        get { return _IsFinalBool; }
        set { _IsFinalBool = value; OnPropertyChanged(nameof(IsFinalBool)); DBController.IsFinalChange(Id, IsFinalBool); }
    }


    public Task() {}

    public Task(string InputTitle, string InputDescription, string InputCreateDate, string InputCompletionDate)
    {
        Title = InputTitle;
        Description = InputDescription;
        CreateDate = InputCreateDate;
        CompletionDate = InputCompletionDate;
        IsFinal = 0;
    }
    public override bool Equals(object? obj)
    {
        if(obj is Task other)
        {
            return this.Title == other.Title && this.Description == other.Description && this.IsFinal == other.IsFinal;
        }
        else
        {
            return false;
        } 
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Description, IsFinal);
    }

    public static bool operator ==(Task LeftTask, Task RightTask)
    {
        return LeftTask.Title == RightTask.Title && LeftTask.Description == RightTask.Description && LeftTask.IsFinal == RightTask.IsFinal;
    }

    public static bool operator !=(Task LeftTask, Task RightTask)
    {
        return !(LeftTask == RightTask);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
