using CustomerDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataAccessLayer.Repository
{
     public interface ICustomerRepository
     {
        public IEnumerable<CustomerDetail> GetAllCustomerDetails();
        public CustomerDetail GetbyCustomerID(long CustomerID);
        public void Insert(CustomerDetail detail);
        public void Update(long CustomerID, CustomerDetail detail);
        public void Deletebyid(long CustomerID);
    }
}
