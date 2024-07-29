using Issue_Tracking_App.Migrations;
using System.Net.Mail;
using System.Net.Mime;

namespace Issue_Tracking_App.Services
{
    public class MailService
    {
        public void SendMail(string userName, string email, string subject)

        {

            var message_body = "";

            var dm_link = "https://apps.mrc.gm/hrcontracts";


            message_body = "<html><body>";

            message_body = "<html><body>";

            //message_body += "<h2 style='color: #FFFFFF;background: #6A3B77;text-align:center'><span style='color: #FFDB00;'>ePaySlip </span>dispatch system</h2>";

            //message_body += "<hr>";

            message_body += "<div>";

            message_body += "<p>Dear <strong>" + userName + ",</strong></p>";

            //message_body += "<p>Dear {getFirstName}, </p>";

            // message_body += "<p>Please find attached your extended contract.</p>";

            //message_body += "<p>If you have queries please contact the HR Department.</p>";

            //message_body += "<p>Application: <a href='" + dm_link + "'> HR Contracts Extension Application </a></p>";

            //message_body += "<br><br>";

            //message_body += "Regards,";

            //message_body += "<br><br>";

            message_body += subject;

            message_body += "</div>";

            message_body += "<hr>";

            message_body += "CLICK HERE TO VIEW  STATUS: <a href='http://localhost:5244/Tracking/UserInputList' target='_top'>My Created Issues</a>";

            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(email));

            //mailMessage.To.Add(new MailAddress("anndure@mrc.gm"));

            //mailMessage.CC.Add("ksallah@mrc.gm");

            //mailMessage.CC.Add("najaiteh@mrc.gm"); 

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "Issue Sent Successfully";

            // Attach the provided attachment directly

            // mailMessage.Attachments.Add(attachment);

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }

        }
        public void SendFinalMail(string userName, string email, string subject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + userName + ",</strong></p>";

            //message_body += "<br><br>";
            message_body += subject;
            message_body += "</div>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(email));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "Issue Solved";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }

        }
        public void SendFirstMailToAdmin(string Adminemail, string Adminsubject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + "Admin" + ",</strong></p>";

            //message_body += "<br><br>";
            message_body += Adminsubject;
            message_body += "</div>";
            message_body += "List of all Issues : <a href='http://localhost:5244/Tracking/AllReports' target='_top'>View</a>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(Adminemail));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "New Issue created";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }


        }
        public void SendMailToDev(string userName, string email, string subject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + userName + ",</strong></p>";

            //message_body += "<br><br>";
            message_body += subject;
            message_body += "</div>";
            message_body += "List of all Issues Assigned to you: <a href='http://localhost:5244/Tracking/DeveloperList' target='_top'>View</a>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(email));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "Issue Assigned To You.";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }


        }
        public void SendMailToTester(string tester, string testersEmail, string subject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + tester + ",</strong></p>";

            //message_body += "<br><br>";

            message_body += subject;

            message_body += "</div>";
            message_body += "List of all Issues Assigned to you: <a href='http://localhost:5244/Tracking/TestersList' target='_top'>View</a>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(testersEmail));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "New Issue Assigned To You.";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }


        }
        public void SendTestMailToAdmin(string Adminemail, string Adminsubject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + "Admin" + ",</strong></p>";

            //message_body += "<br><br>";
            message_body += Adminsubject;
            message_body += "The Developer added a note on how the Issue was solved.";
            message_body += "</div>";
            message_body += "List of all Issues : <a href='http://localhost:5244/Tracking/AllReports' target='_top'>View</a>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(Adminemail));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "Issue Awaiting Test";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }

        }
        public void SendFinalMailToAdmin(string Adminemail, string Adminsubject)
        {
            var message_body = "";

            message_body = "<html><body>";
            message_body += " <div>";
            message_body += "<p>Dear <strong>" + "Admin" + ",</strong></p>";

            //message_body += "<br><br>";
            message_body += Adminsubject;
            message_body += "</div>";
            message_body += "List of all Issues : <a href='http://localhost:5244/Tracking/AllReports' target='_top'>View</a>";
            message_body += "<hr>";

            message_body += "<p style='font-size: 0.8em;'>DISCLAIMER: This message is private and confidential. If you have received this message in error please notify us and remove it from your system. Any views and opinions expressed in this message are those of the individual sender and do not necessarily represent the views and opinions of MRC Unit The Gambia.</p>";

            message_body += "</body></html>";

            MailMessage mailMessage = new MailMessage();

            MailAddress fromAddress = new MailAddress("development@mrc.gm");

            mailMessage.From = fromAddress;

            mailMessage.To.Add(new MailAddress(Adminemail));

            mailMessage.Body = message_body;

            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = "Issue Solved";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "mail.mrc.gm";

            smtpClient.Port = 25;

            try

            {

                smtpClient.Send(mailMessage);

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }


        }
    }
}