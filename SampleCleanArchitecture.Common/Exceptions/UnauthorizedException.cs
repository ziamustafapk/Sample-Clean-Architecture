namespace SampleCleanArchitecture.Common.Exceptions
{
    public class UnauthorizedException :Exception
    {
        protected UnauthorizedException(string message) : base(message) { }
    }
}
