using ChessTrainer.Commands;
using ChessTrainer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTrainer.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        public event EventHandler<LoginEventArgs> OnAuthorize;

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged();}
        }

        private RelayCommand enterCommand;

        public RelayCommand EnterCommand
        {
            get { return enterCommand ??
                    (enterCommand = new RelayCommand(Authorize, obj=> 
                    {
                        return !(String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Login));
                    }
                    )); 
            }
        }

        private void Authorize(object o)
        {
            using (ChessTrainerContext ctx = new ChessTrainerContext())
            {
                User user = new User() { Login = this.Login, Password = this.Password };
                if (ctx.Users.Where(u => u.Login == user.Login && u.Password == user.Password).Any())
                    OnAuthorize?.Invoke(this, new LoginEventArgs(user, true));

                else if (ctx.Users.Where(u => u.Login == user.Login && u.Password != user.Password).Any())
                {
                    MessageBox.Show("Пользователь с данным логином уже есть или неправильно введен пароль.", 
                        "Ошибка", 
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                else
                {
                    MessageBox.Show("Пользователь добавлен в базу данных.",
                        "Удача",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    OnAuthorize?.Invoke(this, new LoginEventArgs(user, true));
                }
            }
        }
    }



    public class LoginEventArgs : EventArgs
    {
        public User User { get; }
        public bool IsAuthorized { get; }

        public LoginEventArgs(User user, bool isAuthorized)
        {
            User = user;
            IsAuthorized = isAuthorized;
        }
    }
}
