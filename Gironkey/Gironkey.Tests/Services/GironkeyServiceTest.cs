using Gironkey.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gironkey.Tests.Services
{
    [TestClass]
    public class GironkeyServiceTest
    {

        [TestMethod]
        public void GironkeyService_CallHttp_ReturnData()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            var result = service.CallWeb();


            // Assert
            Assert.IsNotNull(service);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GironkeyService_CallLandgate_ReturnData()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            var result = service.CallLandgate("115.90114501745099,-31.915819563332345");


            // Assert
            Assert.IsNotNull(service);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GironkeyService_CallLandgate_ReturnDataJson()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            //var result = 
            service.CallLandgateJson();


            // Assert
            Assert.IsNotNull(service);
            //Assert.IsNotNull(result);
        } 
        
        [TestMethod]
        public void GironkeyService_CallLandgateGet_ReturnDataJson()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            //var result = 
            service.CallLandgateGetJson();
            
            // Assert
            Assert.IsNotNull(service);
            //Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void GironkeyService_CallNewUrl_ReturnDataJson()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            //var result = 
            service.CallNewUrl();
            
            // Assert
            Assert.IsNotNull(service);
            //Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void GironkeyService_CallLandgateWithPassword_ReturnDataJson()
        {
            // Arrange
            var service = new GironkeyService();

            // Act
            //var result = 
            service.CallLandgate("115.90114501745099,-31.915819563332345");
            
            // Assert
            Assert.IsNotNull(service);
            //Assert.IsNotNull(result);
        }
    }
}