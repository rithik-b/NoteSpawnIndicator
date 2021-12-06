using Zenject;

namespace NoteSpawnIndicator
{
    internal class NoteSpawnIndicatorAppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourceLoader>().AsSingle();
        }
    }
}
