// See https://aka.ms/new-console-template for more information
using Amazon.CDK;
using Notification.cdk;

var app = new App();
new TemplateStack(app, "TemplateStack");

app.Synth();
