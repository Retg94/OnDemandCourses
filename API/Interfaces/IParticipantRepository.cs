using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IParticipantRepository
    {
        void Add(ParticipantViewModel participant);
        Task<IEnumerable<Participant>> GetParticipantsAsync();
        Task<IEnumerable<Participant>> GetParticipantsByCourseIdAsync();
        Task<IEnumerable<Participant>> GetParticipantsByParticipantIdAsync();
        Task<Participant> GetParticipantByIdAsync(int id);
        void Delete(Participant participant);
        Task<bool> SaveAllAsync();
    }
}