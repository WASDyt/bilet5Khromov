using bilet5Khromov.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilet5Khromov.Services
{
    public class OrderService
    {
        public List<Order> GetOrders()
        {
            using (var context = new bilet5KhromovEntities())
            {
                return context.Order.ToList();
            }
        }

        public void AddOrder(Order order)
        {
            using (var context = new bilet5KhromovEntities())
            {
                context.Order.Add(order);
                context.SaveChanges();
            }
        }

        public void EditOrder(Order order) 
        {
            using (var context = new bilet5KhromovEntities())
            {
                var existingOrder = context.Order.Find(order.idOrder);
                if (existingOrder != null)
                {
                    existingOrder.idUser = order.idUser;
                    existingOrder.order_date = order.order_date;
                    existingOrder.quantity = order.quantity;
                    existingOrder.idProduct = order.idProduct;


                    context.SaveChanges();
                }
            }
        }

        public void DeleteOrder(int orderID)
        {
            using (var context = new bilet5KhromovEntities())
            {
                var order = context.Order.Find(orderID);
                if (order != null)
                {
                    context.Order.Remove(order);
                    context.SaveChanges();
                }
            }
        }
    }
}
