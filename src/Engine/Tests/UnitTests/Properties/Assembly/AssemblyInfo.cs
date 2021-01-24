using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("BMTest Engine")]
[assembly: AssemblyProduct("BMTest")]
[assembly: AssemblyMetadata("Default OS", "Ubuntu20.04-x64")]
[assembly: AssemblyCompany("BMTLab")]
[assembly: AssemblyCopyright("Copyright © BMTLab, 2020")]
[assembly: AssemblyTrademark("BMTLab ®")]
[assembly: AssemblyDefaultAlias("BMTest")]
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0")]
[assembly: AssemblyInformationalVersion("1.0")]
[assembly: AssemblyDescription("BMTest Engine (Tests)")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#elif STAGING
[assembly: AssemblyConfiguration("Staging")]
#elif RELEASE
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyFlags(AssemblyNameFlags.EnableJITcompileOptimizer | AssemblyNameFlags.EnableJITcompileTracking)]
[assembly: ComVisible(false)]