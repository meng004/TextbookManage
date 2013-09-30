﻿using ByteartRetail.Domain.Model;
using ByteartRetail.Domain.Repositories.Specifications;

namespace ByteartRetail.Domain.Repositories.MongoDB
{
    public class ShoppingCartRepository : MongoDBRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IRepositoryContext context)
            : base(context)
        {

        }

        #region IShoppingCartRepository Members

        public ShoppingCart FindShoppingCartByUser(User user)
        {
            return Find(new ShoppingCartBelongsToCustomerSpecification(user));
        }

        #endregion
    }
}
