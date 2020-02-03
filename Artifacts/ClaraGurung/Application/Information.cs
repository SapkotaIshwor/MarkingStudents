using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class Information
    {
        private string txtData1;
        private string txtData2;
        private string txtData3;
        private string txtData4;
        private string txtData5;
        private string txtData6;
        

        public string StudentRegistrationDate
        {
            get { return txtData1; }
            set { txtData1 = value; }
        }

        public string StudentID
        {
            get { return txtData2; }
            set { txtData2 = value; }
        }

        public string StudentName
        {
            get { return txtData3; }
            set { txtData3 = value; }
        }

        public string StudentAddress
        {
            get { return txtData4; }
            set { txtData4 = value; }
        }


        public string StudentContact
        {
            get { return txtData5; }
            set { txtData5 = value; }
        }

        public string StudentCourse
        {
            get { return txtData6; }
            set { txtData6 = value; }
        }
    }
}
