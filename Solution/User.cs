using System;

namespace NAoCHelper
{
    public class User
    {
        public string Cookie { get; }

        public User(string cookie)
        {
            if (string.IsNullOrWhiteSpace(cookie))
                throw new ArgumentNullException($"Expecting a value for ${nameof(cookie)}. Cannot be null or whitespace.");

            Cookie = cookie;
        }
    }
}
