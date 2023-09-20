using AutoMapper;
using ClearDemandCodeExcercise.Data.Model;

namespace ClearDemand.MarkdownPlan.Server.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Shared.Product>()
                .ForMember(dest => dest.Quantity,
                opt => opt.MapFrom(src => src.ProductStorages.Sum(x=>x.Quantity)));

            CreateMap<Shared.Product, Product>();

            CreateMap<ClearDemandCodeExcercise.Data.Model.MarkdownPlan, Shared.MarkdownPlan>();
            CreateMap<Shared.MarkdownPlan, ClearDemandCodeExcercise.Data.Model.MarkdownPlan>()
                .ForMember(d=>d.Product, o=>o.Ignore());

            CreateMap<ClearDemandCodeExcercise.Data.Model.MarkdownRule, Shared.MarkdownRule>();            
            CreateMap<Shared.MarkdownRule, ClearDemandCodeExcercise.Data.Model.MarkdownRule>();

            CreateMap<Shared.Sale, ClearDemandCodeExcercise.Data.Model.Sale>();
            CreateMap<ClearDemandCodeExcercise.Data.Model.Sale, Shared.Sale>();

            CreateMap<Shared.ProductStorage, ClearDemandCodeExcercise.Data.Model.ProductStorage>();
            CreateMap<ClearDemandCodeExcercise.Data.Model.ProductStorage, Shared.ProductStorage>();
        }
    }
}
