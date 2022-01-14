namespace JSUnitTest.EnvDTE
{
    internal class EnvDteJSUnitTest
    {
#if DEBUG
        public const bool IsDebugDefined = true;
#else
        public const bool IsDebugDefined = false;
#endif

#if TDDSPECIFIC
        public const bool IsTddSpecific = true;
#else
        public const bool IsTddSpecific = false;
#endif

        /// <summary>
        /// Namespace has to be set manually
        /// </summary>
        public static readonly string RootNamespace = System.IO.Path.GetFileNameWithoutExtension(ProjectFileName);
        //public const string RootNamespace = @""; 

        public const string ProjectDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\AjaxMinCore\JSUnitTest\";
        public const string SolutionDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\";
        public const string TargetDir = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\AjaxMinCore\JSUnitTest\bin\Debug\netcoreapp3.1\";

        public const string ProjectFileName = @"AjaxMinJSUnitTest.csproj";
        public const string SolutionFileName = @"Calysto.Framework.sln";

        public const string ProjectPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\AjaxMinCore\JSUnitTest\AjaxMinJSUnitTest.csproj";
        public const string SolutionPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\Calysto.Framework\Calysto.Framework.sln";
        public const string TargetPath = @"W:\Razvoj\Calysto\Calysto.Core.3\CalystoShared\AjaxMinCore\JSUnitTest\bin\Debug\netcoreapp3.1\AjaxMinJSUnitTest.dll";

        public const string PlatformName = @"AnyCPU";
        public const string ConfigurationName = @"Debug";
        public const string SolutionName = @"Calysto.Framework";

        public const string OutDir = @"bin\Debug\netcoreapp3.1\";

    }
}
