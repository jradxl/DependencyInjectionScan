using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    /// <summary>
    /// 服务注册描述信息集合
    /// </summary>
    public class ServiceRegisterDescriptorCollection
    {
        public ServiceRegisterDescriptorCollection(IReadOnlyList<ServiceRegisterDescriptor> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }
        public IReadOnlyList<ServiceRegisterDescriptor> Items { get; private set; }
    }
}
