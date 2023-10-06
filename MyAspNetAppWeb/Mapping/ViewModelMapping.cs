using AutoMapper;
using MyAspNetAppWeb.Models;
using MyAspNetAppWeb.ViewModels;

namespace MyAspNetAppWeb.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
             CreateMap<Product, ProductViewModel>().ReverseMap();


        }
    }
}
