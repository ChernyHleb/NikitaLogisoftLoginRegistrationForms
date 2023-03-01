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
using System.Windows.Shapes;

namespace NikitaLogisoftLoginRegistrationForms
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width * 1.25;
        }

        private void Window_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Checking if all the fields have values
            string errorMessage = "";
            if (FirstNameTextBox.Text.Equals(""))
            {
                errorMessage += "Insert first name\n";
            }
            if (LastNameTextBox.Text.Equals(""))
            {
                errorMessage += "Insert last name\n";
            }
            if (EmailTextBox.Text.Equals(""))
            {
                errorMessage += "Insert email\n";
            }
            if (PasswordTextBox.Password.Equals(""))
            {
                errorMessage += "Insert password\n";
            }
            if (ConfirmPasswordTextBox.Password.Equals(""))
            {
                errorMessage += "Confirm password";
            }

            if (!errorMessage.Equals(""))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            ApiCommunicator apiCommunicator = new ApiCommunicator();

            // Checking if user with this email already exists
            ApiResponse<Email> getEmailResponse = apiCommunicator.GetEmails();
            if (getEmailResponse.data.Count != 0 && getEmailResponse.data.Exists(item => item.email.Equals(EmailTextBox.Text)))
            {
                MessageBox.Show("User with this email already exists");
                return;
            }

            UserNoId user = new UserNoId();
            user.first_name = FirstNameTextBox.Text;
            user.last_name = LastNameTextBox.Text;
            user.email = EmailTextBox.Text;
            user.pwd = PasswordTextBox.Password;

            apiCommunicator.PostUser(user);

            MessageBox.Show("Success");
        }
    }
}
