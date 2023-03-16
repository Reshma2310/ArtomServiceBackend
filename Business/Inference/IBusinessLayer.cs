using Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Inference
{
    public interface IBusinessLayer
    {
        UserResponse InsertUser(UserContract userContract);
    }
}
