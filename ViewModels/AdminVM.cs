using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class AdminVM : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private RelayCommand addClassCommand;
        private RelayCommand addStudentCommand;
        private RelayCommand addTeacherCommand;
        private RelayCommand studentsCommand;
        private RelayCommand addTopicCommand;
        private RelayCommand addTopicToClassCommand;

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }
        public AdminVM()
        {
            CurrentViewModel = App.Container.GetInstance<StudentsVM>();
        }

        public RelayCommand StudentsCommand => studentsCommand ?? (studentsCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<StudentsVM>();
        }));

        public RelayCommand AddClassCommand => addClassCommand ?? (addClassCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<AddClassVM>();
        }));

        public RelayCommand AddStudentCommand => addStudentCommand ?? (addStudentCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<AddStudentVM>();
        }));
        public RelayCommand AddTopicCommand => addTopicCommand ?? (addTopicCommand = new RelayCommand(() =>
         {
             CurrentViewModel = App.Container.GetInstance<AddTopicVM>();
         }));

        public RelayCommand AddTeacherCommand => addTeacherCommand ?? (addTeacherCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<AddTeacherVM>();
        }));

        public RelayCommand AddTopicToClassCommand => addTopicToClassCommand ?? (addTopicToClassCommand = new RelayCommand(() =>
        {
            CurrentViewModel = App.Container.GetInstance<AddTepoicToClassVM>();
        }));

    }
}
