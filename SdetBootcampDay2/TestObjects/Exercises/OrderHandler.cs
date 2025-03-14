namespace SdetBootcampDay2.TestObjects.Exercises
{
    // public class OrderHandler
    // {
    //     private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
    //     private readonly PaymentProcessor paymentProcessor;

    //     /**
    //      * TODO: can you apply Dependency Inversion here to make this code more flexible,
    //      * allowing users to inject the stock, and thereby make the code easier to test?
    //      * Do the same for the PaymentProcessor. You do not need to create interfaces as
    //      * was shown in the example (although if you want to, be my guest!)
    //      * After you have done that, update the existing tests and add the tests that were
    //      * not possible before.
    //      */
    //     public OrderHandler()
    //     {
    //         this.stock.Add(OrderItem.FIFA_24, 10);
    //         this.stock.Add(OrderItem.Fortnite, 100);
    //         this.stock.Add(OrderItem.SuperMarioBros3, 5);

    //         this.paymentProcessor = new PaymentProcessor(PaymentProcessorType.Stripe);
    //     }

    //     /**
    //      * TODO: this method clearly violates the Single Responsibility Principle
    //      * Can you refactor the code to resolve that? Don't forget to also update the tests.
    //      */
    //     public bool OrderAndPay(OrderItem item, int quantity)
    //     {
    //         if (!this.stock!.TryGetValue(item, out int result))
    //         {
    //             throw new ArgumentException($"Unknown item {item}");
    //         }

    //         if (this.stock[item] < quantity)
    //         {
    //             throw new ArgumentException($"Insufficient stock for item {item}");
    //         }

    //         this.stock[item] -= quantity;

    //         return this.paymentProcessor.PayFor(item, quantity);
    //     }

    //     public void AddStock(OrderItem item, int quantity)
    //     {
    //         if (!this.stock!.TryGetValue(item, out int result))
    //         {
    //             throw new ArgumentException($"Unknown item {item}");
    //         }

    //         this.stock[item] += quantity;
    //     }

    //     public int GetStockFor(OrderItem item)
    //     {
    //         if (!this.stock!.TryGetValue(item, out int result))
    //         {
    //             throw new ArgumentException($"Unknown item {item}");
    //         }

    //         return this.stock[item]; 
    //     }
    // }

        public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        public OrderHandler(Dictionary<OrderItem, int> stock, PaymentProcessor paymentProcessor)
        {
            this.stock = stock;
            this.paymentProcessor = paymentProcessor;
        }

        public Dictionary<string, object> SubmitOrder(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;
            Dictionary<string, object> OrderDetails = new Dictionary<string, object>();

            OrderDetails.Add("ItemName",item);
            OrderDetails.Add("Quantity", quantity);
            return OrderDetails;

        }

        public bool PayForOrder(Dictionary<string, object> OrderDetails)
        {
            OrderItem OrderedItem = (OrderItem)OrderDetails["ItemName"];
            int OrderQuantity = (int)OrderDetails["Quantity"];

            bool DidPaymentProcess = this.paymentProcessor.PayFor(OrderedItem, OrderQuantity);

            if (DidPaymentProcess)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Payment failed to process, quantity of {OrderQuantity} for order was too great!");
            }

        }

        public bool OrderAndPay(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;

            return this.paymentProcessor.PayFor(item, quantity);
        }

        public void AddStock(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            this.stock[item] += quantity;
        }

        public int GetStockFor(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            return this.stock[item]; 
        }
    }
}

