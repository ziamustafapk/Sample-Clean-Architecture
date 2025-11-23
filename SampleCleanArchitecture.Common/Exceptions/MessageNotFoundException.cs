namespace SampleCleanArchitecture.Common.Exceptions
{
    public class MessageNotFoundException : NotFoundException
    {
        public MessageNotFoundException(string message) : base(message)
        {
        }
    }
}
