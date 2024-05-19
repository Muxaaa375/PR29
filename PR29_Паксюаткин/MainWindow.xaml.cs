using System.Windows;

namespace PR29_Паксюаткин
{
    public partial class MainWindow : Window
    {
        public static MainWindow? init;

        public View.Courses.Main MainCourses = new();
        public View.Teachers.Main MainTeachers = new();
        public MainWindow()
        {
            InitializeComponent();

            init = this;
            frame.Navigate(MainCourses);
        }

        private void OpenCourses(object sender, RoutedEventArgs e) =>
            frame.Navigate(MainCourses);

        private void OpenTeachers(object sender, RoutedEventArgs e) =>
            frame.Navigate(MainTeachers);
    }
}
