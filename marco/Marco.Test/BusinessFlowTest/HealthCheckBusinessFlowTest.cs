using Marco.BusinessFlow;
using Marco.Models;
using Marco.Repository;
using Moq;
using System.Linq.Expressions;

namespace Marco.Test
{
    [TestClass]
    public class HealthCheckBusinessFlowTest
    {
        private readonly Mock<IBaseRepository> _healthCheckRepository;
        private readonly HealthCheckBusinessFlow _healthCheckBusinessFlow;
        public HealthCheckBusinessFlowTest()
        {
            _healthCheckRepository = new Mock<IBaseRepository>();
            _healthCheckBusinessFlow = new HealthCheckBusinessFlow(_healthCheckRepository.Object);
        }
        [TestMethod]
        public void HeathCheckTestCase()
        {
            HealthCheckEntity healthCheck = new HealthCheckEntity() { id = 1, message = "I'm fine, Thank you :)" };
            _healthCheckRepository.Setup(x => x.GetByReplicaContext(It.IsAny<Expression<Func<HealthCheckEntity, bool>>>(), null, "", true)).Returns(new List<HealthCheckEntity>() { healthCheck });
            var result = _healthCheckBusinessFlow.HealthCheckFlow();
            Assert.AreEqual("I'm fine, Thank you :)", result.status);
        }
    }
}
