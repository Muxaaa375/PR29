using Microsoft.Extensions.Logging;
using PR29_Паксюаткин.Context;
using PR29_Паксюаткин.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PR29_Паксюаткин.ViewModel
{
    public class VMCoursesAdd : INotifyPropertyChanged
    {
        public Courses item { get; set; }
        public CoursesContext context { get; set; }

        public VMCoursesAdd(Courses Item, CoursesContext Context)
        {
            item = Item;
            context = Context;
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
