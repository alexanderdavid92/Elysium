namespace Elysium.Helpers
{
    using AutoMapper;
    using Elysium.HelperInterfaces;
    using Elysium.Manager.Dto;
    using Elysium.Models;

    public class EmployeeHistoryHelper : IEmployeeHistoryHelper
    {
        private static readonly IMapper ToViewModelMapper = CreateToViewModelMapper();
        private static readonly IMapper ToDtoMapper = CreateToDtoMapper();

        public EmployeeHistoryDto ConvertToDto(EmployeeHistoryViewModel employeeHistoryViewModel)
        {
            return ToDtoMapper.Map<EmployeeHistoryDto>(employeeHistoryViewModel);
        }

        public EmployeeHistoryViewModel ConvertToViewModel(EmployeeHistoryDto employeeHistoryDto)
        {
            return ToViewModelMapper.Map<EmployeeHistoryViewModel>(employeeHistoryDto);
        }

        private static IMapper CreateToViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeHistoryDto, EmployeeHistoryViewModel>();
            });

            return configuration.CreateMapper();
        }

        private static IMapper CreateToDtoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeHistoryViewModel, EmployeeHistoryDto>();
            });

            return configuration.CreateMapper();
        }
    }
}