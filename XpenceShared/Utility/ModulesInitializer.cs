using System.Linq;
using Prism.Modularity;

namespace XpenceShared.Utility
{
    public static class ModulesInitializer
    {
       public static IModuleCatalog ModuleCatalog { get; set; }
        public static IModuleManager ModuleManager { get; set; }

        public static string ExtractModuleFromUrl(string url)
        {
            if (!url.Contains("#"))
            {
                return url;
            }

            var result = url.Split('#');



            var module = ModuleCatalog.Modules.FirstOrDefault(x => x.ModuleName == result[1]);

            if (module != null && module.State == ModuleState.NotStarted)
            {

                ModuleManager.LoadModule(module.ModuleName);
            }

            return result[0];



        }
    }
}