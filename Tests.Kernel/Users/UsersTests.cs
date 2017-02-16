using NUnit.Framework;
using FluentAssertions;
using Ninject;
using System.Collections.Generic;
using NSubstitute;
using Ninject.MockingKernel.NSubstitute;
using Ninject.MockingKernel;

namespace Tests.Kernel.Users
{
    [TestFixture]
    public class UsersManagementTests
    {
        private readonly NSubstituteMockingKernel IoCKernel;

        public UsersManagementTests()
        {
            this.IoCKernel = new NSubstituteMockingKernel();
            this.IoCKernel.Bind<Core.Kernel>().ToMock();
        }

        [SetUp]
        public void SetUp()
        {
            this.IoCKernel.Reset();
        }

        [Test(Description = "Configured Users are well loaded on Kernel")]
        public void InitializationWithUsersTest()
        {
            //Setup Data
            Core.Configuration.UserIdentity userConfiguration = Core.Configuration.UserIdentity.Create("u1", "p1");
            IEnumerable<Core.Configuration.UserIdentity> configurationUsers = new List<Core.Configuration.UserIdentity>() { userConfiguration };

            //Setup Mocks
            this.IoCKernel.Get<Core.Configuration.ICoreConfiguration>().UserIdentities.Returns(configurationUsers);
            Core.Kernel kernel = (Core.Kernel)this.IoCKernel.Get<Core.Kernel>();
            
            //Act
            kernel.Initialize();

            //Assert
            IEnumerable<NSubstitute.Core.ICall> calls = kernel.ReceivedCalls();
            kernel.Received(1).AddUser(Arg.Any<Core.Identity.UserIdentity>());

            kernel.UserIdentities
                .Should()
                    .NotBeEmpty()
                    .And.HaveCount(1)
                    .And.OnlyContain(u => u.UserId.Equals(userConfiguration.UserId) && u.Password.Equals(userConfiguration.Password));
        }
    }
}
