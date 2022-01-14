namespace Calysto.Genesis.EnvDTE
{
   public class EnvDTETestSite
    {
        /// <summary>
        /// Namespace has to be set manually
        /// </summary>
        public static readonly string RootNamespace = System.IO.Path.GetFileNameWithoutExtension(ProjectFileName);
        //public const string RootNamespace = @""; 
        
        public const string ProjectDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\Calysto.Web.Mvc.WebSite\";
        public const string SolutionDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\";
        public const string TargetDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\Calysto.Web.Mvc.WebSite\bin\Debug\net5.0\";

        public const string ProjectFileName = @"Calysto.Web.Mvc.WebSite.csproj";
        public const string SolutionFileName = @"WEM.Calysto.Framework.sln";

        public const string ProjectPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\Calysto.Web.Mvc.WebSite\Calysto.Web.Mvc.WebSite.csproj";
        public const string SolutionPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\WEM.Calysto.Framework.sln";
        public const string TargetPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\Calysto.Web.Mvc.WebSite\bin\Debug\net5.0\Calysto.Web.WebSite.dll";

        public const string PlatformName = @"AnyCPU";
        public const string ConfigurationName = @"Debug";
        public const string SolutionName = @"WEM.Calysto.Framework";

        public const string OutDir = @"bin\Debug\net5.0\";

    }
}
