using Microsoft.AspNetCore.Mvc;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// API danh mục khách hàng
    /// createdBy: vtminh (6/1/2021)
    /// </summary>
    public class CustomersController : BaseEntityController<Customer>
    {
        ICustomerService _baseService;

        public CustomersController(ICustomerService baseService):base(baseService)
        {
            _baseService = baseService;
        }
    }
}
