namespace ShowInvisibleNetworks
{
    using Colossal.IO.AssetDatabase;
    using Game.Input;
    using Game.Modding;
    using Game.Settings;

    [FileLocation(Mod.Id)]
    [SettingsUIGroupOrder(kGeneralGroup, kKeybindingGroup)]
    [SettingsUIShowGroupName(kGeneralGroup, kKeybindingGroup)]
    [SettingsUIKeyboardAction(Mod.ToggleActionName, ActionType.Button, usages: new[] { Usages.kMenuUsage }, interactions: new[] { "UIButton" })]
    public class Setting : ModSetting
    {
        public const string kMainSection = "Main";
        public const string kGeneralGroup = "General";
        public const string kKeybindingGroup = "KeyBinding";

        public Setting(IMod mod)
            : base(mod)
        {
        }

        [SettingsUISection(kMainSection, kGeneralGroup)]
        public bool ShowInvisibleNetworks { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.M, Mod.ToggleActionName, ctrl: true)]
        [SettingsUISection(kMainSection, kKeybindingGroup)]
        public ProxyBinding ToggleBinding { get; set; }

        public override void SetDefaults()
        {
            ShowInvisibleNetworks = false;
        }
    }
}
