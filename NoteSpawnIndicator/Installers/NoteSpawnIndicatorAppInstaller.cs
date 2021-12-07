using Zenject;

namespace NoteSpawnIndicator.Installers
{
    internal class NoteSpawnIndicatorAppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourceLoader>().AsSingle();
        }
    }
}
