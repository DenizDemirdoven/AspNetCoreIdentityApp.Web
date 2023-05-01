﻿using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber: IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
           return new() { Code="DublicateUserName", Description = $"{userName} daha önce başka bir kullanıcı tarafından alınmıştır." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DublicateEmail", Description = $"{email} daha önce başka bir kullanıcı tarafından alınmıştır." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = $"Şifre en az 6 karakterden oluşmalıdır." };
        }

        public override IdentityError InvalidUserName(string? userName)
        {
            return new() { Code = "InvalidUserName", Description = $"Kullanıcı adı geçersiz karakter içeriyor." };
        }

        public override IdentityError InvalidEmail(string? email)
        {
            return new() { Code = "InvalidEmail", Description = $"Email geçersiz karakter içeriyor." };
        }


    }
}
