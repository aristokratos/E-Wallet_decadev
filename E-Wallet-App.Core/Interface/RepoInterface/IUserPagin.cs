using E_Wallet_App.Entity.Dtos;
using E_Wallet_App.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Core.Interface.RepoInterface
{
    public interface IUserPagin
    {
        Task<PageList<UserDTO>> GetAllUser(PaginationParameter pagin);
    }
}