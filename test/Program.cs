﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Scan;
using System;
using System.Reflection;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Starting...");

            Assembly[] ass = AssemblyDiscovery.Discovery();

            IServiceCollection sc = new ServiceCollection();
            sc.AddScanServices();
            var hostingServiceProvider = sc.BuildServiceProvider();

            IServiceTest t = hostingServiceProvider.GetService<IServiceTest>();
            t.TestM();

            IEnumerable<AbstractTest> t1 = hostingServiceProvider.GetServices<AbstractTest>();
            foreach (var item in t1)
            {
                item.M();
            }

            IGenericTest<AbstractImpTest> t2 = hostingServiceProvider.GetService<IGenericTest<AbstractImpTest>>();

            Console.WriteLine("Press Enter to Quit.");
            Console.ReadLine();
        }
    }
}