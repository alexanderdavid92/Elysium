namespace Elysium.Manager.Members
{
    using AutoMapper;
    using Elysium.Data.Interfaces;
    using Elysium.Entities;
    using Elysium.Manager.Dto;
    using Elysium.Manager.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeHistoryManager : IEmployeeHistoryManager
    {
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();
        private static readonly IMapper ToEntityMapper = CreateToEntityMapper();
        private IEmployeeHistoryData employeeHistoryData;
        public EmployeeHistoryManager(IEmployeeHistoryData _employeeHistoryData)
        {
            employeeHistoryData = _employeeHistoryData;
        }
        public void Add(EmployeeHistoryDto employeeHistoryDto)
        {
            var dbEntity = this.MapToEntity(employeeHistoryDto);
            this.employeeHistoryData.Add(dbEntity);
        }

        public void Delete(Guid Id)
        {
            this.employeeHistoryData.Delete(Id);
        }

        public void Edit(EmployeeHistoryDto employeeHistoryDto)
        {
            var dbEntity = this.MapToEntity(employeeHistoryDto);
            this.employeeHistoryData.Edit(dbEntity);
        }

        public IList<EmployeeHistoryDto> GetAll()
        {
            var employeeHistory = this.employeeHistoryData.GetAll().ToList();

            return employeeHistory.Select(x => MapToDto(x)).ToList();
        }

        public EmployeeHistoryDto GetById(Guid Id)
        {
            var dbEntity = this.employeeHistoryData.GetById(Id);
            return this.MapToDto(dbEntity);
        }
  
        private EmployeeHistory MapToEntity(EmployeeHistoryDto employeeHistory)
        {
            return ToEntityMapper.Map<EmployeeHistory>(employeeHistory);
        }

        private EmployeeHistoryDto MapToDto(EmployeeHistory employeeHistory)
        {
            return ToDtoMapper.Map<EmployeeHistoryDto>(employeeHistory);
        }
        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeHistory, EmployeeHistoryDto>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToEntityMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeHistoryDto, EmployeeHistory>();
            });

            return configuration.CreateMapper();
        }
    }
}
