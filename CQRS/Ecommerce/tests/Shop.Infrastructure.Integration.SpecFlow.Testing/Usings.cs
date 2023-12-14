// Global using directives

global using System.Data.Common;
global using System.Text;
global using Bogus;
global using FluentAssertions;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using Shop.Api.Graphs.Queries.Products;
global using Shop.Application.Checkouts;
global using Shop.Application.Checkouts.Imp;
global using Shop.Domain;
global using Shop.Domain.Clients;
global using Shop.Domain.Orders;
global using Shop.Infrastructure.Abstractions;
global using Shop.Infrastructure.Integration.SpecFlow.Testing.Mocks;
global using Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;
global using Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;
global using Shop.Infrastructure.Reads;
global using Xunit;