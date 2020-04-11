using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using profile.api.Services.LanguageService;

namespace profile.unit_tests.Services {
    [TestFixture]
    public class LanguageServiceTests {
        private ILanguageService _languageService;

        private List<string> _codes;
        private List<string> _languages;

        [SetUp]
        public void Setup () {
            _languageService = Substitute.For<ILanguageService> ();
            _codes = new List<string> {
                "eng",
                "fre"
            };
            _languages = new List<string> {
                "English",
                "French"
            };
        }

        [Test]
        public void GetIsoCodes_AllOK_ReturnsIsoCodes () {
            //arrange
            _languageService.GetIsoCodes (Arg.Any<List<string>> ()).Returns (_codes);

            //act
            var result = _languageService.GetIsoCodes (_languages);

            //assert
            result.Should ().HaveCount (2).And.AllBeOfType<string> ();
            result.First ().Should ().Be ("eng").And.HaveLength (3);
            result.Last ().Should ().Be ("fre").And.HaveLength (3);
            result.Should ().BeSameAs (_codes);

            _languageService.Received ().GetIsoCodes (Arg.Any<List<string>> ());
        }

        [Test]
        public void GetAllLanguageNames_AllOk_ReturnsLanguageNames () {
            //arrange
            _languageService.GetLanguageNames(Arg.Any<List<string>>()).Returns(_languages);            

            //act
            var result = _languageService.GetLanguageNames (_codes);

            //assert
            result.Should ().HaveCount (2).And.AllBeOfType<string> ();
            result.First ().Should ().Be ("English");
            result.Last ().Should ().Be ("French");
            result.Should ().BeSameAs (_languages);

            _languageService.Received ().GetLanguageNames (Arg.Any<List<string>> ());

        }
    }
}