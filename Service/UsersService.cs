using HangfileService.Models;

namespace HangfileService.Service
{
    public class UsersService : IUsersService
    {
        public UsersService() { }
        
        public List<Users> GetUsers()
        {
            var user = new List<Users>
            {
                new Users
                {
                    Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Vũ Đức Long",
                    Sex = "Male",
                    Address = "Hà Nội",
                    DateOfBirth = new DateTime(2000, 10, 30)
                },
                new Users
                {
                    Id = new Guid("0f8fad5b-d9cb-469f-a165-708677289283"),
                    Name = "Vũ Minh Đức",
                    Sex = "Male",
                    Address = "Hà Nội",
                    DateOfBirth = new DateTime(2003, 10, 30)
                }
            };

            return user;
        }
    }
}
