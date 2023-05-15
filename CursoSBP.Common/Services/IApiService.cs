using CursoSBP.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoSBP.Common.Services
{
    public interface IApiService
    {
        Response GetApi(string url, string controller, string endpoint);
        Response PostApi(string url, string controller, string endpoint);
        Response PutApi(string url, string controller, string endpoint);
        Response DeleteApi(string url, string controller, string endpoint);
    }
}
