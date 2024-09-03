﻿using MediatR;
using YoutubeApi.Application.Interfaces.RedisCache;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuerry
    {
        public string CacheKey => "GetAllProducts";

        public double CacheTime => 60;
    }
}
