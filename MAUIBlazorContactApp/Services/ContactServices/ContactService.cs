using MAUIBlazorContactApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIBlazorContactApp.Services.ContactServices
{
    public class ContactService : IContactRepository
    {
        public SQLiteAsyncConnection _db;
        string _dbPath;

        public ContactService(string dbPath)
        {
            _dbPath = dbPath;
            InitAsync();
        }

        private async Task InitAsync()
        {
            if (_db != null)
            {
                return;
            }

            _db = new SQLiteAsyncConnection(_dbPath);
            await _db.CreateTableAsync<ContactInfo>();
        }

        public async Task<bool> AddUpdateContactAsync(ContactInfo contact)
        {
            if (contact.Id > 0)
            {
                await _db.UpdateAsync(contact);
            }
            else
            {
                await _db.InsertAsync(contact);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteContactAsync(int UserId)
        {
            await _db.DeleteAsync<ContactInfo>(UserId);
            return await Task.FromResult(true);
        }

        public async Task<ContactInfo> GetContactByIdAsync(int UserId)
        {
            await InitAsync();
            return await Task.FromResult(await _db.Table<ContactInfo>().Where(p => UserId == p.Id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<ContactInfo>> GetContactsAsync()
        {
            await InitAsync();
            return await Task.FromResult(await _db.Table<ContactInfo>().ToListAsync());
        }
    }
}
