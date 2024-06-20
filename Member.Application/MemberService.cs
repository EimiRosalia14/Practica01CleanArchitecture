using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application
{
    //Implement Bussiness Rule / USE CASES
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        List<Domain.Member> IMemberService.GetAllMembers()
        {
            return this.memberRepository.GetAllMembers();
        }

        public Domain.Member AddMember(Domain.Member member)
        {
            return memberRepository.AddMember(member);
        }

        public Domain.Member UpdateMember(Domain.Member member)
        {
            return memberRepository.UpdateMember(member);
        }

        public void DeleteMember(int id)
        {
            memberRepository.DeleteMember(id);
        }
    }
}
