using Microsoft.Extensions.Logging;
using PR29_Паксюаткин.Context;
using PR29_Паксюаткин.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PR29_Паксюаткин.ViewModel
{
    public class VMTeachersAdd : INotifyPropertyChanged
    {
        public Teachers item { get; set; }
        public TeachersContext context { get; set; }
        public ObservableCollection<Courses> courses { get; set; }

        public VMTeachersAdd(Teachers Item, TeachersContext Context)
        {
            item = Item;
            context = Context;
            courses = new VMCourses().Items;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
