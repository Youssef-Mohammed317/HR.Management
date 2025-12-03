using AutoMapper;
using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveTypeProfile  : Profile
    {
        public LeaveTypeProfile() 
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
