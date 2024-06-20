using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Application;

namespace Member.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<IList<Domain.Member>> Get()
        {
            return Ok(this.memberService.GetAllMembers());
        }

        [HttpPost]
        public ActionResult<Domain.Member> Post(Domain.Member member)
        {
            var createdMember = memberService.AddMember(member);
            return CreatedAtAction(nameof(Get), new { id = createdMember.Id }, createdMember);
        }

        [HttpPut("{id}")]
        public ActionResult<Domain.Member> Put(int id, Domain.Member member)
        {
            member.Id = id;
            var updatedMember = memberService.UpdateMember(member);
            if (updatedMember == null)
            {
                return NotFound();
            }
            return Ok(updatedMember);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            memberService.DeleteMember(id);
            return NoContent();
        }
    }
}
