﻿using IPA;
using SiraUtil.Zenject;
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
            zenjector.OnApp<NoteSpawnIndicatorAppInstaller>();
            zenjector.OnGame<NoteSpawnIndicatorGameInstaller>().ShortCircuitForMultiplayer().ShortCircuitForTutorial();
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Plugin.Log?.Debug("Config loaded");
        }
        */
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
