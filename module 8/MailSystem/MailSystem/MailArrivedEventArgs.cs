using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailArrivedEventArgs : EventArgs
    {
        public readonly string Title;
        public readonly string Body;

        public MailArrivedEventArgs(string title,string body)
        {
            Title = title;
            Body = body;
        }
    }
}
