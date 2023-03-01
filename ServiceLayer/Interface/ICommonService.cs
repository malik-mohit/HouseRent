using Model;


namespace ServiceLayer.Interface
{
    public interface ICommonService
    {
        List<StateModel> GetStateList();
        List<CityModel> GetCityList(int StateId);
    }
}
