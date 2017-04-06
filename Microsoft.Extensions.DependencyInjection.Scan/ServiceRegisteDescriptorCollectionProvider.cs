using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public class ServiceRegisterDescriptorCollectionProvider : IServiceRegisterDescriptorCollectionProvider
    {
        private readonly IServiceRegisterDescriptorProvider[] _serviceRegisterDescriptorProviders;
        private ServiceRegisterDescriptorCollection _collection;

        public ServiceRegisterDescriptorCollectionProvider(
           IEnumerable<IServiceRegisterDescriptorProvider> serviceRegisterDescriptorProviders)
        {
            _serviceRegisterDescriptorProviders = serviceRegisterDescriptorProviders
                .OrderBy(p => p.Order)
                .ToArray();
        }

        private void UpdateCollection()
        {
            var context = new ServiceRegisterDescriptorProviderContext();

            for (var i = 0; i < _serviceRegisterDescriptorProviders.Length; i++)
            {
                _serviceRegisterDescriptorProviders[i].OnProvidersExecuting(context);
            }

            for (var i = _serviceRegisterDescriptorProviders.Length - 1; i >= 0; i--)
            {
                _serviceRegisterDescriptorProviders[i].OnProvidersExecuted(context);
            }

            _collection = new ServiceRegisterDescriptorCollection(
                new ReadOnlyCollection<ServiceRegisterDescriptor>(context.Results));
        }
        public ServiceRegisterDescriptorCollection ServiceRegisterDescriptors
        {
            get
            {
                if (_collection == null)
                {
                    UpdateCollection();
                }

                return _collection;
            }
        }
    }
}
