using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Contracts;
using RedisProvider;

namespace DataServices
{
     public class RedisService : IRedisProvider
    {
        public void Connect()
        {
            var redis = new Redis();
            redis.Connect();
        }
    }
}
