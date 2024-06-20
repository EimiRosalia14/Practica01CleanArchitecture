using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Application;

namespace Member.Infrastructure
{
    public class MemberRepository : IMemberRepository
    {
        public static List<Domain.Member> lstMembers = new List<Domain.Member>()
        {
           new Domain.Member{  Id =1 ,Name= "Kirtesh Shah", Type ="G" , Address="Vadodara"},
           new Domain.Member{  Id =2 ,Name= "Mahesh Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =3 ,Name= "Nitya Shah", Type ="G" , Address="Mumbai"},
           new Domain.Member{  Id =4 ,Name= "Dilip Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =5 ,Name= "Hansa Shah", Type ="S" , Address="Dabhoi"},
           new Domain.Member{  Id =6 ,Name= "Mita Shah", Type ="G" , Address="Surat"}
        };
        public List<Domain.Member> GetAllMembers()
        {
            return lstMembers;
        }

        public Domain.Member AddMember(Domain.Member member)
        {
            member.Id = lstMembers.Max(m => m.Id) + 1;  // simple ID increment
            lstMembers.Add(member);
            return member;
        }

        public Domain.Member UpdateMember(Domain.Member member)
        {
            var existingMember = lstMembers.FirstOrDefault(m => m.Id == member.Id);
            if (existingMember != null)
            {
                existingMember.Name = member.Name;
                existingMember.Type = member.Type;
                existingMember.Address = member.Address;
                return existingMember;
            }
            return null;
        }

        public void DeleteMember(int id)
        {
            var member = lstMembers.FirstOrDefault(m => m.Id == id);
            if (member != null)
            {
                lstMembers.Remove(member);
            }
        }
    }
}
