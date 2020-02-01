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

    public class EmployeeManager : IEmployeeManager
    {
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();
        private static readonly IMapper ToEntityMapper = CreateToEntityMapper();
        private IEmployeeData employeeData;
        public EmployeeManager(IEmployeeData _employeeData)
        {
            employeeData = _employeeData;
        }
        public void Add(EmployeeDto employeeDto)
        {
            var dbEntity = this.MapToEntityMapper(employeeDto);
            this.employeeData.Add(dbEntity);
        }

        public void Delete(Guid Id)
        {
            this.employeeData.Delete(Id);
        }

        public void Edit(EmployeeDto employeeDto)
        {
            var dbEntity = this.MapToEntityMapper(employeeDto);
            this.employeeData.Edit(dbEntity);
        }

        public IList<EmployeeDto> GetAll()
        {
            var employeeDto = this.employeeData.GetAll().ToList();

            return employeeDto.Select(x => MapToDtoMapper(x)).ToList();
        }

        public EmployeeDto GetById(Guid Id)
        {
            var dbEntity = this.employeeData.GetById(Id);
            return this.MapToDtoMapper(dbEntity);
        }

        private EmployeeDto MapToDtoMapper(Employee employee)
        {
            return ToDtoMapper.Map<EmployeeDto>(employee);
        }

        private Employee MapToEntityMapper(EmployeeDto employeeDto)
        {
            return ToEntityMapper.Map<Employee>(employeeDto);
        }
        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDto>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToEntityMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDto, Employee>();
            });

            return configuration.CreateMapper();
        }
    }
}
