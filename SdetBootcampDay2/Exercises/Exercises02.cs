using System.Runtime.CompilerServices;
using Moq;
using NUnit.Framework;
using SdetBootcampDay2.Answers;
using SdetBootcampDay2.TestObjects.Answers;


namespace SdetBootcampDay2.Exercises
{
    [TestFixture]
    public class Exercises02
    {

        [Test]
        public void PaymentProcessor_ReturnFalseForAllStripePayments()
        {
            Dictionary<OrderItem, int> stock = new Dictionary<OrderItem, int>
            {
                {OrderItem.FIFA_24, 10 }
            };

            var fakePaymentProcessor = new Mock<IPaymentProcessor>();
            fakePaymentProcessor.Object.paymentProcessorType = PaymentProcessorType.Stripe;
            fakePaymentProcessor.Setup(n => n.PayFor(OrderItem.FIFA_24, 10)).Returns(false);

            var OrderHandler = new OrderHandler(stock, fakePaymentProcessor.Object);

            OrderHandler.Order(OrderItem.FIFA_24, 10);

            var TestPurchase = OrderHandler.PayFor(OrderItem.FIFA_24, 10);

            Assert.That(TestPurchase, Is.False);

            fakePaymentProcessor.Verify(n => n.PayFor(OrderItem.FIFA_24, 10), Times.Once);

            

            /**
             * TODO: Create a mock object representing the payment processor. Pass in Stripe
             * as the payment processor type. Set up the mock so that a call to PayFor() with
             * FIFA 24 and 10 as arguments returns false.
             */


            /**
             * TODO: Complete the test by creating a new OrderHandler, passing in the mock object
             * for the payment processor. Call the Order() method and then assert that the PayFor()
             * method of the OrderHandler returns false
             */


            /**
             * TODO: verify that the PayFor() method of the mock payment processor was called
             * exactly once with FIFA_24 and 10 as parameters.
             */

        }
    }

}
