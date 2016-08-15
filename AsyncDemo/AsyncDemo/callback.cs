using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class CallbackClass
    {
        public static void callbackMethod(IAsyncResult Iasync)
        {
            AsyncResult res = (AsyncResult)Iasync;
            CallbackClass callback = new CallbackClass();
            currentDelegate caller = (currentDelegate)res.AsyncDelegate;
            var PrimeNumbers = caller.EndInvoke(Iasync);
            foreach (var number in PrimeNumbers)
            {
                callback.addToList(number);
            }


        }

        private void addToList(int number)
        {
            
        }
    }
}
