using Heuristics.TechEval.Core.Models;
using Heuristics.TechEval.Core.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heuristics.TechEval.Core.Repository
{
    /// <summary>
    /// Handles the Database calls for members
    /// </summary>
    public class MembersRepository : IMembersRepository
    {
        private readonly IDataContext context;

        public MembersRepository(IDataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Member> ListMembers()
        {
            List<Member> list = new List<Member>();
            try
            {
                list = this.context.Members.ToList();
            }
            catch
            {
                list = new List<Member>();
                throw;
            }
            return list;
        }

        public Member GetMemberById(int id)
        {
            Member item = null;
            try
            {
                item = context.Members.Find(id);
            }
            catch
            {
                item = null;
                throw;
            }
            return item;
        }

        public Member AddMember(Member member)
        {
            try
            {
                IsDuplicateMembersName(member);
                if (ValidateMember(member))
                {
                    context.Members.Add(member);
                    // May want to push this out to the calling process...
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
            return GetMemberById(member.Id);
        }

        public Member EditMember(Member member)
        {
            try
            {
                IsDuplicateMembersName(member);

                if (ValidateMember(member))
                {
                    context.Members.Attach(member);
                    // May want to push this out to the calling process...
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
            return GetMemberById(member.Id);
        }

        private void IsDuplicateMembersName(Member member)
        {
            bool duplicate = false;
            Member item = context.Members.FirstOrDefault(m => m.Name.ToLower() == member.Name.ToLower());
            if (item != null)
            {
                duplicate = (member.Id > 0 && member.Id != item.Id);
            }
            if (duplicate)
            {
                throw new ApplicationException($"Member {member.Name} is already in the database.");
            }
        }

        private bool ValidateMember(Member member)
        {
            MemberValidation rules = new MemberValidation();

            var results = rules.Validate(member);
            if (!results.IsValid)
            {
                StringBuilder errors = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    errors.Append($"Property: {failure.PropertyName} Error: {failure.ErrorMessage} Code: {failure.ErrorCode}{Environment.NewLine}");
                }
                throw new Exception(errors.ToString());
            }
            return true;
        }

    }
}
