namespace SqlMetal.Tests.EnvDTE
{
    public class EnvDTESqlMetalTests
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
        
        public const string ProjectDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\Calysto.SqlMetalTests\";
        public const string SolutionDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\";
        public const string TargetDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\Calysto.SqlMetalTests\bin\Debug\net5.0\";

        public const string ProjectFileName = @"Calysto.SqlMetal.Tests.csproj";
        public const string SolutionFileName = @"CalystoEFCoreGeneratorWpf.sln";

        public const string ProjectPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\Calysto.SqlMetalTests\Calysto.SqlMetal.Tests.csproj";
        public const string SolutionPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\CalystoEFCoreGeneratorWpf.sln";
        public const string TargetPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.SqlMetalCore\Calysto.SqlMetalTests\bin\Debug\net5.0\Calysto.SqlMetal.Tests.dll";

        public const string PlatformName = @"AnyCPU";
        public const string ConfigurationName = @"Debug";
        public const string SolutionName = @"CalystoEFCoreGeneratorWpf";

        public const string OutDir = @"bin\Debug\net5.0\";

    }
}
