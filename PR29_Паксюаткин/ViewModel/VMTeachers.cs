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
    public class VMTeachers : INotifyPropertyChanged
    {


        public ObservableCollection<Teachers> Items { get; set; }

        public Classes.RelayCommand NewItem
        {
            get
            {
                return new Classes.RelayCommand(obj =>
                {
                    Teachers _teachers = new()
                    {
                        Id = 0,
                        Name = "",
                        CoursesId = 0,
                    };
                    VMTeachersAdd newModell = new(_teachers, new TeachersContext());
                    MainWindow.init?.frame.Navigate(new View.Teachers.Add(newModell));
                });
            }
        }

        public VMTeachers()
        {
            using CoursesContext coursesContext = new CoursesContext();
            Items = new ObservableCollection<Teachers>(
                TeachersContext.AllTeachers()
                    .Select(x => {
                        Courses? SelectedCourses = coursesContext.Courses.FirstOrDefault(_courses => _courses.Id == x.CoursesId);
                        x.Courses = SelectedCourses;
                        return x;
                    })
            );
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
