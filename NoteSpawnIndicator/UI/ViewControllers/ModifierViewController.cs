using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using NoteSpawnIndicator.Configuration;
using System;
using System.ComponentModel;
using Zenject;

namespace NoteSpawnIndicator.UI
{
    internal class ModifierViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Initialize()
        {
            GameplaySetup.instance.AddTab(nameof(NoteSpawnIndicator), "NoteSpawnIndicator.UI.Views.ModifierView.bsml", this);
        }

        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable)
            {
                GameplaySetup.instance.RemoveTab(nameof(NoteSpawnIndicator));
            }
        }

        [UIValue("enabled")]
        private bool ModEnabled
        {
            get => PluginConfig.Instance.ModEnabled;
            set
            {
                PluginConfig.Instance.ModEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModEnabled)));
            }
        }

        [UIValue("offset-y")]
        private float YOffset
        {
            get => PluginConfig.Instance.YOffset;
            set
            {
                PluginConfig.Instance.YOffset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModEnabled)));
            }
        }

        [UIValue("offset-x")]
        private float XOffset
        {
            get => PluginConfig.Instance.XOffset;
            set
            {
                PluginConfig.Instance.XOffset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModEnabled)));
            }
        }

        [UIValue("scale")]
        private float Scale
        {
            get => PluginConfig.Instance.Scale;
            set
            {
                PluginConfig.Instance.Scale = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModEnabled)));
            }
        }
    }
}
