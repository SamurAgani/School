using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SchoolApp.Messaging;
using SchoolApp.Models;
using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchoolApp.ViewModels
{
    public class SignInVM : ViewModelBase
    {
        private string username;
        private string password;
        private Visibility lableVisibilty;
        private IFindAccount findAccount;
        private Messenger messenger;
        private Admin admin;
        private RelayCommand<object> loginCommand;
        private string lableText;
        private Visibility loadingVisibility;
        private string directory = Directory.GetParent(Directory.GetParent(Directory.GetParent("as").ToString()).ToString()).ToString();
        private Visibility passwordVisibility;
        private Visibility textBoxVisibility;
        private RelayCommand<object> showCommand;

        public string Username
        {
            get => username;
            set
            {
                Set(ref username, value);
                LableVisibilty = Visibility.Hidden;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                Set(ref password, value);
                LableVisibilty = Visibility.Hidden;
            }
        }
        public string LableText { get => lableText; set => Set(ref lableText, value); }
        public Visibility LableVisibilty { get => lableVisibilty; set => Set(ref lableVisibilty, value); }
        public Visibility PasswordVisibility
        {
            get => passwordVisibility;
            set
            {
                Set(ref passwordVisibility, value);
                if (value == Visibility.Visible) TextBoxVisibility = Visibility.Collapsed;
                else TextBoxVisibility = Visibility.Visible;
            }
        }
        public Visibility TextBoxVisibility { get => textBoxVisibility; set => Set(ref textBoxVisibility, value); }
        public Visibility LoadingVisibility { get => loadingVisibility; set => Set(ref loadingVisibility, value); }
        public string BackgroundPath => directory + @"\Images\loginbackground.png";
        public string GifPath => directory + @"\Images\circle3.gif";
        public SignInVM(IFindAccount findAccount)
        {
            LableVisibilty = Visibility.Collapsed;
            LoadingVisibility = Visibility.Collapsed;
            this.findAccount = findAccount;
            messenger = App.Container.GetInstance<Messenger>();
            PasswordVisibility = Visibility.Visible;

        }

        public RelayCommand<object> ShowCommand => showCommand ?? (showCommand = new RelayCommand<object>((x) =>
        {
            var passwordBox = x as PasswordBox;
            
            if (PasswordVisibility == Visibility.Visible)
            {
                PasswordVisibility = Visibility.Collapsed;
                Password = passwordBox.Password;
            }
            else
            {
                PasswordVisibility = Visibility.Visible;
                passwordBox.Password = Password;

            }
        }));
        public RelayCommand<object> LoginCommand => loginCommand ?? (loginCommand = new RelayCommand<object>((x) =>
        {
            var passwordBox = x as PasswordBox;
            if (PasswordVisibility == Visibility.Visible) Password = passwordBox.Password;
            if (string.IsNullOrWhiteSpace(Username))
            {
                LableText = "Enter username";
                LableVisibilty = Visibility.Visible;
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                LableText = "Enter password";
                LableVisibilty = Visibility.Visible;
            }
            else
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    LoadingVisibility = Visibility.Visible;
                    admin = findAccount.FindAdmin(Username, Password);
                    if (admin != null)
                    {
                        LableVisibilty = Visibility.Collapsed;
                        messenger.Send(new AdminChange() { Admin = admin });
                        messenger.Send(new ViewChange() { ViewModel = App.Container.GetInstance<AdminVM>() });
                    }
                    else
                    {
                        LableText = "Account not found";
                        LableVisibilty = Visibility.Visible;
                    }
                    LoadingVisibility = Visibility.Collapsed;
                });
            }


        }));
    }
}
