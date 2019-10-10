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
        private IConstants _constants;
        private IDomainWrapper _domainWrapper;

        public StringCreatorBuilder()
        {
            this._constants = Substitute.For<IConstants>();
            this._domainWrapper = Substitute.For<IDomainWrapper>();
        }

        public StringCreatorBuilder WithConstants(IConstants constants)
        {
            this._constants = constants;
            return this;
        }

        public StringCreatorBuilder WithDomainWrapper(IDomainWrapper domainWrapper)
        {
            this._domainWrapper = domainWrapper;
            return this;
        }

        public StringCreator Build()
        {
            return new StringCreator(_constants, _domainWrapper);
        }
    }
}
