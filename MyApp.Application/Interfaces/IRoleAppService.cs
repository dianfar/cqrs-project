using MyApp.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IRoleAppService
    {
        Task<IEnumerable<RoleViewModel>> GetAll();
    }
}
