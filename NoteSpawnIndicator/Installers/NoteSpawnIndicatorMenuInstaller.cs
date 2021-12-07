using NoteSpawnIndicator.UI;
using Zenject;

namespace NoteSpawnIndicator.Installers
{
    internal class NoteSpawnIndicatorMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ModifierViewController>().AsSingle();
        }
    }
}
