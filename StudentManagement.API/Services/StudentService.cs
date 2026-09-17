using Microsoft.Extensions.Caching.Memory;
using StudentManagement.API.DTOs;
using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories;

namespace StudentManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly GuidService _guidService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<StudentService> _logger;
        public StudentService(
            IStudentRepository studentRepository,
            GuidService guidService,
            IMemoryCache cache,
            ILogger<StudentService> logger  )
        {
            _studentRepository = studentRepository;
            _guidService = guidService;
            _cache = cache;
            _logger = logger;
        }

        public async Task<List<Student>> GetStudentsAsync(
            StudentQueryDto query)
        {
            string cacheKey =
                $"students_{query.PageNumber}_{query.PageSize}_{query.Search}_{query.SortBy}_{query.SortDescending}";

            // Check cache
            if (_cache.TryGetValue(
                cacheKey,
                out List<Student>? cachedStudents))
            {
                _logger.LogInformation(
                    "CACHE HIT: {CacheKey}",
                    cacheKey);

                return cachedStudents!;
            }

            _logger.LogInformation(
                "CACHE MISS: {CacheKey}",
                cacheKey);

            // Get from database
            var students =
                await _studentRepository.GetStudentsAsync(query);

            // Store in cache
            _cache.Set(
                cacheKey,
                students,
                TimeSpan.FromMinutes(5));

            return students;
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public void AddStudent(CreateStudentRequestDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Email = dto.Email
            };

            _studentRepository.AddStudent(student);
        }

        public bool UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        public Guid GetGuid()
        {
            return _guidService.Id;
        }
    }
}