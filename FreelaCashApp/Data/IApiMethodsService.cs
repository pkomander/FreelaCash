using FreelaCashApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCashApp.Data
{
    public interface IApiMethodsService
    {
        Task<string> CreateAccountAsync(User user);
        Task<RetornoLogin> LoginAccountAsync(UserLogin userLogin);
        Task<UserUpdate> GetUsertAsync(string token);
        Task<UserUpdate> UpdateUsertAsync(string token, UserUpdate userUpdate, Image imagem);


        Task<List<Servico>> GetAllServicosAsync(string token);

    }
}
