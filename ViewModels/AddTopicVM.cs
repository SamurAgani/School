using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolApp.ViewModels
{
    class AddTopicVM : ViewModelBase
    {
        private IRepository<Topic> topicRepository;
        private string name;
        private RelayCommand addCommand;

        public AddTopicVM(IRepository<Topic> repository)
        {
            topicRepository = repository;
        }
        public string Name
        {
            get => name;
            set
            { 
                Set(ref name, value);
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(() =>
        {

            if (!topicRepository.GetAll().Any(x => x.Name == Name))
            {
                topicRepository.Add(new Topic()
                {
                    Name = Name
                });
                topicRepository.Save();
                MessageBox.Show("Topic added");
            }
            else MessageBox.Show("The topic has already been added");
            Name = string.Empty;
        }, !string.IsNullOrWhiteSpace(Name)));
    }
}
