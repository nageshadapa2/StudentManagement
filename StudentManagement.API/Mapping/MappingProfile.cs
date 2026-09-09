using AutoMapper;
using StudentManagement.API.DTOs.Responses;
using StudentManagement.API.DTOs.Requests;
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
