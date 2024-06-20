using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application
{
    //This interface is use for Bussiness Rule / USE CASE
    public interface IMemberService
    {
        List<Domain.Member> GetAllMembers();
        Domain.Member AddMember(Domain.Member member);
        Domain.Member UpdateMember(Domain.Member member);
        void DeleteMember(int id);
    }
}
