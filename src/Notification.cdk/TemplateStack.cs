using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.cdk
{
    public class TemplateStack : Stack
    {
        internal TemplateStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var messageTemplateStack = new Function(this, "Template", new FunctionProps
            {
                Runtime = new Runtime("dotnet6"),
                Code = Code.FromAsset("src/WhatsappNotification/WhatsappNotification/bin/Release/net6.0/publish"),
                Handler = "WhatsappNotification::WhatsappNotification.Templates::Post"
            });
            var app = new LambdaRestApi(this, "Endpoint", new LambdaRestApiProps
            {
                Handler = messageTemplateStack,
                Proxy = false
            }) ;

            var template = app.Root.AddResource("template");
            template.AddMethod("POST");
            
        }
    }
}
