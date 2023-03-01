using Microsoft.AspNetCore.Mvc;
using Model;
using ServiceLayer.Interface;


namespace HouseRent.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly IUserService UserService;
        private readonly ICommonService CommonService;

        public AccountController(IConfiguration Configuration, IUserService UserService, ICommonService CommonService)
        {
            this.Configuration = Configuration;
            this.UserService = UserService;
            this.CommonService = CommonService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var userDetails = UserService.AuthenticateUser(loginModel.Email, loginModel.Password);
                if (userDetails.CustomerId > 0)
                {

                    return RedirectToAction("Profile", "Account");
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Register()
        {
            List<StateModel> stateList = CommonService.GetStateList();
            ViewBag.State = stateList;
            return View();

        }

        [HttpPost]
        public IActionResult Register(CustomerModel customer)
        {
            List<StateModel> stateList = CommonService.GetStateList();
            ViewBag.State = stateList;
            if (ModelState.IsValid==true)
            {
                bool userExists = UserService.UserAlreadyExists(customer.Email);
                if (userExists)
                {
                    ViewBag.Msg = "Kuch Aur Daal";
                    return View();
                }

                var obj = UserService.AddCustomerDetails(customer);
                return RedirectToAction("Login", "Account");

            }


            

            return View();



        }

        [HttpGet]
        public List<CityModel> GetCityList(int StateId)
        {
            return CommonService.GetCityList(StateId);
        }

       

        







    }
}
