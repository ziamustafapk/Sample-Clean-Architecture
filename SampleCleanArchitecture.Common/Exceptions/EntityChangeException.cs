namespace SampleCleanArchitecture.Common.Exceptions
{
    public class EntityChangeException : NotFoundException
    {
        public EntityChangeException(string message) 
            : base(message)
        {
        }
    }
}
