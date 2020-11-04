using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace KimCommander
{
    class FileManager
    {
        private static readonly FileManager instance = new FileManager();
        private XmlDocument mXmlDoc = new XmlDocument();

        private const String ROOT_NODE = "savedatas";
        private const String SETTING_VERSION = "201609212238";        


        // NODE_KEYS

        private const String NK_VERSION_NODE = "version";
        private const String NK_TIMEITEM_NODES = "timenodes";
        private const String NK_QUICKITEM_NODES = "quicknodes";
        private const String NK_HOTKEY_NODES = "hotkeynodes";

        // NODE_ATTS

        // TimeItem atts
        private const String NA_TIME_ITEM_NAME = "name";
        private const String NA_TIME_ITEM_ITEMTYPE = "itemtype";
        private const String NA_TIME_ITEM_AFTERCHECK = "aftercheck";
        private const String NA_TIME_ITEM_HOUR = "hour";
        private const String NA_TIME_ITEM_MIN = "min";
        private const String NA_TIME_ITEM_SEC = "sec";
        private const String NA_TIME_ITEM_EVENTTYPE = "eventtype";
        private const String NA_TIME_ITEM_PARAM1 = "param1";
        private const String NA_TIME_ITEM_PARAM2 = "param2";
        private const String NA_TIME_ITEM_TIMESTAMP = "timestamp";
        private const String NA_TIME_ITEM_RUNADMIN = "admin";

        // QuickItem atts
        private const String NA_QUICK_ITEM_NAME = "name";
        private const String NA_QUICK_ITEM_FILEPATH = "filepath";
        private const String NA_QUICK_ITEM_SHORTNAME = "shortname";
        private const String NA_QUICK_ITEM_ARGUMENT = "argument";
        private const String NA_QUICK_ITEM_PRECOMMAND = "precommand";
        private const String NA_QUICK_ITEM_RUNADMIN = "admin";

        // Hotkey Item
        private const String NA_HOTKEY_MODIFYKEY = "modifykey";
        private const String NA_HOTKEY_HOTKEY = "hotkey";


        private String[] NODE_KEYS ={                                        
                                        NK_VERSION_NODE,
                                        NK_TIMEITEM_NODES,
                                        NK_QUICKITEM_NODES,
                                        NK_HOTKEY_NODES,
                                    };

        private String[] NA_TIME_ITEM_ATTS =
        {
            NA_TIME_ITEM_NAME,
            NA_TIME_ITEM_ITEMTYPE,
            NA_TIME_ITEM_AFTERCHECK,
            NA_TIME_ITEM_HOUR,
            NA_TIME_ITEM_MIN,
            NA_TIME_ITEM_SEC,
            NA_TIME_ITEM_EVENTTYPE,
            NA_TIME_ITEM_PARAM1,
            NA_TIME_ITEM_PARAM2,
            NA_TIME_ITEM_TIMESTAMP,
            NA_TIME_ITEM_RUNADMIN
        };

        private String[] NA_QUICK_ITEM_ATTS =
        {
            NA_QUICK_ITEM_NAME,
            NA_QUICK_ITEM_FILEPATH,
            NA_QUICK_ITEM_SHORTNAME,
            NA_QUICK_ITEM_ARGUMENT,
            NA_QUICK_ITEM_PRECOMMAND,
            NA_QUICK_ITEM_RUNADMIN
        };

        private String[] NA_HOTKEY_ATTS =
        {
            NA_HOTKEY_MODIFYKEY,
            NA_HOTKEY_HOTKEY
        };

        public static FileManager getInst()
        {
            return instance;
        }

        public void makeXml(String fileName)
        {
            try
            {                
                XmlNode rootNode = mXmlDoc.CreateElement(ROOT_NODE);
                foreach(String nodeName in NODE_KEYS)
                {
                    appendDefaultValueNode(rootNode, nodeName);
                }                
                mXmlDoc.AppendChild(rootNode);
                mXmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void existCheckAndAddNodeAll(String fileName)
        {
            foreach (String nodekey in NODE_KEYS)
            {
                existCheckAndAddNode(nodekey);
            }
            mXmlDoc.Save(fileName);
        }

        private void appendDefaultValueNode(XmlNode parentNode, String nodeName)
        {
            XmlElement node = mXmlDoc.CreateElement(nodeName);
            switch (nodeName)
            {
                case NK_VERSION_NODE:
                    node.InnerText = SETTING_VERSION;
                    break;
                case NK_TIMEITEM_NODES:
                    {

                    }
                    break;
                case NK_QUICKITEM_NODES:
                    break;
                case NK_HOTKEY_NODES:
                    break;                
            }
            parentNode.AppendChild(node);
        }        

        private void existCheckAndAddNode(String nodeKey)
        {
            XmlNode root = mXmlDoc.DocumentElement;
            XmlNodeList nodes = root.ChildNodes;
            bool isExist = false;
            foreach (XmlNode node in nodes)
            {
                if (node.Name.Equals(nodeKey))
                {
                    isExist = true;
                    break;
                }
            }
            if (isExist == false)
            {
                appendDefaultValueNode(root, nodeKey);
            }            
        }

        private void existCheckAndAddAtt(String nodeName, XmlNode node)
        {
            switch (nodeName)
            {
                case NK_VERSION_NODE:
                    break;
                case NK_TIMEITEM_NODES:
                    {
                        foreach(String attName in NA_TIME_ITEM_ATTS)
                        {
                            if (node.Attributes[attName] == null)
                            {
                                String ns = node.GetNamespaceOfPrefix("item");
                                XmlNode attr = mXmlDoc.CreateNode(XmlNodeType.Attribute, attName, ns);
                                switch (attName)
                                {
                                    case NA_TIME_ITEM_TIMESTAMP:
                                        attr.Value = Utils.getTimeStamp().ToString();
                                        break;
                                    case NA_TIME_ITEM_RUNADMIN:
                                        attr.Value = "false";
                                        break;
                                    default:
                                        attr.Value = "";
                                        break;
                                }                                
                                node.Attributes.SetNamedItem(attr);
                            }
                        }
                    }
                    break;
                case NK_QUICKITEM_NODES:
                    {
                        foreach (String attName in NA_QUICK_ITEM_ATTS)
                        {
                            if (node.Attributes[attName] == null)
                            {
                                String ns = node.GetNamespaceOfPrefix("item");
                                XmlNode attr = mXmlDoc.CreateNode(XmlNodeType.Attribute, attName, ns);
                                switch (attName)
                                {
                                    case NA_QUICK_ITEM_RUNADMIN:
                                        attr.Value = "false";
                                        break;
                                    default:
                                        attr.Value = "";
                                        break;
                                }                                
                                node.Attributes.SetNamedItem(attr);
                            }
                        }
                    }
                    break;
                case NK_HOTKEY_NODES:
                    {
                        foreach (String attName in NA_HOTKEY_ATTS)
                        {
                            if (node.Attributes[attName] == null)
                            {
                                String ns = node.GetNamespaceOfPrefix("hotkey");
                                XmlNode attr = mXmlDoc.CreateNode(XmlNodeType.Attribute, attName, ns);
                                attr.Value = "";
                                node.Attributes.SetNamedItem(attr);
                            }
                        }
                    }
                    break;
            }
        }

        public bool CheckXmlFile(String fileName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlElement root = mXmlDoc.DocumentElement;
                XmlElement loadRoot = xmlDoc.DocumentElement;
                if (root.Name.Equals(loadRoot.Name))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return false;
        }

        public void LoadXmlFile(String fileName, List<TimeItem> timeItems, List<QuickStartItem> quickItems)
        {
            try
            {
                mXmlDoc.Load(fileName);
                XmlElement root = mXmlDoc.DocumentElement;
                XmlNodeList nodes = root.ChildNodes;
                // 노드 요소의 값을 읽어옵니다
                foreach (XmlNode node in nodes)
                {
                    switch (node.Name)
                    {
                        case NK_VERSION_NODE:
                            //if (node.InnerText != null && Convert.ToInt64(node.InnerText) < Convert.ToInt64(CUR_VERSION))
                            {
                                // version 이 작음
                            }                            
                            break;
                        case NK_TIMEITEM_NODES:
                            {                                
                                foreach (XmlNode subNode in node)
                                {
                                    existCheckAndAddAtt(node.Name, subNode);
                                    long itemTimeStamp = Convert.ToInt64(subNode.Attributes[NA_TIME_ITEM_TIMESTAMP].Value);
                                    timeItems.Add(new TimeItem(subNode.Attributes[NA_TIME_ITEM_NAME].Value,
                                        Utils.EnumConv<TimeItem.TIMEITEM_TYPE>.Parse(subNode.Attributes[NA_TIME_ITEM_ITEMTYPE].Value),
                                        subNode.Attributes[NA_TIME_ITEM_AFTERCHECK].Value.Equals("true") ? true : false,
                                        Convert.ToInt32(subNode.Attributes[NA_TIME_ITEM_HOUR].Value),
                                        Convert.ToInt32(subNode.Attributes[NA_TIME_ITEM_MIN].Value),
                                        Convert.ToInt32(subNode.Attributes[NA_TIME_ITEM_SEC].Value),
                                        Utils.EnumConv<TimeItem.TIMEEVENT_TYPE>.Parse(subNode.Attributes[NA_TIME_ITEM_EVENTTYPE].Value),
                                        subNode.Attributes[NA_TIME_ITEM_PARAM1].Value, subNode.Attributes[NA_TIME_ITEM_PARAM2].Value,
                                        Convert.ToInt64(subNode.Attributes[NA_TIME_ITEM_TIMESTAMP].Value),
                                        Convert.ToBoolean(subNode.Attributes[NA_TIME_ITEM_RUNADMIN].Value)
                                        ));
                                }
                            }                            
                            break;
                        case NK_QUICKITEM_NODES:
                            {                                
                                foreach (XmlNode subNode in node)
                                {
                                    existCheckAndAddAtt(node.Name, subNode);
                                    quickItems.Add(new QuickStartItem(subNode.Attributes[NA_QUICK_ITEM_NAME].Value,
                                        subNode.Attributes[NA_QUICK_ITEM_FILEPATH].Value,
                                        subNode.Attributes[NA_QUICK_ITEM_SHORTNAME].Value,
                                        subNode.Attributes[NA_QUICK_ITEM_ARGUMENT].Value,
                                        subNode.Attributes[NA_QUICK_ITEM_PRECOMMAND].Value,
                                        Convert.ToBoolean(subNode.Attributes[NA_QUICK_ITEM_RUNADMIN].Value)));
                                }
                            }
                            break;
                        case NK_HOTKEY_NODES:
                            {
                                foreach (XmlNode subNode in node)
                                {
                                    existCheckAndAddAtt(node.Name, subNode);
                                    SettingDatas.getInst().setModifierKeysByComboValue(subNode.Attributes[NA_HOTKEY_MODIFYKEY].Value);
                                    SettingDatas.getInst().hotkey = (Keys)Enum.Parse(typeof(Keys), subNode.Attributes[NA_HOTKEY_HOTKEY].Value);
                                }
                            }
                            break;
                    }
                }
                existCheckAndAddNodeAll(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }            
        }

        public void SaveXmlFile(String fileName)
        {
            XmlElement root = mXmlDoc.DocumentElement;
            XmlNodeList nodes = root.ChildNodes;
            // 노드 요소의 값을 읽어옵니다
            foreach (XmlNode node in nodes)
            {
                switch (node.Name)
                {
                    case NK_VERSION_NODE:
                        node.RemoveAll();                        
                        break;
                    case NK_TIMEITEM_NODES:
                        {
                            node.RemoveAll();
                            List<TimeItem> timeItems = DataManager.getTimeItems();
                            foreach (TimeItem item in timeItems.ToArray())
                            {
                                XmlElement subNode = mXmlDoc.CreateElement("item");
                                subNode.SetAttribute(NA_TIME_ITEM_NAME, item.Name);
                                subNode.SetAttribute(NA_TIME_ITEM_ITEMTYPE, item.Type.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_AFTERCHECK, item.AfterCheck.ToString().ToLower());
                                subNode.SetAttribute(NA_TIME_ITEM_HOUR, item.Hour.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_MIN, item.Minute.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_SEC, item.Second.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_EVENTTYPE, item.TimeEventType.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_PARAM1, item.Param1.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_PARAM2, item.Param2.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_TIMESTAMP, item.TimeStamp.ToString());
                                subNode.SetAttribute(NA_TIME_ITEM_RUNADMIN, item.RunAdmin.ToString());
                                node.AppendChild(subNode);
                            }                            
                        }
                        break;
                    case NK_QUICKITEM_NODES:
                        {
                            node.RemoveAll();
                            List<QuickStartItem> quickItems = DataManager.getQuickStartItems();
                            foreach (QuickStartItem item in quickItems)
                            {
                                XmlElement subNode = mXmlDoc.CreateElement("item");
                                subNode.SetAttribute(NA_QUICK_ITEM_NAME, item.Name);
                                subNode.SetAttribute(NA_QUICK_ITEM_FILEPATH, item.FilePath);
                                subNode.SetAttribute(NA_QUICK_ITEM_SHORTNAME, item.ShortName);
                                subNode.SetAttribute(NA_QUICK_ITEM_ARGUMENT, item.Arguments);
                                subNode.SetAttribute(NA_QUICK_ITEM_PRECOMMAND, item.PreCommand);
                                subNode.SetAttribute(NA_QUICK_ITEM_RUNADMIN, item.RunAdmin.ToString());
                                node.AppendChild(subNode);

                                if (Utils.checkIconFileExit(item.ShortName) == false)
                                {
                                    Utils.makeIconCacheFile(Utils.getIconFromAppPath(item.FilePath), item.ShortName);
                                }
                            }
                        }
                        break;
                    case NK_HOTKEY_NODES:
                        {
                            node.RemoveAll();
                            XmlElement subNode = mXmlDoc.CreateElement("hotkey");
                            subNode.SetAttribute(NA_HOTKEY_MODIFYKEY, SettingDatas.getInst().getModifierKeysbyComboValue());
                            subNode.SetAttribute(NA_HOTKEY_HOTKEY, SettingDatas.getInst().hotkey.ToString());
                            node.AppendChild(subNode);
                        }
                        break;
                }
            }
            mXmlDoc.Save(fileName);
        }
    }    
}
