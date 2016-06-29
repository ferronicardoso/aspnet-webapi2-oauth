using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoModelo.Authentication.Infrastructure.Test
{
    [TestClass]
    public class AuthApplicationServiceTest
    {
        private AuthApplicationService authAppService;

        [TestInitialize]
        public void Init()
        {
            authAppService = new AuthApplicationService();
        }

        [TestMethod]
        public void Authentication()
        {
            var username = "admin";
            var password = "123456";
            var model = authAppService.Authentication(username, password.ToMD5());

            Assert.IsNotNull(model);
        }
        
        [TestMethod]
        public void UpdateLastAccess()
        {
            var id = 1;
            authAppService.UpdateLastAccess(id);
        }
    }
}
