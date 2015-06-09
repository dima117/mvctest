using AutoMapper;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<ContentPage, ContentPageModel>();
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<CatalogSection, CatalogSectionModel>();

            Mapper
                .CreateMap<Product, CartItemModel>()
                .ForMember(l => l.ProductId, o => o.MapFrom(r => r.Id))
                .ForMember(l => l.ProductName, o => o.MapFrom(r => r.Name))
                .ForMember(l => l.ProductPrice, o => o.MapFrom(r => r.Price));
        }
    }
}