namespace SampleCleanArchitecture.Common.Exceptions
{
    public class CompanyNoFoundException : NotFoundException
    {
        public CompanyNoFoundException(Guid id)
            : base($"Company with id : {id} doesn't exist in the database.")
        {
        }
    }
}
