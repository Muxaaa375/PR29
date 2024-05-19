﻿using Microsoft.EntityFrameworkCore;
using PR29_Паксюаткин.Classes.Common;
using PR29_Паксюаткин.Classes;
using System.Collections.ObjectModel;
using PR29_Паксюаткин.Model;

namespace PR29_Паксюаткин.Context
{
    public class CoursesContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);

        public CoursesContext() => Database.EnsureCreated();
        public static ObservableCollection<Courses> AllCourses()
        {
            using CoursesContext context = new();
            return new ObservableCollection<Courses>([.. context.Courses]);
        }

        public void Save(Courses сoursesItem, bool isNew)
        {
            using CoursesContext context = new();
            if (isNew)
            {
                context.Courses.Add(сoursesItem);
            }
            else
            {
                context.Courses.Update(сoursesItem);
            }
            context.SaveChanges();
        }

        public void Delete(Courses сoursesItem)
        {
            Courses.Remove(сoursesItem);
            SaveChanges();
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Courses сoursesItem)
                    {
                        Save(сoursesItem, сoursesItem.Id == 0);
                        MainWindow.init?.frame.Navigate(new View.Courses.Main());
                    }
                });
            }
        }
    }
}
