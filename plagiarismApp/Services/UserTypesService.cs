using AutoMapper;
using plagiarismApp.Database;
using System.Collections.Generic;
using System.Linq;

namespace plagiarismApp.Services
{
    public class UserTypesService : IUserTypesService
    {
        private readonly plagiarismContext _context;
        private readonly IMapper _mapper;

        public UserTypesService(plagiarismContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public plagiarismModel.UserTypes GetById(int id)
        {
            var entity = _context.UserTypes.Find(id);

            return _mapper.Map<plagiarismModel.UserTypes>(entity);
        }
        public List<plagiarismModel.UserTypes> Get()
        {
            List<plagiarismModel.UserTypes> result = new List<plagiarismModel.UserTypes>();
            var lista = _context.UserTypes.ToList();

            foreach (var item in lista)
            {
                plagiarismModel.UserTypes userTypes = new plagiarismModel.UserTypes();
                userTypes.Name = item.Name;
                userTypes.Description = item.Description;
                userTypes.Id = item.Id;
                result.Add(userTypes);
            }
            return result;
        }

        public plagiarismModel.UserTypes isAdmin(int userTypesId)
        {
            var lista = _context.UserTypes.ToList();
            plagiarismModel.UserTypes result = new plagiarismModel.UserTypes();

            foreach (var item in lista)
            {
                if (item.Id == userTypesId)
                {
                    if (item.Name.Contains("Admin"))
                    {
                        result.Name = item.Name;
                        result.Description = item.Description;
                        result.Id = item.Id;

                        return result;
                    }

                }
            }
            return null;
        }
    }
}