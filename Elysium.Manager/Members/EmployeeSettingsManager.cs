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

    public class EmployeeSettingsManager : IEmployeeSettingsManager
    {
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();
        private static readonly IMapper ToEntityMapper = CreateToEntityMapper();
        private IEmployeeSettingsData employeeSettingsData;
        public EmployeeSettingsManager(IEmployeeSettingsData _employeeSettingsData)
        {
            employeeSettingsData = _employeeSettingsData;
        }
        public void Add(EmployeeSettingsDto employeeSettingsDto)
        {
            var dbEntity = this.MapToEntity(employeeSettingsDto);
            this.employeeSettingsData.Add(dbEntity);
        }

        public void Delete(Guid Id)
        {
            this.employeeSettingsData.Delete(Id);
        }

        public void Edit(EmployeeSettingsDto employeeSettingsDto)
        {
            var dbEntity = this.MapToEntity(employeeSettingsDto);
            this.employeeSettingsData.Edit(dbEntity);
        }

        public IList<EmployeeSettingsDto> GetAll()
        {
            var employeeSettings = this.employeeSettingsData.GetAll().ToList();

            return employeeSettings.Select(x => MapToDto(x)).ToList();
        }

        public EmployeeSettingsDto GetById(Guid Id)
        {
            var dbEntity = this.employeeSettingsData.GetById(Id);
            return this.MapToDto(dbEntity);
        }

        private EmployeeSettingsDto MapToDto(EmployeeSettings employeeSettings)
        {
            return ToDtoMapper.Map<EmployeeSettingsDto>(employeeSettings);
        }

        private EmployeeSettings MapToEntity(EmployeeSettingsDto employeeSettingsDto)
        {
            return ToEntityMapper.Map<EmployeeSettings>(employeeSettingsDto);
        }
        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSettings, EmployeeSettingsDto>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToEntityMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSettingsDto, EmployeeSettings>();
            });

            return configuration.CreateMapper();
        }
    }
}
