using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class VMCourses : INotifyPropertyChanged
    {
        public ObservableCollection<Courses> Items { get; set; }

        public Classes.RelayCommand NewItem
        {
            get
            {
                return new Classes.RelayCommand(obj =>
                {
                    Courses _courses = new()
                    {
                        Id = 0,
                        Title = "",
                        Date = DateTime.Now,
                        Time = TimeSpan.Zero,
                    };
                    VMCoursesAdd newModell = new(_courses, new CoursesContext());
                    MainWindow.init?.frame.Navigate(new View.Courses.Add(newModell));
                });
            }
        }

        public VMCourses() => Items = Context.CoursesContext.AllCourses();

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
