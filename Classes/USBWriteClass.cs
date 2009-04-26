using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Haiku.Classes
{
    class USBWriteClass
    {
        private string fFile;
        private string fSource;
        private ManualResetEvent fDoneEvent;
        private HaikuOnAStick fHaikuOnAStick;

        private delegate void WriteAString(string str);

        public USBWriteClass(string file, string source, ManualResetEvent doneEvent, HaikuOnAStick haikuOnAStick) 
        {
            fFile = file;
            fSource = source;
            fDoneEvent = doneEvent;
            fHaikuOnAStick = haikuOnAStick;
        }

        public string File 
        {
            get { return fFile; }
        }

        public string Source
        {
            get { return fSource; }
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            try
            {
                if (!string.IsNullOrEmpty(fFile) && !string.IsNullOrEmpty(fSource))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(fFile, fSource);
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                fHaikuOnAStick.Invoke(new WriteAString(fHaikuOnAStick.Log), "Error : " + ex.Message);
            }
            fDoneEvent.Set();
        }
    }
}
