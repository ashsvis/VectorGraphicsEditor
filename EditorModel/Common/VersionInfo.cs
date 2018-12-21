using System;

namespace EditorModel.Common
{
    [Serializable]
    public class VersionInfo
    {
        public const int DEFAULT_VERSION = 2;

        public int Version = DEFAULT_VERSION;
    }
}
