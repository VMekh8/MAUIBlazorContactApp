using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIBlazorContactApp.Data
{
    public class ContactInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
