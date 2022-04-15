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
    class AuthorizationViewModel : BaseViewModel
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
                    (enterCommand = new RelayCommand(obj=> 
                    {
                        using (ChessTrainerContext ctx = new ChessTrainerContext())
                        {
                            if (ctx.Users.Where(u => u.Login == this.Login && u.Password == this.Password).Any())
                                OnAuthorize?.Invoke(this, new LoginEventArgs(this.Login, true));
                            else if (ctx.Users.Where(u => u.Login == this.Login && u.Password != this.Password).Any())
                            {
                                MessageBox.Show("Пользователь с данным логином уже есть или неправильно введен пароль.");
                                OnAuthorize?.Invoke(this, new LoginEventArgs(this.Login, false));
                            }
                            else
                            {
                                ctx.Users.Add(new User { Login = this.Login, Password = this.Password });
                                ctx.SaveChanges();
                                OnAuthorize?.Invoke(this, new LoginEventArgs(this.Login, true));
                            }
                        }
                    })); 
            }
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string Login { get; }
        public bool IsAuthorized { get; }

        public LoginEventArgs(string login, bool isAuthorized)
        {
            Login = login;
            IsAuthorized = isAuthorized;
        }
    }
}
