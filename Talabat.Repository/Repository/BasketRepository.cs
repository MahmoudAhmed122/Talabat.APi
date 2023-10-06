﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.IRepositories;

namespace Talabat.Repository.Repository
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer  redis )  { 
        _database=redis.GetDatabase();  
        
        }   


        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);    
          
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var basket =await _database.StringGetAsync(basketId);   // Json
            return basket.IsNull ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var updateOrCreate = await _database.StringSetAsync(basket.Id , JsonSerializer.Serialize(basket),TimeSpan.FromDays(1));
            if (!updateOrCreate) return null;
            return await GetBasketAsync(basket.Id);

        }
    }
}
