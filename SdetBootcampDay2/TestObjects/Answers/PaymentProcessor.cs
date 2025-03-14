using SdetBootcampDay2.Answers;

namespace SdetBootcampDay2.TestObjects.Answers
{
    // public class PaymentProcessor
    // {
    //     private readonly PaymentProcessorType paymentProcessorType;

    //     public PaymentProcessor(PaymentProcessorType paymentProcessorType)
    //     {
    //         this.paymentProcessorType = paymentProcessorType;
    //     }

    //     public virtual bool PayFor(OrderItem item, int quantity)
    //     {
    //         // With Stripe, you can pay for every order.
    //         if (this.paymentProcessorType.Equals(PaymentProcessorType.Stripe))
    //         {
    //             return true;
    //         }

    //         // You can use PayPal only when ordering 5 items or less.
    //         return quantity <= 5;
    //     }
    // }

    public class PaymentProcessor : IPaymentProcessor
    {
        public PaymentProcessorType paymentProcessorType { get; set; }

        public PaymentProcessor(PaymentProcessorType InType)
        {
            this.paymentProcessorType = (PaymentProcessorType)InType;
        }

        public virtual bool PayFor(OrderItem item, int quantity)
        {
            // With Stripe, you can pay for every order.
            if (this.paymentProcessorType.Equals(PaymentProcessorType.Stripe))
            {
                return true;
            }

            // You can use PayPal only when ordering 5 items or less.
            return quantity <= 5;
        }

    }
}

