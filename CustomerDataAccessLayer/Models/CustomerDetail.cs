using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataAccessLayer.Models
{
     public class CustomerDetail
     {
        [Key]

        public long CustomerID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public long phonenumber { get; set; }
        

        public string Email { get; set; }
       
    }
}
