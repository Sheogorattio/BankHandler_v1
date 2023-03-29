using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankHandler
{
    public class Receiver
    {
        private bool BankTransfer;
        private bool MoneyTransfer;
        private bool PayPalTransfer;
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
        public bool GetBankTransfer()
        {
            return BankTransfer;
        }
        public void SetBankTransfer(bool BankTransfer)
        {
            this.BankTransfer = BankTransfer;
        }
        public bool GetMoneyTransfer()
        {
            return MoneyTransfer;
        }
        public void SetMoneyTransfer(bool MoneyTransfer)
        {
            this.MoneyTransfer = MoneyTransfer;
        }
        public bool GetPayPalTransfer()
        {
            return PayPalTransfer;
        }
        public void SetPayPalTransfer(bool PayPalTransfer)
        {
            this.PayPalTransfer = PayPalTransfer;
        }
    }
    public abstract class PaymentHandler
    {
        protected PaymentHandler Successor;
        public void SetHandler(PaymentHandler Successor)
        {
            this.Successor = Successor;
        }
        public PaymentHandler GetHandler()
        {
            return this.Successor;
        }
        public abstract void Handle(Receiver receiver);
    }
    public class BankPaymentHandler : PaymentHandler
    {
        override public void Handle(Receiver receiver) 
	    {
		    if (receiver.GetBankTransfer())
			    Console.WriteLine( "Bank transfer");
		    else if (Successor != null)
			    Successor.Handle(receiver);
        }
    }

    public class MoneyPaymentHandler :  PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.GetMoneyTransfer())
                Console.WriteLine("Transfer through money transfer systems");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }


    class PayPalPaymentHandler :  PaymentHandler
    {
	    public override void Handle(Receiver receiver) 
	    {
		    if (receiver.GetPayPalTransfer())
			    Console.WriteLine( "Transfer via paypal");
		    else if (Successor != null)
			    Successor.Handle(receiver);
        }
    }
}
