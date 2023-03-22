﻿using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User: IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
