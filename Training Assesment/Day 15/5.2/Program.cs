using System;

namespace OrderProcessing
{
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private bool _discountApplied;

        public Order()
        {
            _orderId = 0;
            _customerName = "Unknown";
            _totalAmount = 0;
            _discountApplied = false;
        }

        public Order(int orderId, string customerName)
        {
            _orderId = orderId;
            CustomerName = customerName; // validation via property
            _totalAmount = 0;
            _discountApplied = false;
        }

        public int OrderId
        {
            get { return _orderId; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _customerName = value;
                }
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        public void AddItem(decimal price)
        {
            if (price > 0)
            {
                _totalAmount += price;
            }
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (!_discountApplied && percentage >= 1 && percentage <= 30)
            {
                decimal discount = _totalAmount * (percentage / 100);
                _totalAmount -= discount;
                _discountApplied = true;
            }
        }

        public string GetOrderSummary()
        {
            return $"Order Id: {OrderId}\n" +
                   $"Customer: {CustomerName}\n" +
                   $"Total Amount: {_totalAmount}\n" +
                   $"Status: NEW";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(101, "Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);

            Console.WriteLine(order1.GetOrderSummary());

            Console.WriteLine();

            Order order2 = new Order();
            order2.CustomerName = "Sachin";
            order2.AddItem(1000);

            Console.WriteLine(order2.GetOrderSummary());
        }
    }
}
