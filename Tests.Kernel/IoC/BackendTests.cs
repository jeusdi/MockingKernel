using NUnit.Framework;
using Ninject;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;

namespace Tests.Kernel.IoC
{
    [TestFixture]
    public class BackendTests
    {

        private Ninject.IKernel ninjectKernel;
        private Core.IKernel coreKernel;
        private Core.Configuration.ICoreConfiguration coreConfiguration;

        [SetUp]
        public void setUp()
        {
            this.coreKernel = NSubstitute.Substitute.For<Core.IKernel>();
            this.coreConfiguration = NSubstitute.Substitute.For<Core.Configuration.ICoreConfiguration>();

            IEnumerable<Core.Configuration.UserIdentity> userIdentities = new List<Core.Configuration.UserIdentity>() { new Core.Configuration.UserIdentity() { UserId = "u1" } };
            this.coreConfiguration.UserIdentities.Returns(userIdentities);
            this.coreKernel.Configuration.Returns(this.coreConfiguration);

            //this.ninjectKernel = new StandardKernel(new Core.IoC.Modules.BackendModule());
        }

        [Test]
        public void test()
        {
            Core.Identity.DomainIdentity domainIdentity = null;

            Backend.Infrastructure.IBackend backend = this.ninjectKernel.Get<Backend.Infrastructure.IBackend>("lest", new Ninject.Parameters.Parameter("domainIdentity", domainIdentity, true));
            backend.Should().NotBeNull();
        }
    }
}
