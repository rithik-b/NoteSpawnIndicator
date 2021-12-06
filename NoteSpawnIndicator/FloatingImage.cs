using UnityEngine;
using UnityEngine.UI;

namespace NoteSpawnIndicator
{
    public class FloatingImage : Image
    {
        internal void Setup(Sprite sprite, Material material, Vector3 position)
        {
            gameObject.SetActive(false);

            CanvasScaler scaler = gameObject.AddComponent<CanvasScaler>();
            scaler.dynamicPixelsPerUnit = 3.44f;
            scaler.referencePixelsPerUnit = 10f;

            Canvas canvas = gameObject.GetComponent<Canvas>();
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2;
            canvas.sortingOrder = 4;

            this.sprite = sprite;
            this.material = material;

            rectTransform.position = position;
            gameObject.SetActive(true);
        }
    }
}