using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandSwagger
{
    public class Credential
    {
        public static string clientId = "";
        public static string clientSecret = "";
        public static string tenantId = "";
        public static string subscriptionId = "";
        public static IAzure azure;

        public static string setCred()
        {            
            try
            {
                var credentials = SdkContext.AzureCredentialsFactory
                    .FromServicePrincipal(clientId, clientSecret, tenantId, AzureEnvironment.AzureGlobalCloud);

                azure = Microsoft.Azure.Management.Fluent.Azure.Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithSubscription(subscriptionId);
                return "OK";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }            
        }
    }
}
