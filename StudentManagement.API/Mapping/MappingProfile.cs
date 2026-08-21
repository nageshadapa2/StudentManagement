using AutoMapper;
using StudentManagement.API.DTOs;
using StudentManagement.API.Models;

namespace StudentManagement.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentResponseDto>();

            CreateMap<CreateStudentRequestDto, Student>();
        }

    }
}
