using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimCommander
{
    class Define
    {
        public const String APP_NAME = "KIMCOMMANDER";
        public static String XML_FILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Define.APP_NAME;
        public static String ICON_FILE_PATH = XML_FILE_PATH + "\\icons";
        public static String XML_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Define.APP_NAME + "\\savedatas.xml";
    }
}
