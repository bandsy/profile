using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using profile.api.EntityFramework;
using profile.data.ProfileModels;

namespace profile.api.Controllers.ProfileControllers {
    [ApiController]
    [Route ("/api/[controller]")]
    public class ProfileController : ControllerBase {

        public readonly ProfileApiDbContext _profileApiDbContext;

        public ProfileController (ProfileApiDbContext profileApiDbContext) {
            _profileApiDbContext = profileApiDbContext;
        }

        [HttpGet]
        public IEnumerable<ProfileModel> Get () {
            var profiles = _profileApiDbContext.Profiles.ToList ();

            return profiles;
        }

    }
}