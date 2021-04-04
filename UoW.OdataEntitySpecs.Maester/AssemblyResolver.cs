namespace UoW.OdataEntitySpecs.Maester
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.Extensions.DependencyModel;
    using Microsoft.Extensions.DependencyModel.Resolution;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;

    public class AssemblyResolver : IDisposable
    {
        private readonly ICompilationAssemblyResolver _assemblyResolver;
        private readonly DependencyContext _dependencyContext;
        private readonly AssemblyLoadContext _loadContext;

        public AssemblyResolver(string path)
        {
            Assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            _dependencyContext = DependencyContext.Load(Assembly);

            _assemblyResolver = new CompositeCompilationAssemblyResolver(
                new ICompilationAssemblyResolver[]
                {
                    new AppBaseCompilationAssemblyResolver(Path.GetDirectoryName(path)),
                    new ReferenceAssemblyPathResolver(),
                    new PackageCompilationAssemblyResolver(),
                });

            _loadContext = AssemblyLoadContext.GetLoadContext(Assembly);
            _loadContext.Resolving += OnResolving;
        }

        public Assembly Assembly { get; }

        public void Dispose()
        {
            _loadContext.Resolving -= OnResolving;
        }

        private Assembly? OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            if (name.Name == "Microsoft.AspNetCore.Mvc.Core")
            {
                return typeof(AcceptVerbsAttribute).Assembly;
            }

            if (name.Name == "Microsoft.AspNetCore.Mvc.Abstractions")
            {
                return typeof(ActionDescriptor).Assembly;
            }

            var library = _dependencyContext.RuntimeLibraries
                .FirstOrDefault(it => string.Equals(it.Name, name.Name, StringComparison.OrdinalIgnoreCase));

            if (library == null)
            {
                Console.WriteLine($"Cannot find library: {name.Name}");
                return null;
            }

            try
            {
                var wrapped = new CompilationLibrary(
                    library.Type,
                    library.Name,
                    library.Version,
                    library.Hash,
                    library.RuntimeAssemblyGroups.SelectMany(g => g.AssetPaths),
                    library.Dependencies,
                    library.Serviceable);

                var assemblies = new List<string>();
                _assemblyResolver.TryResolveAssemblyPaths(wrapped, assemblies);

                if (assemblies.Count == 0)
                {
                    Console.WriteLine($"Cannot find assembly path: {name.Name} (type={library.Type}, version={library.Version})");
                    return null;
                }

                return _loadContext.LoadFromAssemblyPath(assemblies[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot find assembly path: {name.Name} (type={library.Type}, version={library.Version})");
                Console.WriteLine($"exception: {ex.Message}");
                return null;
            }
        }
    }
}
