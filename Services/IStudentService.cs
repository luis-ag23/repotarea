using ta.Models;
using ta.Models.DTOS;
namespace ta.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetOne(Guid id);
        Task<Student> CreateStudent(CreateStudentDto dto);
        Task<Student> UpdateStudent(UpdateStudentDto dto, Guid id);
        Task DeleteStudent(Guid id);
    }
}
