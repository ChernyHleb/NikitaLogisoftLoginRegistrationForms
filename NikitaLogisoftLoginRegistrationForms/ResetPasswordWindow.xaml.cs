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
    /// Interaction logic for ResetPasswordWindow.xaml
    /// </summary>
    public partial class ResetPasswordWindow : Window
    {
        public ResetPasswordWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width * 3.5;
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
            if (EmailTextBox.Text.Equals(""))
            {
                MessageBox.Show("Insert email");
                return;
            }

            // making request to API to get existing emails
            ApiCommunicator apiCommunicator = new ApiCommunicator();
            List<Email> response = apiCommunicator.GetEmails();

            if (response.Count == 0 || !response.Exists(item => item.email.Equals(EmailTextBox.Text)))
            {
                MessageBox.Show("There is no user with such email");
                return;
            }

            MessageBox.Show("Success");
        }
    }
}
