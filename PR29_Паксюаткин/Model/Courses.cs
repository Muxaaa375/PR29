using PR29_Паксюаткин.Classes;
using PR29_Паксюаткин.Context;
using PR29_Паксюаткин.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PR29_Паксюаткин.Model
{
    public class Courses : INotifyPropertyChanged
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
        private string? _title;
        public string? Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("_title");
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("_date");
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("_time");
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
                return new RelayCommand(coursesItem =>
                {
                    if (coursesItem is Courses coursesObject)
                    {
                        VMCoursesAdd newModel = new(coursesObject, new CoursesContext());
                        MainWindow.init?.frame.Navigate(new View.Courses.Add(newModel));
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
                    if (obj is Courses coursesItem)
                    {
                        using CoursesContext coursesContext = new();
                        coursesContext.Delete(this);
                        MainWindow.init.MainCourses = new View.Courses.Main();
                        MainWindow.init.frame.Navigate(MainWindow.init.MainCourses);
                    }
                });
            }
        }
    }
}
