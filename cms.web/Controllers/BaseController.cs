using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        #region Fields
       // private IErrorLogService _errorLog;
       // protected IErrorLogService ErrorLog => _errorLog ?? (_errorLog = HttpContext.RequestServices.GetService<IErrorLogService>());

        private IHttpContextAccessor _accessor;
        protected IHttpContextAccessor Accessor => _accessor ?? (_accessor = HttpContext.RequestServices.GetService<IHttpContextAccessor>());
     
        #endregion

        public string GetSortingColumnName(int sortColumnNo)
        {
            return Accessor.HttpContext.Request.Query["mDataProp_" + sortColumnNo][0] ?? "Id";
        }          
    }
}
