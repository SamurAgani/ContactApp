using ContactApp.BaseRepository;
using ContactApp.DBContext;
using ContactApp.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContactApp.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private IConfiguration _configuration { get; set; }
        public ContactRepository(ContactDBContext dBContext, IConfiguration Configuration) : base(dBContext)
        {
            _configuration = Configuration;
        }
        public void CreateContact(Contact Contact)
        {
            Add(Contact);
        }

        public void DeleteContact(Contact Contact)
        {
            Delete(Contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return GetAll();
        }

        public Contact GetById(int id)
        {
            return GetWithCondition(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateContact(Contact Contact)
        {
            Update(Contact);
        }

        public IEnumerable<Contact> GetContactsByUserIdAndText(int userId, string searchText)
        {
            var CS = _configuration.GetConnectionString("ContactDB");
            using (var connection = new SqlConnection(CS))
            {
                connection.Open();

                // Query using Dapper with parameters
                string query = @"
                SELECT *
                FROM Contacts
                WHERE UserId = @UserId
                AND (Name + Surname + Number) LIKE @SearchText";

                // Append '%' to the searchText to perform a partial match
                searchText = "%" + searchText + "%";

                // Execute the query with parameters
                var contacts = connection.Query<Contact>(query, new { UserId = userId, SearchText = searchText });

                return contacts;
            }
        }
    }
}
