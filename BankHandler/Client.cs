using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankHandler
{
    public class Client
    {
        void Request(PaymentHandler h, Receiver r)
        {
            h.Handle(r);
        }
    }
}
