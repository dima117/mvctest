﻿using AutoMapper;
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
        }
    }
}