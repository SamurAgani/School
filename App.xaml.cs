using GalaSoft.MvvmLight.Messaging;
using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolApp.Services;
using SchoolApp.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new Container();
            Container.RegisterSingleton<Messenger>();
            Container.RegisterSingleton<SignInVM>();
            Container.RegisterSingleton<MainVM>();
            Container.Register<AddStudentVM>();
            Container.Register<AddTeacherVM>();
            Container.Register<StudentsVM>();
            Container.RegisterSingleton<AddTopicVM>();
            Container.RegisterSingleton<AdminVM>();
            Container.RegisterSingleton<AddClassVM>();
            Container.Register<AddTepoicToClassVM>();

            Container.RegisterSingleton<IRepository<Admin>, AdminRepository>();
            Container.RegisterSingleton<IRepository<Class>, ClassRepository>();
            Container.RegisterSingleton<IRepository<Topic>, TopicRepository>();
            Container.RegisterSingleton<IRepository<Gender>, GenderRepository>();
            Container.RegisterSingleton<IRepository<TeacherTopicClass>, TeacherTopicClassRepository>();
            Container.RegisterSingleton<IRepository<Teacher>, TeacherRepository>();
            Container.RegisterSingleton<IRepository<Student>, StudentRepository>();
            Container.RegisterSingleton<IFindAccount, FindAccount>();
            Container.RegisterSingleton<ICsvService, CsvService>();


            base.OnStartup(e);
        }
    }
}
