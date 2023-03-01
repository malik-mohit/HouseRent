using Model;


namespace ServiceLayer.Interface
{
    public interface IUserService
    {
        bool UserAlreadyExists(string Email);
        CustomerModel AddCustomerDetails(CustomerModel customerModel);
        CustomerModel AuthenticateUser(string Email, string Password);
    }
}
