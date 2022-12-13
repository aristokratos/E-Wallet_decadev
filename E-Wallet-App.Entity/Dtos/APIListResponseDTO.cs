using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Wallet_App.Entity.Dtos.APIListResponseDTO;
using static E_Wallet_App.Entity.Dtos.APIListResponseDTO;

namespace E_Wallet_App.Entity.Dtos
{
    public class APIListResponseDTO : ApiResponse
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public static APIListResponseDTO Success(object data, int page, int totalPage, int totalCount, bool hasPreviousPage, bool hasNextPage)
        {
            return new APIListResponseDTO
            {
                Page = page,
                TotalPages = totalPage,
                TotalCount = totalCount,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                Data = data
            };
        }



    }
}