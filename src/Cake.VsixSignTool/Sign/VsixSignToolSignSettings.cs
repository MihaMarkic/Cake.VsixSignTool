namespace Cake.VsixSignTool
{
    /// <summary>
    /// Settings for VsixSignTool Sign command.
    /// </summary>
    public sealed class VsixSignToolSignSettings : AutoToolSettings
    {
        /// <summary>
        /// Specify the signing cert in a file. If this file is a PFX with a password, the password may be supplied with the "/p" option.
        /// If the file is P7B file, use the "/csp" and "/k" options to specify the CSP and container name of the private key.
        /// This option is mandatory.
        /// </summary>
        [Parameter("f")]
        public string File { get; set; }
        /// <summary>
        /// Specify a password to use when opening the PFX file.
        /// </summary>
        [Parameter("p")]
        public string Password { get; set; }
        /// <summary>
        /// Specify the Enhanced Key Usage that must be present in the cert. The parameter may be specified by OID or by string. The default
        /// usage is "Code Signing" (1.3.6.1.5.5.7.3.3).
        /// (This functionality has not been implemented yet.)
        /// </summary>
        [Parameter("u")]
        public string Usage { get; set; }
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
        /// Embed the signing certificate within the signature part XML. If no "/e." option is specified, "/es" is default.
        /// </summary>
        [Parameter("es")]
        public bool EmbedSigningCertificate { get; set; }

        /// <summary>
        /// Embed the signing certificate as a separate part in the package.
        /// </summary>
        [Parameter("ep")]
        public bool EmbedSigningCertificateAsSeparate { get; set; }

        /// <summary>
        /// Do not embed the signing certificate in either the signature part XML or as a separate part in the package.
        /// </summary>
        [Parameter("en")]
        public bool DoNotEmbedCertificate { get; set; }

        /// <summary>
        /// Retrieve and embed the certificates in the certificate chain up to the root authority separately in the package.
        /// (This functionality has not been implemented yet.)
        /// </summary>
        [Parameter("cc")]
        public bool EmbedCertificateChain { get; set; }

        /// <summary>
        /// Do not embed the certificates in the certificate chain separately in the package.
        /// </summary>
        [Parameter("cn")]
        public bool DoNotEmbedCertificateInChainSeparately { get; set; }

        /// <summary>
        /// File digest algorithm.
        /// </summary>
        [Parameter("fd")]
        public string FileDigestAlgorithm { get; set; }

        /// <summary>
        ///  Specify the timestamp server's URL. If this option is not present, the signed file will not be timestamped. A warning is
        ///  generated if timestamping fails.
        /// </summary>
        [Parameter("t")]
        public string TimestampServerUrl { get; set; }

        /// <summary>
        /// RFC3161_timestamp_URL
        /// </summary>
        [Parameter("tr")]
        public string RFC3161TimestampServerUrl { get; set; }

        /// <summary>
        /// Use with /tr switch only
        /// </summary>
        [Parameter("td")]
        public string TimestampDigestAlgorithm { get; set; }

        /// <summary>
        /// No output on success and minimal output on failure. As always, VsixSignTool returns 0 on success and 1 on failure.
        /// </summary>
        [Parameter("q")]
        public bool Quiet { get; set; }
    }
}
