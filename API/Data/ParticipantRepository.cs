using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ParticipantRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ParticipantViewModel participant)
        {
            var newParticipant = _mapper.Map<Participant>(participant);
            _context.Entry(newParticipant).State = EntityState.Added;
        }

        public void Delete(Participant participant)
        {
            throw new System.NotImplementedException();
        }

        public Task<Participant> GetParticipantByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Participant>> GetParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public Task<IEnumerable<Participant>> GetParticipantsByCourseIdAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Participant>> GetParticipantsByParticipantIdAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}