using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Infrastructure.Shared.Services
{
    public class BaseService<TEntity>
    {
        protected readonly ILogger<TEntity> _logger;
        protected readonly HttpClient _httpClient;
        public BaseService(ILogger<TEntity> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
    }
}
