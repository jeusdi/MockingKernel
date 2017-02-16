using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Core.IoC.Modules
{
    public class ServiceModule : Ninject.Modules.NinjectModule
    {

        private Core.Communication.ICoreService serviceTarget;

        public ServiceModule(Core.Communication.ICoreService serviceTarget)
        {
            this.serviceTarget = serviceTarget;
        }

        public override void Load()
        {
            this.Bind<System.ServiceModel.ServiceHost>().ToProvider(new ServiceProvider(this.serviceTarget));
        }
    }

    public class ServiceProvider : IProvider<System.ServiceModel.ServiceHost>
    {

        private Core.Communication.ICoreService serviceTarget;

        public ServiceProvider(Core.Communication.ICoreService serviceTarget)
        {
            this.serviceTarget = serviceTarget;
        }

        public object Create(IContext context)
        {
            return this.InitializeSOAPServiceOldConfiguration();
        }

        public Type Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private System.ServiceModel.ServiceHost InitializeSOAPService()
        {

            log4net.LogManager.GetLogger("").Info("Configuring Kernel SOAP Service");

            List<IPAddress> ips = new List<IPAddress>();
            ips.AddRange(Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == AddressFamily.InterNetwork));

            if (ips.Any())
            {
                System.ServiceModel.ServiceHost serviceHost = new System.ServiceModel.ServiceHost(this);

                foreach (var ip in Enumerable.Repeat(IPAddress.Loopback, 1))
                {
                    log4net.LogManager.GetLogger("").Info(string.Format("Adding Endpoint {0}:{1}", ip, 8733));

                    string stringURI = string.Empty;

                    stringURI = string.Format(
                        "http://{0}:{1}/CoreInterface/",
                        ip,
                        9997
                    );

                    System.Uri uri = new System.Uri(stringURI);
                    System.Uri mexUri = new System.Uri(uri, "mex");

                    serviceHost.AddServiceEndpoint(
                        typeof(Core.Communication.ICoreService),
                        new System.ServiceModel.WSHttpBinding(),
                        uri
                    );

                    System.ServiceModel.Description.ServiceMetadataBehavior smb = serviceHost.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>();
                    bool addSMB = smb == null;
                    smb = smb ?? new System.ServiceModel.Description.ServiceMetadataBehavior();

                    smb.HttpGetEnabled = true;
                    smb.HttpGetUrl = mexUri;

                    smb.MetadataExporter.PolicyVersion = System.ServiceModel.Description.PolicyVersion.Policy15;
                    if (addSMB)
                        serviceHost.Description.Behaviors.Add(smb);

                    serviceHost.AddServiceEndpoint(
                        System.ServiceModel.Description.ServiceMetadataBehavior.MexContractName,
                        System.ServiceModel.Description.MetadataExchangeBindings.CreateMexHttpBinding(),
                        mexUri
                    );
                }

                return serviceHost;
            }

            return null;
        }

        private System.ServiceModel.ServiceHost InitializeSOAPServiceOldConfiguration()
        {
            //string baseAdress = "http://localhost:8733/CoreInterface/";
            //System.Uri baseAddressUri = new System.Uri(baseAdress);

            System.ServiceModel.ServiceHost serviceHost = new System.ServiceModel.ServiceHost(this.serviceTarget);
            /*this.serviceHost.AddServiceEndpoint(
                typeof(Core.Communication.ICoreService),
                new System.ServiceModel.WSHttpBinding(),
                string.Empty
            );*/

            /*System.ServiceModel.Description.ServiceMetadataBehavior smb = this.serviceHost.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>();
            smb = smb ?? new System.ServiceModel.Description.ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = new System.Uri(baseAdress);
            //smb.MetadataExporter.PolicyVersion = System.ServiceModel.Description.PolicyVersion.Policy15;
            this.serviceHost.Description.Behaviors.Add(smb);*/

            return serviceHost;

            //log4net.LogManager.GetLogger("").Info("Starting SOAP Service");
            //serviceHost.Open();
            //log4net.LogManager.GetLogger("").Info("SOAP Service Started");
        }

    }
}
