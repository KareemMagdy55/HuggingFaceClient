namespace HuggingFaceClient.Utilities
{
    ///


    /// Provides global configuration settings for interacting with the HuggingFace API.
    ///

    public static class HuggingFaceGlobalConfig
    {
        ///

        /// Stores the API authentication token.
        ///

        public static string ApiToken { get; set; }

        /// <summary>
        /// Stores the base URL for the HuggingFace API.
        /// </summary>
        public static string ApiBaseUrl { get; set; }
    }
}