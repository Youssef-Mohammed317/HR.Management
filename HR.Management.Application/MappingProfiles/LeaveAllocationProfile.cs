using AutoMapper;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocationsWithDetails;
using HR.Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocation, GetAllLeaveAllocationsWithDetailsDto>().ReverseMap();
        }
    }
}
