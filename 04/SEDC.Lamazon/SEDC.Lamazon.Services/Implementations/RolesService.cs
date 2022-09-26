using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class RolesService : IRolesService
    {
        private readonly IRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public RolesService(IRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _rolesRepository.GetAll();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public RoleViewModel GetRoleById(int id)
        {
            var role = _rolesRepository.GetById(id);
            return _mapper.Map <RoleViewModel>(role);
        }
    }
}
