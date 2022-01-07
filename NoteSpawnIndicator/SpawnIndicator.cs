using IPA.Utilities;
using NoteSpawnIndicator.Configuration;
using System.IO;
using System.Threading;
using UnityEngine;
using Zenject;

namespace NoteSpawnIndicator
{
    internal class SpawnIndicator : MonoBehaviour
    {
        private ResourceLoader resourceLoader;
        private CachedMediaAsyncLoader cachedMediaAsyncLoader;
        private AudioTimeSyncController audioTimeSyncController;
        private BeatmapObjectSpawnMovementData beatmapObjectSpawnMovementData;

        [Inject]
        public void Construct(ResourceLoader resourceLoader, CachedMediaAsyncLoader cachedMediaAsyncLoader, AudioTimeSyncController audioTimeSyncController, BeatmapObjectSpawnController beatmapObjectSpawnController)
        {
            this.resourceLoader = resourceLoader;
            this.cachedMediaAsyncLoader = cachedMediaAsyncLoader;
            this.audioTimeSyncController = audioTimeSyncController;
            beatmapObjectSpawnMovementData = beatmapObjectSpawnController.GetField<BeatmapObjectSpawnMovementData, BeatmapObjectSpawnController>("_beatmapObjectSpawnMovementData");
        }

        public void Update()
        {
            // Need to wait a couple ticks for the start pos to be added in
            // It is basically guaranteed the start pos is ready after a single Update but just in case
            if (audioTimeSyncController.songTime > 0.1f)
            {
                CreateIndicator();
                Destroy(this);
            }
        }

        public async void CreateIndicator()
        {
            FloatingImage floatingImage = new GameObject("FloatingImage", typeof(FloatingImage)).GetComponent<FloatingImage>();
            Material material = await resourceLoader.LoadSpriteMaterial();

            Sprite sprite = PluginConfig.Instance.UseCustomImage ? 
                await cachedMediaAsyncLoader.LoadSpriteAsync(Path.Combine(UnityGame.UserDataPath, $"{nameof(NoteSpawnIndicator)}.png"), CancellationToken.None) :
                BeatSaberMarkupLanguage.Utilities.ImageResources.WhitePixel;

            floatingImage.Setup(sprite, material, beatmapObjectSpawnMovementData.GetField<Vector3, BeatmapObjectSpawnMovementData>(PluginConfig.Instance.Mode == PluginConfig.ModeEnum.NoteJump ? "_moveEndPos" : "_moveStartPos"));
            floatingImage.transform.localScale = new Vector3(PluginConfig.Instance.Scale / 100, PluginConfig.Instance.Scale / 100, PluginConfig.Instance.Scale / 100);
            floatingImage.transform.localPosition = new Vector3(PluginConfig.Instance.XOffset, PluginConfig.Instance.YOffset, floatingImage.transform.localPosition.z + PluginConfig.Instance.ZOffset);
        }
    }
}
