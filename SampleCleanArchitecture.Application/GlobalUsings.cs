// System namespaces and commonly used namespaces for the project
global using System.Text;
global using System.Linq.Expressions;
global using System.Transactions;

// Microsoft namespaces
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Options;

global using Microsoft.Net.Http.Headers;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Routing;

// Third-party namespaces
global using AutoMapper;

// Project-specific namespaces

//Domain Layers
global using SampleCleanArchitecture.Domain.Models.Admin;
global using SampleCleanArchitecture.Domain.Models.Application;
global using SampleCleanArchitecture.Domain.Models.Identity;
global using SampleCleanArchitecture.Domain.Models.LookUp;
global using SampleCleanArchitecture.Domain.Jwt;

//Dto Layers
global using SampleCleanArchitecture.Dto.Admin.Company;
global using SampleCleanArchitecture.Dto.Application.Customer;
global using SampleCleanArchitecture.Dto.IdentityUser;
global using SampleCleanArchitecture.Dto.LookUp;
global using SampleCleanArchitecture.Dto.Responses;


// Common Layer
global using SampleCleanArchitecture.Common;
global using SampleCleanArchitecture.Common.LinkModels;
global using SampleCleanArchitecture.Common.RequestFeatures;
global using SampleCleanArchitecture.Common.Exceptions;

// Applicatio Layer
global using SampleCleanArchitecture.Application.Contract;
global using SampleCleanArchitecture.Application.ManagerContract;
global using SampleCleanArchitecture.Application.Service;
global using SampleCleanArchitecture.Application.DataShaping;

global using SampleCleanArchitecture.Infrastructure.BaseContract;

global using SampleCleanArchitecture.LoggerService;






