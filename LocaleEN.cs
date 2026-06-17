namespace ShowInvisibleNetworks
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Show Invisible Networks" },
                { m_Setting.GetOptionTabLocaleID(Setting.kMainSection), "Main" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kGeneralGroup), "Visibility" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Key bindings" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShowInvisibleNetworks)), "Show invisible networks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShowInvisibleNetworks)), "Reveals all invisible networks and markers, including ExtraNetworksAndAreas paths." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ToggleBinding)), "Toggle invisible networks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ToggleBinding)), "Toggles invisible network and marker visibility." },
                { m_Setting.GetBindingKeyLocaleID(Mod.ToggleActionName), "Toggle invisible networks" },
                { m_Setting.GetBindingMapLocaleID(), "Show Invisible Networks" },
            };
        }

        public void Unload()
        {
        }
    }
}
