using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOQSample
{
    public interface ICnovaApi
    {
        IList<Product> ConsultarProdutos(string status);
        IList<Product> ConsultarProdutos();
    }
}
