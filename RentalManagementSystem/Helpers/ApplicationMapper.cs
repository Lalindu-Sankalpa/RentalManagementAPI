using AutoMapper;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Helpers
{public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Contact, ContactModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Lense, LenseModel>().ReverseMap();
            CreateMap<Item, ItemModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Camera, CameraModel>().ReverseMap();
            CreateMap<CameraType, CameraTypeModel>().ReverseMap();
            CreateMap<Staffplan, StaffPlanModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}