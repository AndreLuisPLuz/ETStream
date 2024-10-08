using ETStream.Application.Errors;
using ETStream.Application.Queries;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class SchoolQueryHandler : IQueryHandler<SchoolDetails, GetSchoolDetailsProps>
    {
        private IRepository<SchoolEntity> _repository;

        public SchoolQueryHandler(IRepository<SchoolEntity> repository)
        {
            _repository = repository;
        }

        public async Task<SchoolDetails> HandleAsync(Query<GetSchoolDetailsProps, SchoolDetails> query)
        {
            var school = await _repository.FindByIdAsync(query.Properties.SchoolId)
                    ?? throw new NotFoundException("School not found.");
            
            return new SchoolDetails
            {
                Id = school.Id,
                Description = school.Description
            };
        }
    }
}