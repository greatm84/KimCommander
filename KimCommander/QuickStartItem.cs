using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimCommander
{
    class QuickStartItem
    {
        private String mAppName;
        public String Name
        {
            get
            {
                return mAppName;
            }
            set
            {
                mAppName = value;
            }
        }
        private String mFilePath;
        public String FilePath
        {
            get
            {
                return mFilePath;
            }
            set
            {
                mFilePath = value;
            }
        }
        private String mShortName;
        public String ShortName
        {
            get
            {
                return mShortName;
            }
            set
            {
                mShortName = value;
            }
        }
        private String mArguments;
        public String Arguments
        {
            get
            {
                return mArguments;
            }
            set
            {
                mArguments = value;
            }
        }
        private String mPreCommand;
        public String PreCommand
        {
            get
            {
                return mPreCommand;
            }
            set
            {
                mPreCommand = value;
            }
        }
        private bool mRunAdmin;
        public bool RunAdmin
        {
            get
            {
                return mRunAdmin;
            }
            set
            {
                mRunAdmin = value;
            }
        }
        public QuickStartItem(String appName, String filePath, String shortName, String arguments, String preCommand, bool asAdmin)
        {
            Name = appName;
            FilePath = filePath;
            ShortName = shortName;
            Arguments = arguments;
            PreCommand = preCommand;
            RunAdmin = asAdmin;
        }
    }
}
