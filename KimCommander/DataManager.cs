using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimCommander
{
    class AutoShutDownItem
    {
        public bool alive = false;
        public int hour = 0;
        public int min = 0;
        public int sec = 0;
    }

    class DataManager
    {        
        List<QuickStartItem> mQuickStartItems = new List<QuickStartItem>();
        List<TimeItem> mTimeItems = new List<TimeItem>();
        AutoShutDownItem mAutoShutDownItem = new AutoShutDownItem();

        private static readonly DataManager instance = new DataManager();        
        
        private DataManager()
        {
            loadDatas();
        }

        private void loadDatas()
        {
            String sDirPath;
            sDirPath = Define.XML_FILE_PATH;
            {                
                DirectoryInfo di = new DirectoryInfo(sDirPath);
                if (di.Exists == false)
                {
                    di.Create();
                }
            }
            sDirPath = Define.ICON_FILE_PATH;
            {
                DirectoryInfo di = new DirectoryInfo(sDirPath);
                if (di.Exists == false)
                {
                    di.Create();
                }
            }

            if (File.Exists(Define.XML_FILE_NAME))
            {
                FileManager.getInst().LoadXmlFile(Define.XML_FILE_NAME, mTimeItems, mQuickStartItems);                
            }
            else
            {                                
                FileManager.getInst().makeXml(Define.XML_FILE_NAME);                
            }            
        }

        public static void saveDatas(String fileName = "")
        {
            if (fileName.Equals(""))
            {
                FileManager.getInst().SaveXmlFile(Define.XML_FILE_NAME);
            }
            else
            {
                FileManager.getInst().SaveXmlFile(fileName);
            }
        }

        public static List<TimeItem> getTimeItems()
        {            
            return instance.mTimeItems;
        }

        public static List<QuickStartItem> getQuickStartItems()
        {
            return instance.mQuickStartItems;
        }

        public static AutoShutDownItem getAutoShutdownItem()
        {
            return instance.mAutoShutDownItem;
        }
    }
}
