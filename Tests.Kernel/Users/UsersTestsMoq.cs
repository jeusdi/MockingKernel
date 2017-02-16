using NUnit.Framework;
using FluentAssertions;
using Ninject;
using System.Collections.Generic;
using NSubstitute;
using Ninject.MockingKernel.Moq;
using Ninject.MockingKernel;
using Moq;

namespace Tests.Kernel.Users.Moq
{
    [TestFixture]
    public class UsersManagementTests
    {
        private readonly MoqMockingKernel IoCKernel;

        public UsersManagementTests()
        {
            this.IoCKernel = new MoqMockingKernel();
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
            Mock<Core.Configuration.ICoreConfiguration> mockedConfiguration = this.IoCKernel.GetMock<Core.Configuration.ICoreConfiguration>();
            mockedConfiguration.Setup(c => c.UserIdentities).Returns(configurationUsers);

            //this.IoCKernel.Get<Core.Configuration.ICoreConfiguration>().UserIdentities.Returns(configurationUsers);
            //Core.IKernel kernel = this.IoCKernel.Get<Core.IKernel>();
            Core.Kernel mockedKernel = this.IoCKernel.Get<Core.Kernel>();

            //Act
            mockedKernel.Initialize();

            //Assert
            //kernel.Verify(k => k.AddUser(It.IsAny<Core.Identity.UserIdentity>()), Times.Once());

            mockedKernel.UserIdentities
                .Should()
                    .NotBeEmpty()
                    .And.HaveCount(1)
                    .And.OnlyContain(u => u.UserId.Equals(userConfiguration.UserId) && u.Password.Equals(userConfiguration.Password));
        }
    }
}
