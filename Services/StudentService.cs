using ta.Models;
using ta.Repositories;
using ta.Models.DTOS;
namespace ta.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<Student> CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Address = dto.Address,
                Birthday = dto.Birthday
            };
            await _repo.Add(student);
            return student;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Student> GetOne(Guid id)
        {
            return await _repo.GetOne(id);
        }
        public async Task<Student> UpdateStudent(UpdateStudentDto dto, Guid id)
        {
            Student? student = await GetOne(id);
            if (student == null) throw new Exception("student doesnt exist.");

            student.Name = dto.Name;
            student.Address = dto.Address;
            student.Birthday = dto.Birthday;

            await _repo.Update(student);
            return student;
        }
        public async Task DeleteStudent(Guid id)
        {
            Student? student = (await GetAll()).FirstOrDefault(h => h.Id == id);
            if (student == null) return;
            await _repo.Delete(student);
        }
    }
}
