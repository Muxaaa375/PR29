using Microsoft.EntityFrameworkCore;
using PR29_Паксюаткин.Classes.Common;
using PR29_Паксюаткин.Classes;
using System.Collections.ObjectModel;
using PR29_Паксюаткин.Model;

namespace PR29_Паксюаткин.Context
{
    public class TeachersContext : DbContext
    {
        public DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);

        public TeachersContext() => Database.EnsureCreated();
        public static ObservableCollection<Teachers> AllTeachers()
        {
            using TeachersContext context = new();
            return new ObservableCollection<Teachers>([.. context.Teachers]);
        }

        public void Save(Teachers teachersItem, bool isNew)
        {
            using TeachersContext context = new();
            if (isNew)
            {
                context.Teachers.Add(teachersItem);
            }
            else
            {
                teachersItem.Courses = null;
                context.Teachers.Update(teachersItem);
            }
            context.SaveChanges();
        }

        public void Delete(Teachers teachersItem)
        {
            Teachers.Remove(teachersItem);
            SaveChanges();
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Teachers teachersItem)
                    {
                        Save(teachersItem, teachersItem.Id == 0);
                        MainWindow.init?.frame.Navigate(new View.Teachers.Main());
                    }
                });
            }
        }
    }
}
