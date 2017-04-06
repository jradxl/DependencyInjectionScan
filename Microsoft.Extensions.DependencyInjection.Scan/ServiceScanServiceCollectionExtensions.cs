﻿using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection.Scan
{
    public static class ServiceScanServiceCollectionExtensions
    {
       
        public static IServiceCollection AddScanServices(this IServiceCollection services)
        {
            return AddScanServices(services,null);
        }

        public static IServiceCollection AddScanServices(this IServiceCollection services,Action<ServiceScanOptions> options)
        {
            ServiceScanOptions option = new ServiceScanOptions();
            option.DescriptorProviderTypes.Add(new DefaultServiceRegisterDescriptorProvider());
            options?.Invoke(option);

            IServiceRegisterDescriptorCollectionProvider provider = new ServiceRegisterDescriptorCollectionProvider(option.DescriptorProviderTypes);
            ServiceRegisterDescriptorCollection collection = provider.ServiceRegisterDescriptors;
            foreach (var item in collection.Items)
            {
                ServiceRegister.Register(services,item);
            }

            return services;
        }
    }
}
