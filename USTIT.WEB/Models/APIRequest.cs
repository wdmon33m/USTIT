﻿using static USTIT.WEB.Utility.SD;

namespace USTIT.WEB.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public bool WithBearer { get; set; } = true;
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
