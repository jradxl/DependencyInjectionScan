# DependencyInjectionScan

Updated to fix a typo for Registe should be Register in various places.
For Help and Explanation, see the Text Program, which should be set as Startup.
Not sure of use of "Assembly[] ass = AssemblyDiscovery.Discovery();" on line 14 of Program.cs.
May just be a demo of the method. But amazing it finds 105 assemblies in this small test program!
Program still works with it commented out.


DependencyInjectionScan通过服务注册描述信息完成服务的注册，可以从当前程序集扫描服务注册配置，或者从文件中加载服务注册配置信息，最终完成服务注册。
## 使用方法
1. 引入DepencencyInjectionScan库：Install-Package Microsoft.Extensions.DependencyInjection.Scan
2. 使用IServiceCollection.AddScanServices()完成服务注册 
3. 自定义IServiceRegisterDescriptorProvider注册方法：IServiceCollection.AddScanServices(options=>{options.DescriptorProviderTypes.Add(对象);});

## 自定义服务注册描述信息提供者
1. 定义类实现IServiceRegisterDescriptorProvider接口
2. Order设置大于0
3. OnProvidersExecuting方法中增加自定义服务注册描述信息解析逻辑，并把解析结果放入context.Results中
4. OnProvidersExecuted方法中在解析完成后执行，可以在该方法中进行服务信息的更新，比如移除，替换等。
