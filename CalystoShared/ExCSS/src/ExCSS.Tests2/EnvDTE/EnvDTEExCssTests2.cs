namespace ExCSS.Tests2.EnvDTE
{
    public class EnvDTEExCssTests2
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
        
        public const string ProjectDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\ExCSS\src\ExCSS.Tests2\";
        public const string SolutionDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\Privredni\Privredni.Web\";
        public const string TargetDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\ExCSS\src\ExCSS.Tests2\bin\Release\net5.0\";

        public const string ProjectFileName = @"ExCSS.Tests2.csproj";
        public const string SolutionFileName = @"PrivredniWebCore.sln";

        public const string ProjectPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\ExCSS\src\ExCSS.Tests2\ExCSS.Tests2.csproj";
        public const string SolutionPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\Privredni\Privredni.Web\PrivredniWebCore.sln";
        public const string TargetPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\ExCSS\src\ExCSS.Tests2\bin\Release\net5.0\ExCSS.Tests2.dll";

        public const string PlatformName = @"AnyCPU";
        public const string ConfigurationName = @"Release";
        public const string SolutionName = @"PrivredniWebCore";

        public const string OutDir = @"bin\Release\net5.0\";

    }
}
