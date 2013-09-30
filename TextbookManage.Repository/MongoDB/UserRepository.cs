﻿using ByteartRetail.Domain.Model;
using ByteartRetail.Domain.Repositories.Specifications;
using ByteartRetail.Domain.Specifications;

namespace ByteartRetail.Domain.Repositories.MongoDB
{
    public class UserRepository : MongoDBRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        { }

        #region ICustomerRepository Members

        public bool UserNameExists(string userName)
        {
            return Exists(new UserNameEqualsSpecification(userName));
        }

        public bool EmailExists(string email)
        {
            return Exists(new UserEmailEqualsSpecification(email));
        }

        public bool CheckPassword(string userName, string password)
        {
            return Exists(new AndSpecification<User>(new UserNameEqualsSpecification(userName),
                new UserPasswordEqualsSpecification(password)));
        }

        public User GetUserByName(string userName)
        {
            return Find(new UserNameEqualsSpecification(userName));
        }

        public User GetUserByEmail(string email)
        {
            return Find(new UserEmailEqualsSpecification(email));
        }
        #endregion
    }
}
