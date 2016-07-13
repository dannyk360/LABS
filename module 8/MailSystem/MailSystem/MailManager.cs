using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event System.EventHandler<MailArrivedEventArgs> MailArrived;

        public void SimulateMailArrived(MailArrivedEventArgs e)
        {
            OnMailArrived(e);
        }
        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            MailArrived?.Invoke(this, e);
        }
    }
}
