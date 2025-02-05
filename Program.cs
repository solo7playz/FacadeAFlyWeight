using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaOrderFacade pizzaOrderFacade = new PizzaOrderFacade();

            string pizzaType = "Маргарита";
            string address = "Улица Пушкина, дом 1";
            decimal amount = 500.00m;

            pizzaOrderFacade.PlaceOrder(pizzaType, address, amount);
        }
    }
    public class Kitchen
    {
        public void PreparePizza(string pizzaType)
        {
            Console.WriteLine($"Готовим пиццу: {pizzaType}");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Пицца готова!");
        }
    }
    public class DeliveryService
    {
        public void DeliverPizza(string address)
        {
            Console.WriteLine($"Доставляем пиццу по адресу: {address}");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Пицца доставлена!");
        }
    }
    public class PaymentService
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Обработка оплаты на сумму: {amount} рублей");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Оплата успешно проведена!");
        }
    }
    public class PizzaOrderFacade
    {
        private Kitchen _kitchen;
        private DeliveryService _deliveryService;
        private PaymentService _paymentService;

        public PizzaOrderFacade()
        {
            _kitchen = new Kitchen();
            _deliveryService = new DeliveryService();
            _paymentService = new PaymentService();
        }

        public void PlaceOrder(string pizzaType, string address, decimal amount)
        {
            _kitchen.PreparePizza(pizzaType);
            _paymentService.ProcessPayment(amount);
            _deliveryService.DeliverPizza(address);
        }
    }
}
