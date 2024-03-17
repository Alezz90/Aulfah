using Aulfah.BLL.Interfaces;
using Aulfah.BLL.Repository;
using Aulfah.DAL.Repositories;
using Aulfah.DataContex;
using System;

namespace Aulfah.DAL
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            // Initialize repositories
            ArtistRepository = new ArtistRepository(_context);
            CartRepository = new CartRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            OrdersRepository = new OrdersRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
            ProductRepository = new ProductRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            ShipmentRepository = new ShipmentRepository(_context);
            TrackRepository = new TrackRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public IArtistRepository ArtistRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IOrdersRepository OrdersRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IServiceRepository ServiceRepository { get; set; }
        public IShipmentRepository ShipmentRepository { get; set; }
        public ITrackRepository TrackRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }


    }
}