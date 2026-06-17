namespace ShowInvisibleNetworks.Systems
{
    using Colossal.Logging;
    using Game;
    using Game.Input;
    using Game.Rendering;

    public partial class ShowInvisibleNetworksSystem : GameSystemBase
    {
        private RenderingSystem m_RenderingSystem;
        private ProxyAction m_ToggleAction;
        private bool m_PreviousDesired;
        private ILog m_Log;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_Log = Mod.Instance.Log;
            m_RenderingSystem = World.GetOrCreateSystemManaged<RenderingSystem>();
            m_ToggleAction = Mod.Instance.Settings.GetAction(Mod.ToggleActionName);
            m_ToggleAction.shouldBeEnabled = true;
        }

        protected override void OnUpdate()
        {
            Setting settings = Mod.Instance.Settings;
            bool desired = settings.ShowInvisibleNetworks;

            if (m_ToggleAction.WasPerformedThisFrame())
            {
                desired = !desired;
                settings.ShowInvisibleNetworks = desired;
                settings.ApplyAndSave();
                m_Log.Info($"Invisible networks visible: {desired}");
            }

            ApplyVisibility(desired);
            m_PreviousDesired = desired;
        }

        private void ApplyVisibility(bool desired)
        {
            if (desired)
            {
                if (!m_RenderingSystem.markersVisible)
                {
                    m_RenderingSystem.markersVisible = true;
                }

                return;
            }

            if (m_PreviousDesired)
            {
                m_RenderingSystem.markersVisible = false;
            }
        }
    }
}
