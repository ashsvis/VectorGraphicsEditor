using System;

namespace EditorModel.Common
{
    [Serializable]
    public class VersionInfo
    {
        public const int DEFAULT_VERSION = 4;

        public int Version = DEFAULT_VERSION;
    }
}
