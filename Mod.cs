namespace ShowInvisibleNetworks
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;
    using ShowInvisibleNetworks.Systems;

    public class Mod : IMod
    {
        public const string Id = "ShowInvisibleNetworks";

        public const string ToggleActionName = "ToggleInvisibleNetworks";
        public const string InvisibleNetworksVisibleBinding = "InvisibleNetworksVisible";

        public static Mod Instance { get; private set; }

        public ILog Log { get; private set; }

        public Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            Log = LogManager.GetLogger(Id).SetShowsErrorsInUI(false);
            Log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
            {
                Log.Info($"Current mod asset at {asset.path}");
            }

            Settings = new Setting(this);
            Settings.RegisterInOptionsUI();
            Settings.RegisterKeyBindings();
            AssetDatabase.global.LoadSettings(Id, Settings, new Setting(this));

            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));

            updateSystem.UpdateAt<ShowInvisibleNetworksSystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<ShowInvisibleNetworksUISystem>(SystemUpdatePhase.UIUpdate);
        }

        public void OnDispose()
        {
            Log?.Info(nameof(OnDispose));

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }

            Instance = null;
        }
    }
}
