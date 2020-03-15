using System;
using System.Threading;

namespace _2003132
{
    //定义一个委托类型
    public delegate void AlarmHandler();
    public delegate void TickHandler();
    public class Clock
    {
        //定义事件
        public event AlarmHandler onAlarm;
        public event TickHandler onTick;

        public void Press()
        {
            Console.WriteLine("Clock");           

        }
    }

    public class Ring
    {
        public Clock clock = new Clock();
        public Ring()
        {           
            clock.onTick += new TickHandler(Tick);
            clock.onAlarm +=new AlarmHandler(Alarm);
        }


        public void Tick()
        {
            Thread tick = new Thread(() =>
              {
                  while (true)
                  {
                      Console.WriteLine("嘀嗒");
                      Thread.Sleep(2000);
                  }
              });
            tick.Start();
        }

        public void Alarm()
        {
            if(DateTime.Now.Hour==12)
            {
                Thread alram = new Thread(() => Console.WriteLine("响铃"));
                alram.Start();
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Ring ring = new Ring();
            ring.clock.Press();
            ring.Alarm();
            ring.Tick();
        }
    }
}
