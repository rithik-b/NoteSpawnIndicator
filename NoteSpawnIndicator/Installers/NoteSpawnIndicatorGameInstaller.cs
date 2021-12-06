using Zenject;

namespace NoteSpawnIndicator
{
    internal class NoteSpawnIndicatorGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SpawnIndicator>().FromNewComponentOnRoot().AsSingle();
        }
    }
}
