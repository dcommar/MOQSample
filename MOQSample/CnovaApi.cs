using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOQSample
{
    public class CnovaApi
    {
        public ICnovaApi _service;

        public CnovaApi(ICnovaApi service)
        {
            _service = service;
        }

        public IList<Product> ConsultarProdutos()
        {
            IList<Product> list = new List<Product>();
            list = _service.ConsultarProdutos();

            return list;
        }

        public IList<Product> ConsultarProdutos(string status)
        {
            IList<Product> list = new List<Product>();
            list = _service.ConsultarProdutos(status);

            return list;
        }


    }
}
