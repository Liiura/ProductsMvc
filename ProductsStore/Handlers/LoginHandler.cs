using Microsoft.EntityFrameworkCore;
using ProductsStore.ContextDB;
using ProductsStore.ViewModels;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.Handlers
{
    public class LoginHandler
    {
        private readonly ProductsContext _DbProducts;
        public LoginHandler(ProductsContext _dbProduts)
        {
            _DbProducts = _dbProduts;
        }
        public async Task<SessionModel> SignIn(UserViewModel userData)
        {
            using (var context = _DbProducts)
            {
                userData.Password = ComputeStringToSha256Hash(userData.Password);
                var user = await context.UserClient.Where(x => x.UserName == userData.UserName && x.Password == userData.Password).FirstOrDefaultAsync();
                if (user != null)
                {
                    var sessionModel = new SessionModel
                    {
                        IdUser = user.Id,
                        RoleType = user.RoleType.Name,
                        UserName = user.UserName
                    };
                    return sessionModel;
                }
                return new SessionModel();

            }
        }
        public string ComputeStringToSha256Hash(string textToHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytesHash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textToHash));
                var stringBytesBuilder = new StringBuilder();
                for (int i = 0; i < bytesHash.Length; i++)
                {
                    stringBytesBuilder.Append(bytesHash[i].ToString("x2"));
                }
                return stringBytesBuilder.ToString();
            }
        }
    }
}
