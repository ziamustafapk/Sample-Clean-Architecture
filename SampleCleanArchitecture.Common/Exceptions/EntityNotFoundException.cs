namespace SampleCleanArchitecture.Common.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(Guid id, string entity)
            : base($"{entity} with id : {id} doesn't exist in the database.")
        {
        }
    }
}
