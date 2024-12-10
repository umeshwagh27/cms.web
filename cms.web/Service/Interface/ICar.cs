using cms.web.Models;

namespace cms.web.Service.Interface
{
    public interface ICar
    {
       Task<CarModelResponse> GetCarDetailByBrandClass(string brandName, string className);
       Task<CarRequestResponse> GetCarDetailByBradName(string brandName);
       Task<JQueryDataTableParamModel> GetCarDetailList(JQueryDataTableParamModel param, string sortCol);
       Task<ServiceResponse> AddEditCar(CarRequestResponse carVM);
       Task<ServiceResponse> AddEditCarModel(AddCarModelRequest carVM);
    }
}
