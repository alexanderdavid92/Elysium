namespace Elysium.Helpers
{
    using AutoMapper;
    using Elysium.HelperInterfaces;
    using Elysium.Manager.Dto;
    using Elysium.Models;

    public class EmployeeSettingsHelper : IEmployeeSettingsHelper
    {
        private static readonly IMapper ToViewModelMapper = CreateToViewModelMapper();
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();

        public EmployeeSettingsDto ConvertToDto(EmployeeSettingsViewModel employeeSettingsViewModel)
        {
            return ToDtoMapper.Map<EmployeeSettingsDto>(employeeSettingsViewModel);
        }

        public EmployeeSettingsViewModel ConvertToViewModel(EmployeeSettingsDto employeeSettingsDto)
        {
            return ToViewModelMapper.Map<EmployeeSettingsViewModel>(employeeSettingsDto);
        }
        private static IMapper CreateToViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSettingsDto, EmployeeSettingsViewModel>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeSettingsViewModel, EmployeeSettingsDto>();
            });

            return configuration.CreateMapper();
        }
    }
}