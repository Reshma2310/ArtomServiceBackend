using Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserClass
    {
        UserResponse InsertUser(UserContract userContract);
    }
}
