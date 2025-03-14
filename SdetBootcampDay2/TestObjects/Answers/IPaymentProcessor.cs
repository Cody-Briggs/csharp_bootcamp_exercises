using System;
using SdetBootcampDay2.TestObjects.Answers;

namespace SdetBootcampDay2.Answers;

public interface IPaymentProcessor
{
    PaymentProcessorType paymentProcessorType {get; set;} 
    bool PayFor(OrderItem item, int quantity);

}