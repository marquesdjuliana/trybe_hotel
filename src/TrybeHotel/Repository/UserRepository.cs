using TrybeHotel.Models;
using TrybeHotel.Dto;
using System.Security.Authentication;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var foundUser = _context.Users.FirstOrDefault(u => u.Email == login.Email);

            if (foundUser == null || foundUser.Password != login.Password)
            {
                throw new AuthenticationException("Incorrect e-mail or password");
            }

            return new UserDto
            {
                UserId = foundUser.UserId,
                Name = foundUser.Name,
                Email = foundUser.Email,
                UserType = foundUser.UserType
            };
        }

        public UserDto Add(UserDtoInsert user)
        {

            var existingUser = _context.Users.FirstOrDefault(e => e.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("User email already exists");
            }

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            };

            var addedUser = _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserDto
            {
                UserId = addedUser.Entity.UserId,
                Name = addedUser.Entity.Name,
                Email = addedUser.Entity.Email,
                UserType = addedUser.Entity.UserType
            };
        
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
           var users = _context.Users
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Email = u.Email,
                    UserType = u.UserType
                })
                .ToList();

            return users;
        }

    }
}