using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.BLL.Abstract;
using TicketSales.DAL.Abstract;
using TicketSales.Model.Entities;
using TicketSales.Model.Enums;

namespace TicketSales.BLL.Concrete
{
    class UserService : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        #region Base Method
        public void Insert(User entity)
        {

            entity.Role = UserRole.Standart;
            _userDAL.Add(entity);
        }
        public void Update(User entity)
        {
            _userDAL.Update(entity);
        }
        public void Delete(User entity)
        {
            entity.IsActive = false;
            _userDAL.Update(entity);
        }
        public void DeleteByID(int entityID)
        {
            User user = Get(entityID);
            user.IsActive = false;
            _userDAL.Update(user);
        }
        public User Get(int entityID)
        {
            return _userDAL.Get(a => a.ID == entityID);
        }
        public ICollection<User> GetAll()
        {
            return _userDAL.GetAll();
        }

        #endregion

        public User GetUserByLoginData(string mail, string password)
        {
            User loginUser = _userDAL.Get(a => a.IsActive && a.Email == mail && a.Password == password);
            return loginUser;
        }

        //public List<Event> GetUsersWithEvents()
        //{
        //    return _userDAL.GetAll();
        //}
    }
}
