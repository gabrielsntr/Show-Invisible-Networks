namespace ShowInvisibleNetworks.Systems
{
    using Colossal.UI.Binding;
    using Game.UI;

    public partial class ShowInvisibleNetworksUISystem : UISystemBase
    {
        private ValueBinding<bool> m_InvisibleNetworksVisible;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_InvisibleNetworksVisible = new ValueBinding<bool>(
                Mod.Id,
                Mod.InvisibleNetworksVisibleBinding,
                Mod.Instance.Settings.ShowInvisibleNetworks);

            AddBinding(m_InvisibleNetworksVisible);
            AddBinding(new TriggerBinding(Mod.Id, Mod.ToggleActionName, ToggleInvisibleNetworks));
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            bool visible = Mod.Instance.Settings.ShowInvisibleNetworks;
            if (m_InvisibleNetworksVisible.value != visible)
            {
                m_InvisibleNetworksVisible.Update(visible);
            }
        }

        private void ToggleInvisibleNetworks()
        {
            Setting settings = Mod.Instance.Settings;
            settings.ShowInvisibleNetworks = !settings.ShowInvisibleNetworks;
            settings.ApplyAndSave();
            m_InvisibleNetworksVisible.Update(settings.ShowInvisibleNetworks);
            Mod.Instance.Log.Info($"Invisible networks visible: {settings.ShowInvisibleNetworks}");
        }
    }
}
