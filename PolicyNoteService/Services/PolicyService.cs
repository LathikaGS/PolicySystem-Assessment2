using PolicyNoteService.Models;
using PolicyNoteService.Repositories;

namespace PolicyNoteService.Services
{
    public class PolicyService
    {
        private readonly PolicyNoteRepository _repository;

        public PolicyService(PolicyNoteRepository repository)
        {
            _repository = repository;
        }

        public PolicyNote CreateNote(string policyNumber, string note)
        {
            var policyNote = new PolicyNote
            {
                PolicyNumber = policyNumber,
                Note = note
            };

            return _repository.Add(policyNote);
        }

        public List<PolicyNote> GetNotes()
        {
            return _repository.GetAll();
        }

        public PolicyNote? GetNote(int id)
        {
            return _repository.GetById(id);
        }
    }
}
