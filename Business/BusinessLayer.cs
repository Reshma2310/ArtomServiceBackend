using Business.Inference;
using Common.Contract;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessLayer: IBusinessLayer
    {
        UserClass userClass = new UserClass();
        public UserResponse InsertUser(UserContract userContract)
        {
            try
            {
                return userClass.InsertUser(userContract);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
