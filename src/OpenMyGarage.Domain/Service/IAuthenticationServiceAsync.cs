using Microsoft.AspNetCore.Mvc;
using OpenMyGarage.Domain.ViewModel;
using System.Threading.Tasks;

namespace OpenMyGarage.Domain.Service
{
    public interface IAuthenticationServiceAsync
    {
        Task<ActionResult> RegisterUser(RegisterViewModel vm);
        Task<ActionResult> LoginUser(LoginViewModel vm);
    }
}
