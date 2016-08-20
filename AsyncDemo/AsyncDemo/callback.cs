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
        // method name should begin with big letter, why static?? why new class??
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
        // method name should begin with big letter, why not Implemented ??

        private void addToList(int number)
        {
            // ????
        }
    }
}
