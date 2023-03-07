using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_Particles : MonoBehaviour {
        private static readonly int INTENSITY = Shader.PropertyToID("_Intensity");

        [SerializeField] private ParticleSystem[] particleSystems;
        [SerializeField] private ParticleSystemRenderer[] renderers;
        [SerializeField] private float maxIntensity;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float lengthScale;

        private Material[] materials;

        private void Awake() {
            materials = new Material[renderers.Length];

            for (int i = 0; i < renderers.Length; i++) {
                var renderer = renderers[i];
                
                materials[i] = renderer.material;
                renderer.enabled = false;
            }
        }

        public void SetIntensity(float value) {
            value *= maxIntensity;

            bool enable = value > 0f;
            
            for (int i = 0; i < renderers.Length; i++) {
                materials[i].SetFloat(INTENSITY, value);
                renderers[i].enabled = enable;
            }
        }

        public void SetSpeed(float value) => DoSetSpeed(maxSpeed * value);

        public void DoReset() {
            SetIntensity(0f);
            DoSetSpeed(1f);
        }

        private void DoSetSpeed(float speed) {
            float length = speed * lengthScale;
            
            for (int i = 0; i < particleSystems.Length; i++) {
                var particleSystem = particleSystems[i];
                var main = particleSystem.main;

                main.simulationSpeed = speed;
                renderers[i].lengthScale = length;
            }
        }
    }
}
