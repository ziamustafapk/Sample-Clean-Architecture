using Microsoft.AspNetCore.Http;
using SampleCleanArchitecture.Common.RequestFeatures;

namespace SampleCleanArchitecture.Common.LinkModels
{
    public record LinkParameters(CustomerParameters CustomerParameters, HttpContext Context);
}
