using AutoMapper;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.Requests;
using plagiarismModel.TableRequests.Results;
using plagiarismModel.TableRequests.UserAddresses;
using plagiarismModel.TableRequests.UserImages;
using plagiarismModel.TableRequests.Users;
using plagiarismModel.TableRequests.UsersPackageTypes;
using plagiarismModel.TableRequests.UsersUserTypes;

namespace plagiarismApp.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //users
            CreateMap<Database.Users, plagiarismModel.Users>();
            CreateMap<Database.Users, UsersInsertRequest>().ReverseMap();

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

            //UserAddresses
            CreateMap<Database.UserAddresses, plagiarismModel.UserAddresses>();
            CreateMap<Database.UserAddresses, UserAddressesUpsertRequest>().ReverseMap();

            //UsersUserTypes
            CreateMap<Database.UsersUserTypes, plagiarismModel.UsersUserTypes>();
            CreateMap<Database.UsersUserTypes, UsersUserTypesUpsertRequest>().ReverseMap();

            //Doucuments
            CreateMap<Database.Documents, plagiarismModel.Documents>();
            CreateMap<Database.Documents, DocumentsUpsertRequest>().ReverseMap();

            //Requests
            CreateMap<Database.Requests, plagiarismModel.Requests>().ReverseMap();
            CreateMap<Database.Requests, RequestsUpsertRequest>().ReverseMap();
        }
    }
}
