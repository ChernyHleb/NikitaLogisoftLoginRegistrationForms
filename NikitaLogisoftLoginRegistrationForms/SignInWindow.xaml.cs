using NikitaLogisoftLoginRegistrationForms.ApiResponseModels;
using NikitaLogisoftLoginRegistrationForms.models;
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

namespace NikitaLogisoftLoginRegistrationForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //RegistrationWindow registrationWindow = new RegistrationWindow();
            //registrationWindow.Show();

            //ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow();
            //resetPasswordWindow.Show();
        }

        private void Window_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if(EmailTextBox.Text.Equals(""))
            {
                errorMessage += "Insert email ";
            }
            if (PasswordTextBox.Password.Equals(""))
            {
                errorMessage += "Insert password ";
            }

            if(!errorMessage.Equals(""))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            AuthApiCommunicator auth = new AuthApiCommunicator();

            User user = new User();
            user.email = EmailTextBox.Text;
            user.pwd = PasswordTextBox.Password;

            LoginResponse response = null;

            try
            {
                response = auth.Login(user);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }

            if(response != null)
            {
                MessageBox.Show(
                    "Refresh token: " + response.refreshToken + "\n" +
                    "Access token: " + response.accessToken);
            }

            //// making request to API to get a user
            //ApiCommunicator apiCommunicator = new ApiCommunicator();
            //List<User> response = apiCommunicator.GetUserByEmail(EmailTextBox.Text);
            
            //if (response.Count == 0) 
            //{ 
            //    MessageBox.Show("Not a user");
            //    return;
            //}

            //User user = response[0];
            ////MessageBox.Show(String.Format(
            ////    "{0} {1} {2} {3} {4}", 
            ////    user.id, user.first_name, user.last_name, user.email, user.pwd
            ////));

            //if (!user.pwd.Equals(PasswordTextBox.Password))
            //{
            //    MessageBox.Show("Incorrect password");
            //    return;
            //}
        }
    }
}
