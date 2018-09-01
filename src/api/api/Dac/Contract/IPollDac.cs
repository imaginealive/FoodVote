using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Dac.Contract
{
    public interface IPollDac
    {
        Poll Get(Expression<Func<Poll, bool>> expression);
        void Create(Poll document);
        void Update(Poll document);
        PollInfo GetSubmit(Expression<Func<PollInfo, bool>> expression);
        void SubmitPoll(PollInfo document);
    }
}
