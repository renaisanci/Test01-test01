using Cleverbit.CodingTask.Application.Responses;
using Cleverbit.CodingTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Application.Mapping
{
    public static class MapUser
    {

        public static UserResponse MapToUserResponse(this User user)
        {

       
                return new UserResponse
                {
                    UserName = user?.UserName

                };
        }


    }
}
