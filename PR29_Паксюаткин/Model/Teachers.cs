using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

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
    }
}
