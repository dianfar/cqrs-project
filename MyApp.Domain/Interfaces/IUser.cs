using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
