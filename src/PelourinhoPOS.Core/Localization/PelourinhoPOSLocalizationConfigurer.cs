using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace PelourinhoPOS.Localization
{
    public static class PelourinhoPOSLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PelourinhoPOSConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PelourinhoPOSLocalizationConfigurer).GetAssembly(),
                        "PelourinhoPOS.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
