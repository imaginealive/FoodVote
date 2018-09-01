using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Dac.Contract
{
    public interface IAccountDac
    {
        Account Get(Expression<Func<Account, bool>> expression);
        IEnumerable<Account> List(Expression<Func<Account, bool>> expression);
        void Create(Account document);
    }
}
