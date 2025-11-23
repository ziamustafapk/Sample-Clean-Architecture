namespace SampleCleanArchitecture.Dto.Responses
{
    public sealed class EntityNotFoundResponse : ApiNotFoundResponse 
    { 
        public EntityNotFoundResponse(Guid id, string entity) 
        : base($"{entity} with id: {id} is not found in db.") { }
    }
}
