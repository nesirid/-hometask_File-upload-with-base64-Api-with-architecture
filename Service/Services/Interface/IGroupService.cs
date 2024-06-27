using Service.DTOs.Admin.Groups;


namespace Service.Services.Interface
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllAsync();
        Task EditAsync(int id, GroupEditDto model);
        Task CreateAsync(GroupCreateDto model);
        Task DeleteAsync(int id);
        Task<GroupDto> GetByIdAsync(int id);
    }
}
