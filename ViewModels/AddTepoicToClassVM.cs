using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.ViewModels
{
    class AddTepoicToClassVM : ViewModelBase
    {
        private IRepository<TeacherTopicClass> repository;
        private IRepository<Class> classRepository;
        private IRepository<Topic> topicRepository;
        private IRepository<Teacher> teacherRepository;
        private List<Class> classes;
        private Class selectedClass;
        private List<Topic> topics;
        private Topic selectedTopic;
        private List<Teacher> teachers;
        private Teacher selectedTeacher;
        private TeacherTopicClass selectedTeacherTopic;
        private RelayCommand removeCommand;
        private RelayCommand addCommand;
        private ObservableCollection<TeacherTopicClass> teacherTopics;

        public AddTepoicToClassVM(IRepository<TeacherTopicClass> repository, IRepository<Class> classRepository,
                                    IRepository<Teacher> teacherRepository, IRepository<Topic> topicRepository)
        {
            this.repository = repository;
            this.teacherRepository = teacherRepository;
            this.classRepository = classRepository;
            this.topicRepository = topicRepository;

            Classes = this.classRepository.GetAll().ToList();
            Topics = this.topicRepository.GetAll().ToList();
            Teachers = this.teacherRepository.GetAll().ToList();
            
        }

        public List<Class> Classes { get => classes; set => Set(ref classes, value); }
        public Class SelectedClass
        {
            get => selectedClass;
            set
            {
                Set(ref selectedClass, value);
                if(SelectedClass != null) TeacherTopics = SelectedClass.TeacherTopics;
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        public List<Topic> Topics { get => topics; set => Set(ref topics, value); }
        public Topic SelectedTopic
        {
            get => selectedTopic;
            set
            {
                selectedTopic = value;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public List<Teacher> Teachers { get => teachers; set => Set(ref teachers, value); }
        public Teacher SelectedTeacher
        {
            get => selectedTeacher;
            set
            {
                selectedTeacher = value;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<TeacherTopicClass> TeacherTopics { get => teacherTopics; set => Set(ref teacherTopics, value); }
        public TeacherTopicClass SelectedTeacherTopic
        {
            get => selectedTeacherTopic;
            set
            {
                selectedTeacherTopic = value;
                RemoveCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(() =>
        {
            var db = new TaskContext();
            db.TeacherTopicClass.Remove(db.TeacherTopicClass.FirstOrDefault(x => x.Id == SelectedTeacherTopic.Id));
            db.SaveChanges();
            Classes = db.Classes.ToList();
            SelectedClass = null;
            TeacherTopics = null;
        }, () => SelectedTeacherTopic != null));

        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {
            if (!SelectedClass.TeacherTopics.Any(x => x.Teacher.Id == SelectedTeacher.Id && x.Topic.Id == SelectedTopic.Id))
            {
                var db = new TaskContext();

                db.Classes.FirstOrDefault(x => x.Id == selectedClass.Id).TeacherTopics
                .Add(new TeacherTopicClass()
                {
                    Teacher = db.Teachers.FirstOrDefault(x => x.Id == SelectedTeacher.Id),
                    Topic = db.Topics.FirstOrDefault(x => x.Id == SelectedTopic.Id)
                });
                db.SaveChanges();
                Classes = db.Classes.ToList();
            }
                
        }, () => SelectedClass != null
         && SelectedTopic != null
         && SelectedTeacher != null));
    }
}
