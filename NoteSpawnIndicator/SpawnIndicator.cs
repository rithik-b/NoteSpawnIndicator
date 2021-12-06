using IPA.Utilities;
using UnityEngine;
using Zenject;

namespace NoteSpawnIndicator
{
    internal class SpawnIndicator : MonoBehaviour, IInitializable
    {
        private ResourceLoader resourceLoader;
        private AudioTimeSyncController audioTimeSyncController;
        private BeatmapObjectSpawnMovementData beatmapObjectSpawnMovementData;

        [Inject]
        public void Construct(ResourceLoader resourceLoader, AudioTimeSyncController audioTimeSyncController, BeatmapObjectSpawnController beatmapObjectSpawnController)
        {
            this.resourceLoader = resourceLoader;
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
                GameObject.Destroy(this);
            }
        }

        public async void CreateIndicator()
        {
            FloatingImage floatingImage = new GameObject("FloatingImage", typeof(FloatingImage)).GetComponent<FloatingImage>();
            Material material = await resourceLoader.LoadSpriteMaterial();
            floatingImage.Setup(BeatSaberMarkupLanguage.Utilities.ImageResources.WhitePixel, material, beatmapObjectSpawnMovementData.GetField<Vector3, BeatmapObjectSpawnMovementData>("_moveStartPos"));
            floatingImage.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }

        public void Initialize()
        {
        }
    }
}
