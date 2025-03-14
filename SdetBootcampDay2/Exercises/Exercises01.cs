using Microsoft.VisualBasic;
using NUnit.Framework;
using SdetBootcampDay2.TestObjects.Exercises;

namespace SdetBootcampDay2.Exercises
{
    [TestFixture]
    public class Exercises01
    {

        public Dictionary<OrderItem, int> StockTracker = new Dictionary<OrderItem, int>
        {
            {OrderItem.FIFA_24, 20},
            {OrderItem.Fortnite, 10},
            {OrderItem.SuperMarioBros3, 10}
        };
        public PaymentProcessor StripePaymentManager = new PaymentProcessor(PaymentProcessorType.Stripe);
        public PaymentProcessor PayPalPaymentManager = new PaymentProcessor(PaymentProcessorType.Paypal);

        /**
         * TODO: After updating the OrderHandler to fix the Single Responsibility violation,
         * make the tests work again.
         */

        /**
         * TODO: After updating the OrderHandler to fix the Dependency Inversion violations,
         * make the tests work again.
         */

        /**
         * TODO: Add a test that tests that injects a stock count of 0 for Day Of The Tentacle,
         * tries to order a copy and verifies that the expected exception with the expected message
         * is thrown.
         */

        /**
         * TODO: Add a test that that creates a new OrderHandler using PayPal as a payment
         * processor, and test that ordering more than five items results in a payment failure,
         * even when there is enough stock.
         */

        [Test]
        public void Order1CopyOfFIFA24_ShouldLeave9CopiesRemaining()
        {
            
            var orderHandler = new OrderHandler(StockTracker, StripePaymentManager);

            var PendingOrder = orderHandler.SubmitOrder(OrderItem.FIFA_24, 1);
            orderHandler.PayForOrder(PendingOrder);

            Assert.That(orderHandler.GetStockFor(OrderItem.FIFA_24), Is.EqualTo(9));
        }

        [Test]
        public void Order101CopiesOfFortnite_ShouldYieldArgumentException()
        {
            var orderHandler = new OrderHandler(StockTracker, StripePaymentManager);

            ArgumentException? ae = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.SubmitOrder(OrderItem.Fortnite, 101);
            });

            Assert.That(ae?.Message, Is.EqualTo("Insufficient stock for item Fortnite"));
        }

        [Test]
        public void AddStockForDayOfTheTentacle_ShouldYieldArgumentException()
        {
            var orderHandler = new OrderHandler(StockTracker, StripePaymentManager);

            ArgumentException? ae = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.AddStock(OrderItem.DayOfTheTentacle, 10);
            });

            Assert.That(ae?.Message, Is.EqualTo("Unknown item DayOfTheTentacle"));
        }

        [Test]
        public void TryBulkOrderPaymentThroughPaypal()
        {
            var orderHandler = new OrderHandler(StockTracker, PayPalPaymentManager);

            Dictionary<string, object> PendingOrder = orderHandler.SubmitOrder(OrderItem.FIFA_24, 15);

             ArgumentException? BulkPayPalPurchaseException = Assert.Throws<ArgumentException>(() =>
            { 
                orderHandler.PayForOrder(PendingOrder);
            });

            Assert.That(BulkPayPalPurchaseException?.Message, Is.EqualTo($"Payment failed to process, quantity of {(int)PendingOrder["Quantity"]} for order was too great!"));

        }

    }
}
