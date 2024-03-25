using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulfah.BLL.Interfaces
{
    public interface IUnitofWork
    {
        public IArtistRepository ArtistRepository  { get; set; }
        public ICartRepository CartRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IOrdersRepository OrdersRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IServiceRepository ServiceRepository { get; set; }
        public IShipmentRepository ShipmentRepository { get; set; }
        public ITrackRepository TrackRepository { get; set; }
        public ICategoryRepository  CategoryRepository{ get; set; }
         
        public IProductImageRepository ProductImageRepository { get; set; }
    }
}
