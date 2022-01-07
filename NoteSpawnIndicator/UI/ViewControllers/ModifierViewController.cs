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

        [UIAction("mode-formatter")]
        private string ModeFormatter(int modeNum) => modeNum == 0 ? "Off" : modeNum == 1 ? "Indicate Note Spawn" : "Indicate Note Jump";

        [UIValue("mode")]
        private int Mode
        {
            get => (int)PluginConfig.Instance.Mode;
            set
            {
                PluginConfig.Instance.Mode = (PluginConfig.ModeEnum)value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mode)));
            }
        }

        [UIValue("custom-image")]
        private bool UseCustomImage
        {
            get => PluginConfig.Instance.UseCustomImage;
            set
            {
                PluginConfig.Instance.UseCustomImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseCustomImage)));
            }
        }

        [UIValue("offset-x")]
        private float XOffset
        {
            get => PluginConfig.Instance.XOffset;
            set
            {
                PluginConfig.Instance.XOffset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(XOffset)));
            }
        }

        [UIValue("offset-y")]
        private float YOffset
        {
            get => PluginConfig.Instance.YOffset;
            set
            {
                PluginConfig.Instance.YOffset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(YOffset)));
            }
        }

        [UIValue("offset-z")]
        private float ZOffset
        {
            get => PluginConfig.Instance.ZOffset;
            set
            {
                PluginConfig.Instance.ZOffset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ZOffset)));
            }
        }

        [UIValue("scale")]
        private float Scale
        {
            get => PluginConfig.Instance.Scale;
            set
            {
                PluginConfig.Instance.Scale = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Scale)));
            }
        }
    }
}
