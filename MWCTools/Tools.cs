using System;
using System.Collections.Generic;
using System.IO;
using Security;
using Spire.Email;
using Spire.Email.IMap;
using Spire.Email.Smtp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Packaging;

namespace MWCTools
{
   
      public  class CustomerSettings : CustomerCommands
    {
        string eng = "English";
        string jap = "Japanese";
        bool engSelected = false;
        bool japSelected = false;
        bool isChecked = false;
        public override void CheckDuplicationFile( StreamWriter sw ,bool isChked)
        {
           string  name = "CheckDuplication.txt";
            sw = new StreamWriter(name);
            if(isChked == true)
            {
                sw.Write("true");
                sw.Close();
            }
            else
            {
                sw.Write("false");
                sw.Close();

            }
        }

        public override void createLangFile(string input, StreamWriter sw)
        {
            string name = "lang.txt";
            sw = new StreamWriter(name);

            if(input.Equals("English"))
            {
                sw.Write(eng);
                sw.Close();

            }
            if (input.Equals("Japanese"))
            {
                sw.Write(jap);
                sw.Close();

            }
        }

        public override void generateIp(string name, StreamWriter sw)
        {
            String url = "http://mwc.aranasecurity.com/ip"; 
            name = "ip.txt";
            sw = new StreamWriter(name);
            sw.Write(url);
            sw.Close();

        }

        public override void generatePort(string input, StreamWriter sw)
        {
            string name = "portNumber.txt";
            sw = new StreamWriter(name);
            sw.Write(input);
            sw.Close();

        }

        public override void updateStationNumber(string input, StreamWriter sw)
        {
           string  name = "portNumber.txt";
            sw = new StreamWriter(name);
            sw.Write(input);
            sw.Close();

        }
    }

    public class TroubleShoot : TroubleShootCommands
    {
        public override void checkIp(StreamWriter sw)
        {
            string url = "http://mwc.aranasecurity.com/ip";
            string name = "ip.txt";
            sw = new StreamWriter(name);
            sw.Write(url);
            sw.Close();

        }

        public override void checkPort( StreamWriter sw)
        {
            string numTxt = "";
            string name = "portNumber.txt";
            sw = new StreamWriter(name);
            sw.Write(numTxt);
            sw.Close();

        }

        public override void uploadLogFile(string name, StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }


   public  class LicenseVerification : LicenseCommands
    {
        string selectedApp = "cf89196c441f1069"; // has to be 16 characters

        public override void copyLicense(string fileName)
        {
            string curDir = Environment.CurrentDirectory;
            string path = fileName;
            string filename = System.IO.Path.GetFileName(path);

           
            File.Copy(path, System.IO.Path.Combine(curDir, filename), true);
        }


        public override string generateLicense()
        {
            string enc = Aesendec.Encrypt(FingerPrint.Value(), selectedApp);
            string text = enc;
            StreamWriter licenseEnroll = new StreamWriter("licenseEnrollmentMWC.txt");
            licenseEnroll.Write(text);
            licenseEnroll.Dispose();
            GC.Collect();
            return text;
        }

        public override void sendEmail(string name, string email , string licenceTxt)
        {
            
            MailAddress addressFrom = "dev.team.Arana@hotmail.com";
            MailAddress addressTo = "dev.team@aranasecurity.com";
            MailAddress adressCC = "fazz@aranasecurity.com";

            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "Spire.Email Component";
            message.BodyText = "Hi!\r\n" +
                "This is " + name + "\r\n" + "My Email is " + email + "\r\n License is " + "\r\n" + licenceTxt;
            message.Date = DateTime.Now;

            //message.Attachments.Add(new Attachment("licenseEnrollmentMWC.txt"));
            message.Cc.Add(adressCC.Address);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.outlook.com";
            smtp.ConnectionProtocols = ConnectionProtocols.Ssl;
            smtp.Username = addressFrom.Address;
            smtp.Password = "myPW4tigris!1";
            smtp.Port = 587;
            smtp.SendOne(message);
            GC.Collect();
        }
    }
}
