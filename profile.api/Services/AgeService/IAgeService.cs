using System;

namespace profile.api.Services.AgeService {
    public interface IAgeService {
        int CalculateAge(DateTime birthdate);
    }
}