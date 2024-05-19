using System.Windows.Controls;

namespace PR29_Паксюаткин.View.Teachers
{
    public partial class Add : Page
    {
        public Add(object? Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}
