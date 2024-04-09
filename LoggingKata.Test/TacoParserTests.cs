using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.376395, -84.913185, Taco Bell Adairsvill...", -84.913185)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line).Location.Longitude;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.376395, -84.913185, Taco Bell Adairsvill...", 34.376395)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }
    }
}
