using PolicyNoteService.Data;
using PolicyNoteService.Models;
using Microsoft.EntityFrameworkCore;

namespace PolicyNoteService.Repositories
{
    public class PolicyNoteRepository
    {
        private readonly AppDbContext _context;

        public PolicyNoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public PolicyNote Add(PolicyNote note)
        {
            _context.PolicyNotes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public List<PolicyNote> GetAll()
        {
            return _context.PolicyNotes.ToList();
        }

        public PolicyNote? GetById(int id)
        {
            return _context.PolicyNotes.FirstOrDefault(x => x.Id == id);
        }
    }
}
