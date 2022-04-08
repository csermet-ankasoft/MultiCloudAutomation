using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiCloudAutomation
{
    public class ResponseClass
    {
        public string Content;
        public HttpStatusCode StatusCode;

        public ResponseClass(string responseContent, HttpStatusCode responseStatusCode)
        {
            this.Content = responseContent;
            this.StatusCode = responseStatusCode;
        }
    }
}
