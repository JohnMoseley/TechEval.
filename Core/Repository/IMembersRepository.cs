using Heuristics.TechEval.Core.Models;
using System.Collections.Generic;

namespace Heuristics.TechEval.Core.Repository
{
    public interface IMembersRepository
    {
        Member AddMember(Member member);
        Member EditMember(Member member);
        Member GetMemberById(int id);
        List<Member> ListMembers();
    }
}