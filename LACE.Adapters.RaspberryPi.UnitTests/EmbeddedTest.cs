using System;
using System.Collections.Generic;
using System.Text;
using LACE.Core.Content;

namespace LACE.Adapters.RaspberryPi.UnitTests
{
    public abstract class EmbeddedTest
    {
        protected readonly EmbeddedContentLoader ContentLoader = new EmbeddedContentLoader();
    }
}
