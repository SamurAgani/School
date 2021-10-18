using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SchoolApp.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class MainVM : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private Messenger messenger;

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        public MainVM()
        {
            messenger = App.Container.GetInstance<Messenger>();
            messenger.Register<ViewChange>(this, x =>
            {
                CurrentViewModel = x.ViewModel;
            });
            CurrentViewModel = App.Container.GetInstance<SignInVM>();
        }
    }
}
