using System;

namespace PaymentProcessingApp
{
    public class PaymentMethods
    {
        private static Random random = new Random();

        public bool ProcessMastercardPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Mastercard payment: Account {accountNumber}, Amount {amount}");
            return random.Next(10) != 0; // 10% chance to fail
        }

        public bool ProcessVisaPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Visa payment: Account {accountNumber}, Amount {amount}");
            return random.Next(10) != 0; // 10% chance to fail
        }

        public bool ProcessDiscoverPayment(string accountNumber, double amount)
        {
            Console.WriteLine($"Processing Discover payment: Account {accountNumber}, Amount {amount}");
            return random.Next(10) != 0; // 10% chance to fail
        }
    }

    public delegate bool PaymentHandler(string accountNumber, double amount);

    public class PaymentProcessor
    {
        public bool ProcessPayment(PaymentHandler paymentHandler, string accountNumber, double amount)
        {
            return paymentHandler(accountNumber, amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentMethods paymentMethods = new PaymentMethods();
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            PaymentHandler mastercardHandler = new PaymentHandler(paymentMethods.ProcessMastercardPayment);
            PaymentHandler visaHandler = new PaymentHandler(paymentMethods.ProcessVisaPayment);
            PaymentHandler discoverHandler = new PaymentHandler(paymentMethods.ProcessDiscoverPayment);

            // Test Mastercard payment
            bool isOkay = paymentProcessor.ProcessPayment(mastercardHandler, "1234-1111-2222-1234", 100.00);
            if (!isOkay)
            {
                Console.WriteLine("[ALERT] Mastercard payment processing failed");
            }

            // Test Visa payment
            isOkay = paymentProcessor.ProcessPayment(visaHandler, "4321-2222-3333-4321", 150.00);
            if (!isOkay)
            {
                Console.WriteLine("[ALERT] Visa payment processing failed");
            }

            // Test Discover payment
            isOkay = paymentProcessor.ProcessPayment(discoverHandler, "5678-3333-4444-5678", 200.00);
            if (!isOkay)
            {
                Console.WriteLine("[ALERT] Discover payment processing failed");
            }
        }
    }
}
