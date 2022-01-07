using IPA;
using IPA.Config;
using IPA.Config.Stores;
using NoteSpawnIndicator.Configuration;
using NoteSpawnIndicator.UI;
using SiraUtil.Zenject;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace NoteSpawnIndicator
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            Plugin.Log = logger;

            zenjector.Install(Location.App, (DiContainer Container) =>
            {
                Container.BindInterfacesAndSelfTo<ResourceLoader>().AsSingle();
            });

            zenjector.Install(Location.Menu, (DiContainer Container) =>
            {
                Container.BindInterfacesTo<ModifierViewController>().AsSingle();
            });

            zenjector.Install(Location.Player, (DiContainer Container) =>
            {
                if (PluginConfig.Instance.Mode != PluginConfig.ModeEnum.Off)
                {
                    Container.Bind<SpawnIndicator>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
                }
            });
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Plugin.Log?.Debug("Config loaded");
        }
        #endregion


        #region Disableable

        /// <summary>
        /// Called when the plugin is enabled (including when the game starts if the plugin is enabled).
        /// </summary>
        [OnEnable, OnDisable]
        public void OnStateChange() { }
        #endregion
    }
}
