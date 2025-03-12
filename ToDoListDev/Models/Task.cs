using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        set { _IsFinal = value; OnPropertyChanged(nameof(IsFinal)); } 
    }

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

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
