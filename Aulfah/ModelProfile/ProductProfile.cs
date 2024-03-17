using Aulfah.Models;
using Aulfah.PL.ModelsVM;
using AutoMapper;

namespace Aulfah.PL.ModelProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile() {
            CreateMap<ProductVM, Product>();
        }
    }
}
