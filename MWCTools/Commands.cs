using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWCTools
{
    public abstract class CustomerCommands 
    {
        String fileName;
        StreamWriter sw;

      public abstract void createLangFile(string input, StreamWriter sw);
      public abstract void updateStationNumber(string input, StreamWriter sw);
      public abstract void CheckDuplicationFile( StreamWriter sw ,bool isChked);
      public abstract void generatePort(string input, StreamWriter sw);
      public abstract void generateIp(string input, StreamWriter sw);


    }

    public abstract class TroubleShootCommands
    {
        public abstract void checkIp( StreamWriter sw);
        public abstract void checkPort( StreamWriter sw);
        public abstract void uploadLogFile(string input, StreamWriter sw);

    }

    public abstract class LicenseCommands
    {
        public abstract string generateLicense();
        public abstract void copyLicense(string fileNname);
        public abstract void sendEmail(string name, string email , string licenseTxt);

    }


}
