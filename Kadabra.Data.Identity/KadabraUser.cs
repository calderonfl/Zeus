﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kadabra.Data.Identity
{
    [Table("KadabraUsers")]
    public class KadabraUser : IdentityUser
    {
        public string SocialId { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Level { get; set; }
        public KadabraUserTournaments UserTournaments { get; set; }
        public KadabraLeagues Leagues { get; set; }
        //public KadabraPredictions Predictions { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<KadabraUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
