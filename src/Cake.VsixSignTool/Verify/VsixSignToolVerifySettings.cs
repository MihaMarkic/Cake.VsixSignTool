namespace Cake.VsixSignTool
{
    /// <summary>
    /// Settings for VsixSignTool Sign command.
    /// </summary>
    public sealed class VsixSignToolVerifySettings : AutoToolSettings
    {
        /// <summary>
        /// Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the "/p" option.
        /// If the file is P7B file, use the "/csp" and "/k" options to specify the CSP and container name of the private key.
        /// If there is an existing signing cert stored in the package, the stored cert is ignored.
        /// </summary>
        [Parameter("f")]
        public string File { get; set; }
        /// <summary>
        /// Specify a password to use when opening the PFX file.
        /// </summary>
        [Parameter("p")]
        public string Password { get; set; }
        /// <summary>
        /// Specify the SHA1 hash of the signing cert.
        /// </summary>
        [Parameter("sha1")]
        public string Hash { get; set; }
        /// <summary>
        /// Specify the CSP containing the Private Key Container.
        /// </summary>
        [Parameter("csp")]
        public string Csp { get; set; }
        /// <summary>
        /// Specify the Key Container Name of the Private Key.
        /// </summary>
        [Parameter("k")]
        public string KeyContainerName { get; set; }
        /// <summary>
        /// No output on success and minimal output on failure. As always, VsixSignTool returns 0 on success and 1 on failure.
        /// </summary>
        [Parameter("q")]
        public bool Quiet { get; set; }
    }
}
