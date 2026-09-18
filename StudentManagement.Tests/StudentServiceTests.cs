using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using StudentManagement.API.DTOs;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories;
using StudentManagement.API.Services;

public class StudentServiceTests
{
    [Fact]
    public async Task GetStudentsAsync_ReturnsStudents()
    {
        // Arrange

        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "John"
            },
            new Student
            {
                Id = 2,
                Name = "Ravi"
            }
        };

        var query = new StudentQueryDto
        {
            PageNumber = 1,
            PageSize = 10
        };

        var mockRepository =
            new Mock<IStudentRepository>();

        mockRepository
            .Setup(x => x.GetStudentsAsync(query))
            .ReturnsAsync(students);

        var cache = new MemoryCache(
            new MemoryCacheOptions());

        var guidService = new GuidService();

        var mockLogger =
            new Mock<ILogger<StudentService>>();

        var service =
            new StudentService(
                mockRepository.Object,
                guidService,
                cache,
                mockLogger.Object);

        // Act

        var result =
            await service.GetStudentsAsync(query);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}