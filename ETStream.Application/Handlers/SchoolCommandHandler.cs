using ETStream.Application.Commands;
using ETStream.Application.Errors;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class SchoolCommandHandler : ICommandHandler<Guid, CreateSchoolProperties>
    {
        private readonly IRepository<SchoolEntity> _repository;

        public SchoolCommandHandler(IRepository<SchoolEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(Command<CreateSchoolProperties> command)
        {
            var newSchool = SchoolEntity.CreateNew(command.Properties.Description);
            var savedSchool = await _repository.UpsertAsync(newSchool)
                    ?? throw new UpsertFailException("Could not save school.");

            return savedSchool.Id;
        }
    }
}