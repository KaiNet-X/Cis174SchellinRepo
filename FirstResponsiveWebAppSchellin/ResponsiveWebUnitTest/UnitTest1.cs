using System;
using Xunit;
using FirstResponsiveWebAppSchellin.Models;

namespace ResponsiveWebUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void AgeThisYear()
        {
            DateTime Birthday = new DateTime(2004, 4, 9);
            DateTime Today = DateTime.Now;
            int AgeThisYear = 2020 - Birthday.Year;

            PersonAgeModel PersonAge = new PersonAgeModel()
            {
                Birthday = Birthday
            };

            Assert.Equal(AgeThisYear, PersonAge.AgeThisYear());
        }
        /*
        Age today variable is calculated before PersonAge.
        AgeToday is called, so the output of both must be slightly
        modified to be less precise.
        */
        [Fact]
        public void AgeToday()
        {
            DateTime Birthday = new DateTime(2004, 4, 9);
            DateTime Today = DateTime.Now;
            TimeSpan AgeToday = Today - Birthday;
            AgeToday = new TimeSpan(AgeToday.Days * 24, AgeToday.Hours * 60, 0);

            PersonAgeModel PersonAge = new PersonAgeModel()
            {
                Birthday = Birthday
            };

            TimeSpan AgeModelAgeToday = PersonAge.AgeToday().Value;
            AgeModelAgeToday = new TimeSpan(AgeModelAgeToday.Days * 24, AgeModelAgeToday.Hours * 60, 0);

            Assert.Equal(AgeToday, AgeModelAgeToday);
        }
    }
}
