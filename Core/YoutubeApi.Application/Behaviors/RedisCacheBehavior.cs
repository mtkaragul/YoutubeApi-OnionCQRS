﻿using MediatR;
using YoutubeApi.Application.Interfaces.RedisCache;

namespace YoutubeApi.Application.Behaviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (request is ICacheableQuerry querry)
            {
                var cacheKey = querry.CacheKey;
                var cacheTime = querry.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedData is not null) //eğer cache in içi doluysa döndür değilse doldur içini
                    return cachedData;

                var response = await next();
                if (response is not null )
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

                return response;
            }
            return await next();


        }
    }
}
