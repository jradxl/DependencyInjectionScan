using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceRegisterDescriptorProviderContext
    {
        public IList<ServiceRegisterDescriptor> Results { get; } = new List<ServiceRegisterDescriptor>();
    }
}
