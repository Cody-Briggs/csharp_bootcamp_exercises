namespace SdetBootcampDay1.TestObjects
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        public OrderHandler()
        {
            this.stock.Add(OrderItem.FIFA_24, 10);
            this.stock.Add(OrderItem.Fortnite, 100);
            this.stock.Add(OrderItem.SuperMarioBros3, 5);

            this.paymentProcessor = new PaymentProcessor(PaymentProcessorType.Stripe);
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

            return this.paymentProcessor.PayFor(OrderedItem, OrderQuantity);
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
