using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Reflection;

namespace Innovation_Uniform_Editor_Backend
{
    public static class Versioning
    {
#if INSTALLER
        public static bool Portable = false;
#else
        public static bool Portable = true;
#endif

#if PREVIEW
        public static VersionType VersionType = VersionType.Preview;
#elif BUGTEST
        public static VersionType VersionType = VersionType.Bugtest;
#elif RELEASE
        public static VersionType VersionType = VersionType.Release;
#else
        public static VersionType VersionType = VersionType.Development;
#endif
        public static string VersionString { get; } =
        VersionType == VersionType.Release ?
        VersionToString(Version) :
        $"{VersionToString(Version)} ({VersionType} BUILD)";

        private static string VersionToString(Version version)
        {
            return $"{Version.Major}.{Version.Minor}.{Version.Build}";
        }


        private static Version version;
        public static Version Version
        {
            get
            {
                if (version == null)
                    version = Assembly.GetExecutingAssembly().GetName().Version;

                return version;
            }
        }
    }
}
