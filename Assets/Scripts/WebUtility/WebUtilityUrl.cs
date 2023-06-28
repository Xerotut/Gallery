using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public static class WebUtilityUrl
    {
        //Reamke to use Uri or UriBuilder?
        public static string AssembleURL(string[] urlparts)
        {
            string url = "";
            foreach (string part in urlparts)
            {
                url += part;
            }
            return url;
        }
    }
}
