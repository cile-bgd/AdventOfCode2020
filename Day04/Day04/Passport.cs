using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BirthYear)
                      && !string.IsNullOrWhiteSpace(IssueYear)
                      && !string.IsNullOrWhiteSpace(ExpirationYear)
                      && !string.IsNullOrWhiteSpace(Height)
                      && !string.IsNullOrWhiteSpace(HairColor)
                      && !string.IsNullOrWhiteSpace(EyeColor)
                      && !string.IsNullOrWhiteSpace(PassportId);
        }

        public bool IsPartTwoValid()
        {
            if (!(int.TryParse(BirthYear, out var birthYear) && birthYear >= 1920 && birthYear <= 2002))
            {
                Console.WriteLine($"Failed on Birth Year: {BirthYear}");
                return false;
            }
            if (!(int.TryParse(IssueYear, out var issueYear) && issueYear >= 2010 && issueYear <= 2020))
            {
                Console.WriteLine($"Failed on Issue Year: {IssueYear}");
                return false;
            }

            if (!(int.TryParse(ExpirationYear, out var expirationYear) && expirationYear >= 2020 &&
                  expirationYear <= 2030))
            {
                Console.WriteLine($"Failed on Expiration Year: {ExpirationYear}");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Height))
            {
                Console.WriteLine($"Failed on Height: null");
                return false;
            }

            if (Height.Substring(Height.Length - 2) != "cm" && Height.Substring(Height.Length - 2) != "in")
            {
                Console.WriteLine($"Failed on Height details: {Height}");
                return false;
            }
            
            if (Height.Substring(Height.Length - 2) == "cm")
            {
                if (!(int.TryParse(Height.Substring(0, Height.Length - 2), out var cmHeight) &&
                      cmHeight >= 150 && cmHeight <= 193))
                {
                    Console.WriteLine($"Failed on Height(cm): {cmHeight}");
                    return false;
                }
            }
            
            if (Height.Substring(Height.Length - 2) == "in")
            {
                if (!(int.TryParse(Height.Substring(0, Height.Length - 2), out var inHeight) &&
                      inHeight >= 59 && inHeight <= 76))
                {
                    Console.WriteLine($"Failed on Height(in): {inHeight}");
                    return false;
                }
            }

            var hairColourRegex = new Regex(@"^#([a-zA-Z0-9]{6})$");
            var validHairColour = !string.IsNullOrWhiteSpace(HairColor) && hairColourRegex.Matches(HairColor).Any();
            if (string.IsNullOrWhiteSpace(HairColor))
            {
                Console.WriteLine($"Failed on Hair Color: null");
                return false;
            }

            if (!hairColourRegex.Matches(HairColor).Any())
            {
                Console.WriteLine($"Failed on Hair Color regex: {HairColor}");
                return false;
            }

            if (string.IsNullOrWhiteSpace(EyeColor))
            {
                Console.WriteLine($"Failed on Eye Color: null");
                return false;
            }

            if (!(EyeColor == "amb" || EyeColor == "blu" || EyeColor == "brn" || EyeColor == "gry" ||
                  EyeColor == "grn" || EyeColor == "hzl" || EyeColor == "oth"))
            {
                Console.WriteLine($"Failed on Eye Color: {EyeColor}");
                return false;
            }

            var passportIdRegex = new Regex(@"^\d{9}$");
            if (string.IsNullOrWhiteSpace(PassportId))
            {
                Console.WriteLine($"Failed on Passport Id: null");
                return false;
            }

            if (!passportIdRegex.Matches(PassportId).Any())
            {
                Console.WriteLine($"Failed on Passport Id Regex: {PassportId}");
                return false;
            }

            return true;
        }
    }
}