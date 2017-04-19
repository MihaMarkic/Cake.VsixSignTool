using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System;
using System.Linq;

namespace Cake.VsixSignTool
{
    /// <summary>
    /// Contains functionality for working with VsixSignTool.
    /// </summary>
    [CakeAliasCategory("Signing")]
    public static partial class VsixSignToolAliases
    {
        /// <summary>
        /// Invokes Sign with array of from arguments.
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="settings">The verify settings.</param>
        /// <param name="files">Target vsix files</param>
        [CakeMethodAlias]
        public static void VsixSignToolVerify(this ICakeContext context, VsixSignToolVerifySettings settings, params FilePath[] files)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (files == null || files.Length == 0)
            {
                throw new ArgumentNullException("files");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            
            var runner = new VsixSignToolRunner<VsixSignToolVerifySettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("verify", settings, files.Select(f => f.FullPath).ToArray());
        }
    }
}
