using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.StoreVisitorPattern;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDepartment electronics = new ElectronicsDepartment();
            IDepartment clothing = new ClothingDepartment();
            IDepartment grocery = new GroceryDepartment();

            IVisitor shopper = new Shopper();

            electronics.Accept(shopper);
            clothing.Accept(shopper);
            grocery.Accept(shopper);
        }
    }

    namespace StoreVisitorPattern
    {
        public interface IDepartment
        {
            void Accept(IVisitor visitor);
            string GetSpecialOffer();
        }
        public interface IVisitor
        {
            void Visit(ElectronicsDepartment electronics);
            void Visit(ClothingDepartment clothing);
            void Visit(GroceryDepartment grocery);
        }
        public class ElectronicsDepartment : IDepartment
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public string GetSpecialOffer()
            {
                return "Скидка 20% на ноутбуки";
            }
        }
        public class ClothingDepartment : IDepartment
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public string GetSpecialOffer()
            {
                return "Купите одну рубашку и получите вторую бесплатно";
            }
        }

        public class GroceryDepartment : IDepartment
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public string GetSpecialOffer()
            {
                return "Скидка 10% на свежие фрукты";
            }
        }

        public class Shopper : IVisitor
        {
            public void Visit(ElectronicsDepartment electronics)
            {
                Console.WriteLine($"Отдел электроники: {electronics.GetSpecialOffer()}");
            }

            public void Visit(ClothingDepartment clothing)
            {
                Console.WriteLine($"Отдел одежды: {clothing.GetSpecialOffer()}");
            }

            public void Visit(GroceryDepartment grocery)
            {
                Console.WriteLine($"Отдел продуктов: {grocery.GetSpecialOffer()}");
            }
        }

    }
}
