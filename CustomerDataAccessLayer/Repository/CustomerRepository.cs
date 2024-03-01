using CustomerDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataAccessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly EFContext _contxt;
        public CustomerRepository(EFContext contxt)
        {
            _contxt = contxt;

        }
        public IEnumerable<CustomerDetail> GetAllCustomerDetails()
        {
            try
            {
                var result = _contxt.NewCustomer.FromSqlRaw("select * from NewCustomer").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CustomerDetail GetbyCustomerID(long CustomerID)
        {
            try
            {
                var result = _contxt.NewCustomer.FromSqlRaw<CustomerDetail>($"select * from NewCustomer where CustomerID={@CustomerID}");
                return result.ToList().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(CustomerDetail detail)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"exec NewCustomerInsert'{detail.Name}','{detail.Address}','{detail.phonenumber}','{detail.Email}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(long CustomerID, CustomerDetail detail)
        {
            try
            {
                var result = _contxt.Database.ExecuteSqlRaw($" exec NewCustomerupdate '{detail.CustomerID}' ,'{detail.Name}','{detail.Address}','{detail.phonenumber}','{detail.Email}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Deletebyid(long CustomerID)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"exec  NewCustomerDeletesp {CustomerID}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
