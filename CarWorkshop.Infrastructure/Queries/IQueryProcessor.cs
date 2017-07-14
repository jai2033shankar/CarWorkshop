using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.Queries
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}
