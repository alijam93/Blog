﻿using System.Collections.Generic;

namespace Blog.Shared.Account
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
