using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PR_20._101_Avdeev_authorization.Baza;

namespace PR_20._101_Avdeev_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = TBlockLogin.Text.Trim();
            string password = PBoxPassword.Password.Trim();

            Entities database = Entities.GetContext();

            if (database.User.Any(u => u.UserLogin == login && u.UserPassword == password))
            {
                var user = database.User.Where(u => u.UserLogin == login && u.UserPassword == password).FirstOrDefault();
                MessageBox.Show($"Добро пожаловать! Ваша роль: {user.Role.RoleName}");
            }
            else
                MessageBox.Show("Неверно введены логин или пароль!");
        }
    }
}
