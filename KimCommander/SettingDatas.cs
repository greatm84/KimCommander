using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimCommander
{
    class SettingDatas
    {
        private static readonly SettingDatas instance = new SettingDatas();
        private KimCommander.ModifierKeys mModifierKeys = ModifierKeys.Shift;
        public KimCommander.ModifierKeys ModifierKeys
        {
            get
            {
                return mModifierKeys;
            }
            set
            {
                mModifierKeys = value;
            }
        }
        public void setModifierKeysByComboValue(String value)
        {
            switch (value)
            {
                case "Shift":
                    mModifierKeys = KimCommander.ModifierKeys.Shift;
                    break;
                case "Alt":
                    mModifierKeys = KimCommander.ModifierKeys.Alt;
                    break;
                case "Ctrl":
                    mModifierKeys = KimCommander.ModifierKeys.Control;
                    break;
                case "Shift+Alt":
                    mModifierKeys = KimCommander.ModifierKeys.Shift | KimCommander.ModifierKeys.Alt;
                    break;
                case "Shift+Ctrl":
                    mModifierKeys = KimCommander.ModifierKeys.Shift | KimCommander.ModifierKeys.Control;
                    break;
                case "Alt+Ctrl":
                    mModifierKeys = KimCommander.ModifierKeys.Control | KimCommander.ModifierKeys.Alt;
                    break;
                default:
                    mModifierKeys = KimCommander.ModifierKeys.Shift;
                    break;
            }  
        }
        public String getModifierKeysbyComboValue()
        {
            switch (mModifierKeys)
            {
                case KimCommander.ModifierKeys.Shift:
                    return "Shift";
                case KimCommander.ModifierKeys.Alt:
                    return "Alt";
                case KimCommander.ModifierKeys.Control:
                    return "Ctrl";
                case KimCommander.ModifierKeys.Shift | KimCommander.ModifierKeys.Alt:
                    return "Shift+Alt";
                case KimCommander.ModifierKeys.Shift | KimCommander.ModifierKeys.Control:
                    return "Shift+Ctrl";
                case KimCommander.ModifierKeys.Control | KimCommander.ModifierKeys.Alt:
                    return "Alt+Ctrl";
                default:
                    return "Shift";
            }
        }

        private Keys mHotkeys = Keys.Space;
        public Keys hotkey
        {
            get
            {
                return mHotkeys;
            }
            set
            {
                mHotkeys = value;
            }
        }

        private SettingDatas()
        {

        }

        public static SettingDatas getInst()
        {
            return instance;
        }        
        
    }
}
