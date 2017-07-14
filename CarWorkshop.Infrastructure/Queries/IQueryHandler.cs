using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
