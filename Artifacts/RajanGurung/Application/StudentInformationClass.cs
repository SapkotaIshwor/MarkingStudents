using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkAppDevelopment
{
    public class StudentInformationClass
    {
        //making all the textbox and combo-box private
        
            private string textdataName;
            
            private string textdataId;
        
            private string textdataAddress;
        
            private string textdataConatctNo;
        
            private string textdataEmail;
        
            private string textdataCourseEnroll;
        
            private string textdataRegistrationDate;
        
            private string textdataRegId;
        
        public string StudentId {

            get { return textdataId; }
            
            set { textdataId = value; }

        }
        
        public string StudentName {
            
            get { return textdataName; }
            
            set { textdataName = value; }
       
        }
        
        public string StudentAddress {

            get { return textdataAddress; }
            
            set { textdataAddress = value; }
        }

        public string StudentContactNo {
        
            get { return textdataConatctNo; }
            
            set { textdataConatctNo = value; }
        }
        
        public string StudentEmail {

            get { return textdataEmail; }
            
            set { textdataEmail = value; }
        
        }
        
        public string StudentCourseEnroll {

            get { return textdataCourseEnroll; }
            
            set { textdataCourseEnroll = value; }
        
        }
        
        public string StudentRegistrationDate {

            get { return textdataRegistrationDate; }
            
            set { textdataRegistrationDate = value; }
        
        }

        public string StudentRegistrationId {

            get { return textdataRegId; }
            
            set { textdataRegId = value; }
        
        }

    }
}
