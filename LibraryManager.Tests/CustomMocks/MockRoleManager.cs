using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Tests.CustomMocks
{
    public class MockRoleManager : RoleManager<IdentityRole>
    {
        public MockRoleManager() : base(
            new Mock<IRoleStore<IdentityRole>>().Object,
            new Mock<IEnumerable<IRoleValidator<IdentityRole>>>().Object,
               new Mock<ILookupNormalizer>().Object,
               new IdentityErrorDescriber(),
               new Mock<ILogger<MockRoleManager>>().Object)
        { }

        public override Task<IdentityResult> CreateAsync(IdentityRole role)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
