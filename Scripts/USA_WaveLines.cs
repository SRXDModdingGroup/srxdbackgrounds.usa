using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_WaveLines : MonoBehaviour {
        private static readonly int INTENSITY = Shader.PropertyToID("_Intensity");

        [SerializeField] private MeshRenderer[] renderers;
        [SerializeField] private float maxIntensity;

        private Material[] materials;

        private void Awake() {
            materials = new Material[renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
                materials[i] = renderers[i].material;
        }

        public void SetIntensity(int index, float value) {
            value *= maxIntensity;
            
            materials[index].SetFloat(INTENSITY, value);
            materials[materials.Length - 1 - index].SetFloat(INTENSITY, value);
        }

        public void DoReset() {
            foreach (var material in materials)
                material.SetFloat(INTENSITY, maxIntensity);
        }
    }
}
