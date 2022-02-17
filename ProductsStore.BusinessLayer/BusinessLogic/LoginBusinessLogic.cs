using ProductsStore.Data.ContextDB;
using ProductsStore.Presentation.SharedViewModels;
using ProductsStore.WebApi.Handlers;
using System.Threading.Tasks;

namespace ProductsStore.BusinessLayer.BusinessLogic
{
    public class LoginBusinessLogic
    {
        private readonly LoginHandler _LoginHandler;
        public LoginBusinessLogic(ProductsContext dbContext)
        {
            _LoginHandler = new LoginHandler(dbContext);
        }
        public async Task<SessionModel> SignInAsync(UserViewModel userData)
        {
            return await _LoginHandler.SignIn(userData);
        }
    }
}
