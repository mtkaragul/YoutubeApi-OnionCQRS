﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using ECommerceApi.Domain.Common;

namespace ECommerceApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()

    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, 
            // t ture yada flase bize bir cevap verecek misal Age>30 T olabilir
            //eğer bu doğru ise Expression devreye girecek ve predicate i vereceğiz gibi bir şey olucak

            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        //burada null değil predicate çünkü ben id ile filan çağıracağım için null olmasını istemiyorum 
        //sadece 1 veriyi döndüreceğim için bnnda orderBy a gerek kalmayacaktır.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    }
}
