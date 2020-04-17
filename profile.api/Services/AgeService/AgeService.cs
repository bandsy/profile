using System;
using System.Net.Http.Headers;

namespace profile.api.Services.AgeService {
    public class AgeService : IAgeService {
        public int CalculateAge(DateTime birthdate) {
            var currentDate = DateTime.UtcNow;
            var age = currentDate.Year - birthdate.Year;

            //check for leap years
            if (birthdate.Date > currentDate.AddYears(-age)) {
                age--;
            }

            return age;
        }
    }
}