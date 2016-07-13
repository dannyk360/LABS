using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            var autoArgs = new MailArrivedEventArgs("this is a test", "test");
            manager.MailArrived += MailArrivedHandler;
            manager.SimulateMailArrived(autoArgs);
            Timer startTimer = new Timer(MailCallback, autoArgs, 1000, 1000);
            Console.ReadLine();
        }

        public static void MailArrivedHandler(object sender,MailArrivedEventArgs e)
        {
            Console.WriteLine(e.Title);
            Console.WriteLine(e.Body);
        }

        public static void MailCallback(object args)
        {
            MailManager manager = new MailManager();
            manager.MailArrived += MailArrivedHandler;
            manager.SimulateMailArrived((MailArrivedEventArgs)args);
        }
    }
}
