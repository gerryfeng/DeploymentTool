using GraphQL.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Repositories
{
    public class DataStore : IDataStore
    {
        private ApplicationDbContext _context;

        public DataStore(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            var addedItem = await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return addedItem.Entity;
        }

        public Item GetItemByBarcode(string barcode)
        {
            return _context.Items.First(i => i.Barcode.Equals(barcode));
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers
                .FindAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var addedOrder = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return addedOrder.Entity;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var addedCustomer = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return addedCustomer.Entity;
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            var addedOrderItem = await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return addedOrderItem.Entity;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(o => o.OrderId == orderId)
                .ToListAsync();
        }
    }
}
