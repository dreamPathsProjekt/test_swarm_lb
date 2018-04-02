using App.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace App.Api.Controllers
{
    [Route("[controller]")]
    public class PasswordController : Controller
    {
        [HttpGet]
        public PasswordResponse Get()
        {
            //v1
            return new PasswordResponse 
            {
                Password = Guid.NewGuid().ToString().Substring(0,6),
                ApiVersion = "1.0",
                ApiServer = Environment.MachineName
            };

            //v2
            /* 
            return new PasswordResponse 
            {
                Password = GenerateRandomPassword(),
                ApiVersion = "2.0",
                ApiServer = Environment.MachineName
            };
            */
        }

    private static string GenerateRandomPassword()
    {
 
    string[] randomChars = new [] {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
    };
    Random rand = new Random();
    List<char> chars = new List<char>();
 
        chars.Insert(rand.Next(0, chars.Count), 
            randomChars[0][rand.Next(0, randomChars[0].Length)]);
 
        chars.Insert(rand.Next(0, chars.Count),
            randomChars[1][rand.Next(0, randomChars[1].Length)]);
 
        chars.Insert(rand.Next(0, chars.Count),
            randomChars[2][rand.Next(0, randomChars[2].Length)]);
 
        chars.Insert(rand.Next(0, chars.Count),
            randomChars[3][rand.Next(0, randomChars[3].Length)]);
 
    for (int i = chars.Count; i < 10; i++)
    {
        string rcs = randomChars[rand.Next(0, randomChars.Length)];
        chars.Insert(rand.Next(0, chars.Count), 
            rcs[rand.Next(0, rcs.Length)]);
    }
 
    return new string(chars.ToArray());
}
}
}