using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.Services.Interface;


namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepo, IMapper mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await _groupRepo.CreateAsync(_mapper.Map<Group>(model));
        }

        public async Task EditAsync(int id, GroupEditDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var existinggroup = await _groupRepo.GetById(id);
            if (existinggroup == null) throw new KeyNotFoundException("Group not found");

            _mapper.Map(model, existinggroup);
            await _groupRepo.EditAsync(id, existinggroup);
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _groupRepo.GetById(id);
            if (group == null) throw new KeyNotFoundException("Group not found");
            await _groupRepo.DeleteAsync(group);
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _groupRepo.GetAllAsync());
        }

        public async Task<GroupDto> GetByIdAsync(int id)
        {
            var group = await _groupRepo.GetById(id);
            if (group == null) throw new KeyNotFoundException("Group not found");
            return _mapper.Map<GroupDto>(group);
        }
    }
}
