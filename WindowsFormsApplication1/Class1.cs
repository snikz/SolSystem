using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    delegate void DoWhenTick(int o);
    class Class1
    {
        int days = 0;
        int timerSpeed;
        int totalDays = 0;
        private static Timer aTimer;
        public event DoWhenTick evl;
        public void fireEvent()
        {
            evl(days);
        }
        public void init(int speed)
        {
            aTimer = new System.Timers.Timer(speed);
            aTimer.Elapsed += OnTimedEvent;
        }
        public void setTimer(int speed)
        {
            aTimer.Interval = speed;
        }
        public void start(int totalDays, bool anim)
        {
            if (anim)
                days = 0;
            else
                days = totalDays;
            this.totalDays = totalDays;
            aTimer.Enabled = true;
        }
        public void resume()
        {
            aTimer.Enabled = true;
        }
        public void stop()
        {
            aTimer.Enabled = false;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(days < totalDays)
                days++;
            this.fireEvent();
        }
    }
}
