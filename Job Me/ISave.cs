using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JobMe
{
    public interface ISave
    {
       
        Stream LoadFromFile(string fileName);

    }

}
