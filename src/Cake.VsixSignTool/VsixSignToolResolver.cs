using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.VsixSignTool
{
    /// <summary>
    /// VsixSignTool resolver. VsixSignTool should be located alongside the addin.
    /// </summary>
    internal static class VsixSignToolResolver
    {
        public static FilePath GetVsixSignToolPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException("fileSystem");
            }

            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            var location = typeof(VsixSignToolResolver).Assembly.Location;
            var dir = new DirectoryPath(System.IO.Path.GetDirectoryName(location));
            var filePath = dir.CombineWithFilePath("VsixSignTool.exe");
            return fileSystem.GetFile(filePath).Exists ? filePath : null;
        }
    }
}
