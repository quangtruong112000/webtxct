using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webtx.EF;

namespace webtx.DAO
{
    public class UserDao
    {
        WebTX db = null;
        public UserDao()
        {
            db = new WebTX();
        }
        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.iduser;
        }
        public bool Update(user entity)
        {
            try
            {
                var user = db.users.Find(entity.iduser);
                user.username = entity.username;
                if (!string.IsNullOrEmpty(entity.password))
                {
                    user.password = entity.password;
                }
                user.avatar = entity.avatar;
                user.name = entity.name;
                user.gmail = entity.gmail;
                user.phone = entity.phone;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public user GetById(string userName)
        {
            return db.users.SingleOrDefault(x => x.username == userName);
        }
        public int LoginForCus(string userName, string passWord)
        {
            var result = db.users.SingleOrDefault(x => x.username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.password == passWord)
                {
                    return 1;
                }
                else return 0;
            }
        }
    }
}