using System;
using System.Collections.Generic;
using System.Text;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;

namespace MISA.ApplicationCore
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Method
        //Get list customer
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return customers;
        }

        //Get customer by id
        public Customer GetCustomerById(Guid customerId)
        {
            var customers = _customerRepository.GetCustomerById(customerId);
            return customers;

        }

        //Insert new customer
        public ServiceResult AddCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            //validate data
            //if data is invalid, message error will be created
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var message = new
                {
                    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng không để trống" },
                    userMsg = "Mã khách hàng không để trống",
                    code = MISACode.NotValid
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không đc để trống!";
                serviceResult.Data = message;
                return serviceResult;
            }

            //Check CustomerCode exist
            var res = _customerRepository.GetCustomerByCode(customerCode);
            if (res != null)
            {
                var message = new
                {
                    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng đã tồn tại" },
                    userMsg = "Mã khách hàng đã tồn tại",
                    code = MISACode.NotValid
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng đã tồn tại!";
                serviceResult.Data = message;
                return serviceResult;
            }
            //Insert data when it valid
            var rowAffects = _customerRepository.AddCustomer(customer);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Thêm thành công!";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }

        //Modify customer
        public ServiceResult UpdateCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            //Check CustomerCode exist
            var res = _customerRepository.GetCustomerById(customer.CustomerId);
            if (res == null)
            {
                var message = new
                {
                    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng không tồn tại" },
                    userMsg = "Mã khách hàng không tồn tại",
                    code = MISACode.NotValid
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không tồn tại!";
                serviceResult.Data = message;
                return serviceResult;
            }
            //Update data to customer
            var rowAffects = _customerRepository.UpdateCustomer(customer);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Sửa thành công!";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }
        //Delete customer
        public ServiceResult DeleteCustomer(Guid customerId)
        {
            var serviceResult = new ServiceResult();
            //Check CustomerCode exist
            var res = _customerRepository.GetCustomerById(customerId);
            if (res == null)
            {
                var message = new
                {
                    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng không tồn tại" },
                    userMsg = "Mã khách hàng không tồn tại",
                    code = MISACode.NotValid
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không tồn tại!";
                serviceResult.Data = message;
                return serviceResult;
            }
            //Delete data when it valid
            var rowAffects = _customerRepository.DeleteCustomer(customerId);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Xóa thành công!";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }
        #endregion
    }
}
