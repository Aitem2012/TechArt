namespace TechArt.Tests
{
    public class ExtensionMethodTests
    {
        [Fact]
        public void SlugifyShouldReturnNewSlugString()
        {
            var sut = "ClassicalAitem".Slugify();
            Assert.NotEmpty(sut);
            Assert.True(sut.Length > 0);
        }

        [Fact]
        public void GenerateRefShouldReturnReferenceNumber()
        {
            var sut = "TechArt".GenerateRef();
            Assert.NotEmpty(sut);
            Assert.True(sut.Length > 0);
        }

        [Fact]
        public void GenerateReferralCodeShouldReturnReferalCode()
        {
            var sut = "TechArt".GenerateReferralCode();
            Assert.NotEmpty(sut);
            Assert.True(sut.Length > 0);
        }

        [Fact]
        public void ToYesNoShouldReturnStringValue()
        {
            var yes = true;
            var no = false;
            Assert.Equal("Yes", yes.ToYesNo());
            Assert.Equal("No", no.ToYesNo());
        }

        [Fact]
        public void ToTrueOrFalseShouldReturnStringValue()
        {
            var yes = true;
            var no = false;
            Assert.Equal("True", yes.ToTrueFalse());
            Assert.Equal("False", no.ToTrueFalse());
        }

        [Fact]
        public void GetEnumDescriptionShouldReturnAppropriateDescription()
        {
            var sut = Enums.InternationalSchool;
            Assert.Equal("International School", sut.GetDescription());
        }

        [Fact]
        public void ToAgeShouldCalculateAge()
        {
            var sut = new DateTime(1993, 11, 30);

            Assert.NotEqual(29, sut.ToAge());
            Assert.Equal(30, sut.ToAge());
        }
    }
}