﻿using NoteSpawnIndicator.Configuration;
using Zenject;

namespace NoteSpawnIndicator.Installers
{
    internal class NoteSpawnIndicatorGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            if (PluginConfig.Instance.ModEnabled)
            {
                Container.BindInterfacesTo<SpawnIndicator>().FromNewComponentOnRoot().AsSingle();
            }
        }
    }
}
