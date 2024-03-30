using MAUIBlazorContactApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIBlazorContactApp.Services.ContactServices
{
    public interface IContactRepository
    {
        Task<bool> AddUpdateContactAsync(ContactInfo contact);

        Task<bool> DeleteContactAsync(int UserId);

        Task<ContactInfo> GetContactByIdAsync(int UserId);

        Task<IEnumerable<ContactInfo>> GetContactsAsync(); 
    }
}
