using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace NoteSpawnIndicator.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        [UseConverter(typeof(EnumConverter<ModeEnum>))]
        [NonNullable]
        public virtual ModeEnum Mode { get; set; } = ModeEnum.Off;
        public virtual bool UseCustomImage { get; set; } = false;
        public virtual float XOffset { get; set; } = 0f;
        public virtual float YOffset { get; set; } = 0.5f;
        public virtual float ZOffset { get; set; } = 0f;
        public virtual float Scale { get; set; } = 0.1f;
        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
        }

        public enum ModeEnum
        {
            Off,
            NoteSpawn,
            NoteJump
        }
    }
}