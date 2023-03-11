using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_WaveLines : MonoBehaviour {
        private static readonly int ALPHA = Shader.PropertyToID("_Alpha");
        private static readonly int PAN = Shader.PropertyToID("_Pan");

        [SerializeField] private MeshRenderer[] renderers;

        private Material[] materials;

        private void Awake() {
            materials = new Material[renderers.Length];

            for (int i = 0; i < renderers.Length; i++) {
                var material = renderers[i].material;

                material.SetFloat(PAN, (float) i / (renderers.Length - 1));
                materials[i] = material;
            }
        }

        public void SetAlpha(int index, float value) {
            materials[index].SetFloat(ALPHA, value);
            materials[materials.Length - 1 - index].SetFloat(ALPHA, value);
        }

        public void DoReset() {
            foreach (var material in materials)
                material.SetFloat(ALPHA, 1f);
        }
    }
}
