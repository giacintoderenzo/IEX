using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX
{
    public abstract class IEXRequest
    {
        public abstract string GetEndpoint();
        public abstract Type GetResponseType();
        
        public const string ArgumentSeparator = ",";

        public IEXResponse ParseResponse(string response)
        {
            try
            {
                IEXResponse resp = (IEXResponse)Activator.CreateInstance(this.GetResponseType());
                resp.Deserialize(response);
                return resp;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
