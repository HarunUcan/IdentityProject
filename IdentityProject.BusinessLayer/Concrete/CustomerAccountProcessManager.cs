﻿using IdentityProject.BusinessLayer.Abstract;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Delete(t);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccountProcessDal.GetList();
        }

        public CustomerAccountProcess TGetByID(int id)
        {
            return _customerAccountProcessDal.GetByID(id);
        }

        public void TInsert(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Insert(t);
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Update(t);
        }
    }
}
