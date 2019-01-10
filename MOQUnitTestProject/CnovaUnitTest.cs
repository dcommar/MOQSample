using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MOQSample;

namespace MOQUnitTestProject
{
    [TestClass]
    public class CnovaUnitTest
    {
        private Mock<ICnovaApi> mock;

        [TestInitialize]
        public void InicializeMockObject()
        {
            mock = new Mock<ICnovaApi>(MockBehavior.Strict);

            mock.Setup(s => s.ConsultarProdutos()).Returns(() => null);

            //mock.Setup(s => s.ConsultarProdutos()).Returns(() => new List<Product>());

            mock.Setup(s => s.ConsultarProdutos("todos")).Returns(() => new List<Product>());

            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Id = new Random().Next(),
                Name = string.Format("Produto {0}", new Random().Next()),
                Status = "active",
                Value = new decimal(new Random(100).NextDouble()),
                Link = string.Format("http://www.rakuten.com.br/product/{0}/details.aspx", new Random().Next())
            });
            products.Add(new Product()
            {
                Id = new Random().Next(),
                Name = string.Format("Produto {0}", new Random().Next()),
                Status = "paused",
                Value = new decimal(new Random(100).NextDouble()),
                Link = string.Format("http://www.rakuten.com.br/product/{0}/details.aspx", new Random().Next())
            });
            products.Add(new Product()
            {
                Id = new Random().Next(),
                Name = string.Format("Produto {0}", new Random().Next()),
                Status = "inative",
                Value = new decimal(new Random(100).NextDouble()),
                Link = string.Format("http://www.rakuten.com.br/product/{0}/details.aspx", new Random().Next())
            });
            mock.Setup(s => s.ConsultarProdutos("all")).Returns(() => products);
        }

        [TestMethod]
        public void ConsultarProdutosTest()
        {
            CnovaApi service = new CnovaApi(mock.Object);

            var dados = service.ConsultarProdutos("all");

            Assert.IsNotNull(dados);
            Assert.AreEqual(true, dados.Count > 0);

            dados = service.ConsultarProdutos();

            Assert.IsNull(dados);

        }
    }
}
