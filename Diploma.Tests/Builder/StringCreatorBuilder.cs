using Diploma.Utils;
using Diploma.Wrappers;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Tests.Builder
{
    public class StringCreatorBuilder
    {
        private IConstants constants;
        private IDomainWrapper domainWrapper;

        public StringCreatorBuilder()
        {
            this.constants = Substitute.For<IConstants>();
            this.domainWrapper = Substitute.For<IDomainWrapper>();
        }

        public StringCreatorBuilder WithConstants(IConstants constants)
        {
            this.constants = constants;
            return this;
        }

        public StringCreatorBuilder WithDomainWrapper(IDomainWrapper domainWrapper)
        {
            this.domainWrapper = domainWrapper;
            return this;
        }

        public StringCreator Build()
        {
            return new StringCreator(constants, domainWrapper);
        }
    }
}
