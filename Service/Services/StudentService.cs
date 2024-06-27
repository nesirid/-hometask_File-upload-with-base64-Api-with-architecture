using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Students;
using Service.Services.Interface;


namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(StudentCreateDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await _studentRepo.CreateAsync(_mapper.Map<Student>(model));
        }

        public async Task EditAsync(int id, StudentEditDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var existingStudent = await _studentRepo.GetById(id);
            if (existingStudent == null) throw new KeyNotFoundException("Country not found");

            _mapper.Map(model, existingStudent);
            await _studentRepo.EditAsync(id, existingStudent);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _studentRepo.GetById(id);
            if (student == null) throw new KeyNotFoundException("Country not found");
            await _studentRepo.DeleteAsync(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.GetAllAsync());
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentRepo.GetById(id);
            if (student == null) throw new KeyNotFoundException("Country not found");
            return _mapper.Map<StudentDto>(student);
        }
    }
}