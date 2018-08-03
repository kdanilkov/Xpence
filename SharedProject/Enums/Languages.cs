using Xpence.Attributes;

namespace Xpence.Enums
{
    public enum Languages:byte
    {
        [Translate("LanguageEnumEnglish")]
        [LanguageDetails("English","en-en")]
        English,
        [Translate("LanguageEnumGerman")]
        [LanguageDetails("German", "de-de")]
        German,
        [Translate("LanguageEnumRussian")]
        [LanguageDetails("Russian", "ru-ru")]
        Russian
    }
}