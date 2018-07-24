using System;

namespace MsMQ
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}