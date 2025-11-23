namespace SampleCleanArchitecture.Application.Utilities
{
    public class CustomerLinks :ICustomerLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<CustomerDto> _dataShaper;

        public CustomerLinks(LinkGenerator linkGenerator, IDataShaper<CustomerDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } =
            new Dictionary<string, MediaTypeHeaderValue>();

        public LinkResponse TryGenerateLinks(IEnumerable<CustomerDto> customersDto, string fields, Guid companyId, HttpContext httpContext)
        {

            var shapedCustomers = ShapeData(customersDto, fields);

            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkdedCustomers(customersDto, fields, companyId, httpContext, shapedCustomers);

            return ReturnShapedCustomers(shapedCustomers);
        }

        private List<Entity> ShapeData(IEnumerable<CustomerDto> customerDtos, string fields) =>
            _dataShaper.ShapeData(customerDtos, fields)
                .Select(e => e.Entity)
                .ToList();
        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private LinkResponse ReturnShapedCustomers(List<Entity> shapedCustomers) =>
            new LinkResponse { ShapedEntities = shapedCustomers };

        private LinkResponse ReturnLinkdedCustomers(IEnumerable<CustomerDto> customerDto,
            string fields, Guid companyId, HttpContext httpContext, List<Entity> shapedCustomers)
        {
            var customerDtoList = customerDto.ToList();

            for (var index = 0; index < customerDtoList.Count(); index++)
            {
                var customerLinks = CreateLinksForCustomer(httpContext, companyId, customerDtoList[index].Id, fields);
                shapedCustomers[index].Add("Links", customerLinks);
            }

            var customerCollection = new LinkCollectionWrapper<Entity>(shapedCustomers);
            var linkedCustomers = CreateLinksForCustomers(httpContext, customerCollection);

            return new LinkResponse { HasLinks = true, LinkedEntities = linkedCustomers };
        }

        private List<Link> CreateLinksForCustomer(HttpContext httpContext, Guid companyId, Guid id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, $"GetCustomersForCompany", values: new { companyId, id, fields }),
                    "self",
                    "GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, $"DeleteCustomerForCompany", values: new { companyId, id }),
                    "delete_customer",
                    "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, $"UpdateCustomerForCompany", values: new { companyId, id }),
                    "update_customer",
                    "PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext, $"PartiallyUpdateCustomerForCompany", values: new { companyId, id }),
                    "partially_update_customer",
                    "PATCH")
            };
            return links;
        }

        private LinkCollectionWrapper<Entity> CreateLinksForCustomers(HttpContext httpContext,
            LinkCollectionWrapper<Entity> customersWrapper)
        {
            customersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, $"GetCustomersForCompany", values: new { }),
                "self",
                "GET"));

            return customersWrapper;
        }

    }
}
