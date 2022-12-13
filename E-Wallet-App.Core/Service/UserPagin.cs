using AutoMapper;
using E_Wallet_App.Core.Interface.RepoInterface;
using E_Wallet_App.Entity.Dtos;
using E_Wallet_App.Entity.Helper;
using E_WalletApp.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet_App.Core.Service
{
    public class UserPagin : IUserPagin
    {
        private readonly ApplicationContext _appplication;
        private readonly IMapper _mapper;

        public UserPagin(ApplicationContext applicationContext, IMapper mapper)
        {
            _appplication = applicationContext;
            _mapper = mapper;
        }
        public async Task<PageList<UserDTO>> GetAllUser(PaginationParameter pagin)
        {
            //var page = await _appplication.users.Select(x => _mapper.Map<UserDTO>(x)).ToListAsync();

            //return PageList<UserDTO>.ToPageList(page, pagin.PageNumber, pagin.PageSize);

            {
                var page = await _appplication.users.Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    DOB = x.DOB,
                    DateCreated = x.DateCreated,
                    Gender = x.Gender

                }
              ).ToListAsync();
                return PageList<UserDTO>.ToPageList(page, pagin.PageNumber, pagin.PageSize);


            }



        }
    }
}