using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using Domain.Entities.ProductModule;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

namespace Service.Profiles
{
    internal class PictureUrlResolver(IConfiguration configuration): IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            return source.PictureUrl is not null?$"{configuration.GetSection("Urls")["DefaultUrl"] }{source.PictureUrl}": string.Empty;
        }
    }
}
