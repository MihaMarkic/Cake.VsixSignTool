using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.VsixSignTool
{
    /// <summary>
    /// Base class for all VsixSignTool related tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public class VsixSignToolRunner<TSettings>: Tool<TSettings>
        where TSettings : AutoToolSettings, new()
    {
        private readonly ICakeEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="VsixSignToolRunner{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public VsixSignToolRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "VsixSignTool";
        }

        /// <summary>
        /// Runs <paramref name="command"/> using given <paramref name=" settings"/> and <paramref name="files"/>.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <param name="settings"></param>
        /// <param name="files"></param>
        public void Run(string command, TSettings settings, string[] files)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            Run(settings, GetArguments(command, settings, files));
        }

        private ProcessArgumentBuilder GetArguments(string command, TSettings settings, string[] files)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(new string[] { command }, settings, files);
            return builder;
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "VsixSignTool.exe", "VsixSignTool" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = VsixSignToolResolver.GetVsixSignToolPath(_fileSystem, _environment);
            return path != null
                ? new[] { path }
                : Enumerable.Empty<FilePath>();
        }
    }
}
