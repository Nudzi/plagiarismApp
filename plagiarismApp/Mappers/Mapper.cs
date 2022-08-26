using AutoMapper;
using plagiarismModel.Requests.UserImages;
using plagiarismModel.Requests.Results;
using plagiarismModel.Requests.UsersPackageTypes;
using plagiarismModel.Requests.UserAddresses;
using plagiarismModel.Requests.UsersUserTypes;

namespace plagiarismApp.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //users
            CreateMap<Database.Users, plagiarismModel.Users>();
            CreateMap<Database.Users, plagiarismModel.Requests.Users.UsersInsertRequest>().ReverseMap();

            //userTypes
            CreateMap<Database.UserTypes, plagiarismModel.UserTypes>();


            //images
            CreateMap<Database.UserImages, plagiarismModel.UserImages>();
            CreateMap<Database.UserImages, UserImagesUpsertRequest>().ReverseMap();

            //Results
            CreateMap<Database.Results, plagiarismModel.Results>();
            CreateMap<Database.Results, ResultsUpsertRequest>().ReverseMap();

            //PackageTypes
            CreateMap<Database.PackageTypes, plagiarismModel.PackageTypes>();

            //UsersPackageTypes
            CreateMap<Database.UsersPackageTypes, plagiarismModel.UsersPackageTypes>();
            CreateMap<Database.UsersPackageTypes, UsersPackageTypesUpsertRequest>().ReverseMap();

            //Results
            CreateMap<Database.UserAddresses, plagiarismModel.UserAddresses>();
            CreateMap<Database.UserAddresses, UserAddressesUpsertRequest>().ReverseMap();

            //UsersUserTypes
            CreateMap<Database.UsersUserTypes, plagiarismModel.UsersUserTypes>();
            CreateMap<Database.UsersUserTypes, UsersUserTypesUpsertRequest>().ReverseMap();
        }
    }
}
