namespace Elysium.Helpers
{
    using AutoMapper;
    using Elysium.HelperInterfaces;
    using Elysium.Manager.Dto;
    using Elysium.Models;

    public class EmployeeHelper : IEmployeeHelper
    {
        private static readonly IMapper ToViewModelMapper = CreateToViewModelMapper();
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();
        
        public EmployeeDto ConvertToDto(EmployeeViewModel employeeViewModel)
        {
            return ToDtoMapper.Map<EmployeeDto>(employeeViewModel);
        }

        public EmployeeViewModel ConvertToViewModel(EmployeeDto employeeDto)
        {
            return ToViewModelMapper.Map<EmployeeViewModel>(employeeDto);
        }

        private static IMapper CreateToViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDto, EmployeeViewModel>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, EmployeeDto>();
            });

            return configuration.CreateMapper();
        }
    }
}