using System;
using ProjectCentral.Areas.AgeCalculator.Models;
using Xunit;

namespace Tester
{
    public class AgeCalculatorTests
    {
        [Fact]
        public void AgeByEndOfTest()
        {
            DateTime Birthday = new DateTime(2000, 1, 1);
            int ageThisYear = 2020 - Birthday.Year;

            PersonAgeModel person = new PersonAgeModel() { Birthday = Birthday };

            Assert.Equal(ageThisYear, person.AgeThisYear());
        }
        /*
Age today variable is calculated before PersonAge.
AgeToday is called, so the output of both must be slightly
modified to be less precise.
*/
        [Fact]
        public void AgeTodayTest()
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
        [Theory]
        [InlineData(2000, 5, 23)]
        public void CalculateAgeThisYearTest(int BirthdayYear, int BirthdayMonth, int BirthdayDay)
        {
            DateTime Birthday = new DateTime(BirthdayYear, BirthdayMonth, BirthdayDay);
            DateTime Now = DateTime.Now;

            TimeSpan Age = Now - Birthday;
            Age = new TimeSpan(Age.Hours, Age.Minutes, 0 );

            PersonAgeModel person = new PersonAgeModel() { Birthday = Birthday };

            TimeSpan TestAge = person.AgeToday().Value;
            TestAge = new TimeSpan(TestAge.Hours, TestAge.Minutes, 0);

            Assert.Equal(Age, TestAge);
        }
    }
}
