using cms.web.Models;
using cms.web.Service.Interface;
using Newtonsoft.Json;
namespace cms.web.Service
{
    public class CarService:ICar
    {
        public async Task<JQueryDataTableParamModel> GetCarDetailList(JQueryDataTableParamModel param,string sortCol)
        {
            JQueryDataTableParamModel jQueryDataTableParamModel = new JQueryDataTableParamModel();

            string queryString = $"?search={param.sSearch}&pageNumber={param.iDisplayStart+1}&pageSize={param.iDisplayLength}&sortDir={param.sSortDir_0}&sortCol={sortCol}";
            string fullUrl = queryString;
            var result = await ClientRequest.Get("getCarList" + queryString);
            DataTableParamModel newDataTable = JsonConvert.DeserializeObject<DataTableParamModel>(result);
            if (newDataTable.carViewModel != null)
            {
                jQueryDataTableParamModel.sEcho = param.sEcho;
                jQueryDataTableParamModel.iTotalRecords = newDataTable.totalRecords;
                jQueryDataTableParamModel.iTotalDisplayRecords = newDataTable.totalRecords;
                jQueryDataTableParamModel.aaData = newDataTable.carViewModel;
                return jQueryDataTableParamModel;
            }
            else
            {
                jQueryDataTableParamModel.sEcho = param.sEcho;
                jQueryDataTableParamModel.iTotalRecords = 0;
                jQueryDataTableParamModel.iTotalDisplayRecords = 0;
                jQueryDataTableParamModel.aaData = "";
                return jQueryDataTableParamModel;
            }
        }
        public async Task<CarRequestResponse> GetCarDetailByBradName(string brandName)
        {
            CarRequestResponse response = new CarRequestResponse();
            string queryString = $"?brand={brandName}";
            string fullUrl = queryString;
            var result = await ClientRequest.Get("getCarDetailByBrandName" + queryString);
            response = JsonConvert.DeserializeObject<CarRequestResponse>(result);
            if (response != null)
            {
                return response;
            }
            else
            {
                return new CarRequestResponse();
            }
        }
        public async Task<CarModelResponse> GetCarDetailByBrandClass(string brandName, string className)
        {
            CarModelResponse response = new CarModelResponse(); 
            string queryString = $"?brand={brandName}&className={className}";
            string fullUrl = queryString;
            var result= await ClientRequest.Get("getCarModelByBrandClassName"+queryString);
            response = JsonConvert.DeserializeObject<CarModelResponse>(result);
            if (response != null)
            {
                return response;
            }
            else {
                return new CarModelResponse();
            }
        }
        public async Task<ServiceResponse> AddEditCar(CarRequestResponse carVM)
        {
            ServiceResponse response = new ServiceResponse();
            var result = await ClientRequest.Post("addeditCar", carVM);
            return JsonConvert.DeserializeObject<ServiceResponse>(result);           
        }
        public async Task<ServiceResponse> AddEditCarModel(AddCarModelRequest carVM)
        {
            ServiceResponse response = new ServiceResponse();
            var result = await ClientRequest.PostCarModel("addeditCarModel", carVM);
            return JsonConvert.DeserializeObject<ServiceResponse>(result);           
        }
    }
}
