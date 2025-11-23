using SampleCleanArchitecture.Infrastructure.Repositories.Utility;

namespace SampleCleanArchitecture.Infrastructure.Repositories.Extensions;

public static class RepositoryCustomerExtensions
{
    
    public static IQueryable<Customer> Search(this IQueryable<Customer> customers, CustomerParameters parameter)
    {
       // var searchResult = customers;
        var predicate = PredicateBuilder.New<Customer>(true);

        if (!string.IsNullOrWhiteSpace(parameter.FullName))
            predicate = predicate.And(s => s.FirstName.ToLower().Contains(parameter.FullName.ToLower())
                                                || s.MiddleName.ToLower().Contains(parameter.FullName.ToLower())
                                                || s.LastName.ToLower().Contains(parameter.FullName.ToLower()));


        if (!string.IsNullOrWhiteSpace(parameter.Email))
            predicate = predicate.And(s => s.Email.ToLower().Contains(parameter.Email.ToLower()));

        if (!string.IsNullOrWhiteSpace(parameter.Phone))
            predicate = predicate.And(s => s.Phone.ToLower().Contains(parameter.Phone.ToLower())
                                             || s.Mobile.ToLower().Contains(parameter.Phone.ToLower())
            );

       
        if (parameter.RefCustomerTypeId.HasValue && parameter.RefCustomerTypeId.Value !=0)
        {
            predicate = predicate.And(s => s.RefCustomerTypeId == parameter.RefCustomerTypeId);
        }
        if (parameter.IsDeleted.HasValue)
            predicate = predicate.And(s => s.IsDeleted == parameter.IsDeleted);



        return customers.Where(predicate);
    }

    public static IQueryable<Customer> Sort(this IQueryable<Customer> customers, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return customers.OrderBy(cu => cu.FirstName);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Customer>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return customers.OrderBy(cu => cu.FirstName);

        return customers.OrderBy(orderQuery);
    }
}