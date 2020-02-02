namespace Elysium.HelperInterfaces
{
    public interface IHelper<T, X> where T : class
    {
        T ConvertToDto(X employeeViewModel);
        X ConvertToViewModel(T employeeDto);
    }
}
