using Service.DTOs.Admin.Students;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task EditAsync(int id, StudentEditDto model);
        Task CreateAsync(StudentCreateDto model);
        Task DeleteAsync(int id);
        Task<StudentDto> GetByIdAsync(int id);
    }
}
