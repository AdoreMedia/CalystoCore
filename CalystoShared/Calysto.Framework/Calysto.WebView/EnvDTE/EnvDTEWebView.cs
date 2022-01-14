namespace Calysto.WebView.EnvDTE
{
    public class EnvDTEWebView
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
        public const string ProjectDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.Framework\Calysto.WebView\";
        public const string SolutionDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\HitAuto\HitSpider\";
        public const string TargetDir = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.Framework\Calysto.WebView\bin\Release\netcoreapp3.1\";

        public const string ProjectFileName = @"Calysto.WebView.csproj";
        public const string SolutionFileName = @"HitSpiderWpf.sln";

        public const string ProjectPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.Framework\Calysto.WebView\Calysto.WebView.csproj";
        public const string SolutionPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\HitAuto\HitSpider\HitSpiderWpf.sln";
        public const string TargetPath = @"C:\LOCAL\VSPROJECTS\California.Core.3\CalystoShared\Calysto.Framework\Calysto.WebView\bin\Release\netcoreapp3.1\Calysto.WebView.dll";

        public const string PlatformName = @"AnyCPU";
        public const string ConfigurationName = @"Release";
        public const string SolutionName = @"HitSpiderWpf";

        public const string OutDir = @"bin\Release\netcoreapp3.1\";

    }
}
