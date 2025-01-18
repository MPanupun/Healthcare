namespace Marco.BusinessFlow
{
    public class HealthCheckBusinessFlow
    {
        private readonly IBaseRepository baseRepository;
        public HealthCheckBusinessFlow(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public HealthCheckResponse HealthCheckFlow()
        {
            HealthCheckEntity healthCheck = this.baseRepository.GetByReplicaContext<HealthCheckEntity>(filter: a => a.id == 1).FirstOrDefault();
            HealthCheckResponse healthCheckResponse = new HealthCheckResponse
            {
                status = healthCheck?.message,
                version = Environment.GetEnvironmentVariable("API_VERSION")
            };
            return healthCheckResponse;
        }
    }
}
