using PR29_Паксюаткин.Classes;
using PR29_Паксюаткин.Context;
using PR29_Паксюаткин.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PR29_Паксюаткин.Model
{
    public class Teachers : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("_id");
            }
        }
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("_name");
            }
        }


        private int _coursesId;
        public int CoursesId
        {
            get { return _coursesId; }
            set
            {
                _coursesId = value;
                OnPropertyChanged("_coursesId");
            }
        }

        private Courses? _courses;
        public Courses? Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged("_courses");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(teachersItem =>
                {
                    if (teachersItem is Teachers teachersObject)
                    {
                        using TeachersContext teachersContext = new();
                        VMTeachersAdd newModel = new(teachersObject, teachersContext);
                        MainWindow.init?.frame.Navigate(new View.Teachers.Add(newModel));
                    }
                });
            }
        }
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Teachers teachersItem)
                    {
                        using TeachersContext teachersContext = new();
                        teachersContext.Delete(this);
                        MainWindow.init.MainTeachers = new View.Teachers.Main();
                        MainWindow.init.frame.Navigate(MainWindow.init.MainTeachers);
                    }
                });
            }
        }


    }
}
