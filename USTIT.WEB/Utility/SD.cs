namespace USTIT.WEB.Utility
{
    public static class SD
    { 
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
            PATCH
        }
        public enum ContentType
        {
            Json,
            MultipartFormData
        }
    }
}
