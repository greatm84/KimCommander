using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimCommander
{
    class TimeItem
    {        
        public enum TIMEITEM_TYPE
        {
            TIMEITEM_AT_TIME = 0,
            TIMEITEM_TIMER,            
        };
        public enum TIMEEVENT_TYPE
        {
            TIMEEVENT_LAUNCH_APP = 0,
            TIMEEVENT_CAPTURE,
        };
        private TIMEITEM_TYPE mType;
        public TIMEITEM_TYPE Type
        {
            get
            {
                return mType;
            }
            set
            {
                mType = value;
            }
        }       

        private bool mAfterCheck;
        public bool AfterCheck
        {
            get
            {
                return mAfterCheck;
            }
            set
            {
                mAfterCheck = value;
            }
        }
   
        private Object mParam1;
        public Object Param1
        {
            get
            {
                return mParam1;
            }
            set
            {
                mParam1 = value;
            }
        }
        private Object mParam2;
        public Object Param2
        {
            get
            {
                return mParam2;
            }
            set
            {
                mParam2 = value;
            }
        }
        private int mHour;
        public int Hour
        {
            get
            {
                return mHour;
            }
            set
            {
                mHour = value;
            }
        }
        private int mMinute;
        public int Minute
        {
            get
            {
                return mMinute;
            }
            set
            {
                mMinute = value;
            }
        }
        private int mSecond;
        public int Second
        {
            get
            {
                return mSecond;
            }
            set
            {
                mSecond = value;
            }
        }
        private TIMEEVENT_TYPE mTimeEventType;
        public TIMEEVENT_TYPE TimeEventType
        {
            get
            {
                return mTimeEventType;
            }
            set
            {
                mTimeEventType = value;
            }
        }
        private bool mAlive;
        public bool Alive
        {
            get
            {
                return mAlive;
            }
            set{
                mAlive = value;
            }        
        }
        private String mName;
        public String Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }
        private long mTimeStamp;
        public long TimeStamp
        {
            get
            {
                return mTimeStamp;
            }
            set
            {
                mTimeStamp = value;
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

        public TimeItem(String name, TIMEITEM_TYPE type, bool afterCheck, int hour, int min, int sec,
            TIMEEVENT_TYPE event_type, Object param1, Object param2, long timeStamp, bool asAdmin)
        {
            Name = name;
            Alive = true;
            Type = type;
            AfterCheck = afterCheck;
            Hour = hour;
            Minute = min;
            Second = sec;
            Param1 = param1;
            Param2 = param2;
            TimeEventType = event_type;
            TimeStamp = timeStamp;
            RunAdmin = asAdmin;
        }

        public void modifyTimeItem(String name, TIMEITEM_TYPE type, bool afterCheck, int hour, int min, int sec,
            TIMEEVENT_TYPE event_type, Object param1, Object param2, long timeStamp, bool asAdmin)
        {
            Name = name;
            Alive = true;
            Type = type;
            AfterCheck = afterCheck;
            Hour = hour;
            Minute = min;
            Second = sec;
            Param1 = param1;
            Param2 = param2;
            TimeEventType = event_type;
            TimeStamp = timeStamp;
            RunAdmin = asAdmin;
        }
    }
}
