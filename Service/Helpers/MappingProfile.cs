using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Groups
            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupDto>();
            CreateMap<GroupEditDto, Group>();
            //Student
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentEditDto, Student>();
        }
    }
}
