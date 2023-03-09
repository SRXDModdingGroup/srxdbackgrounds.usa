using SRXDBackgrounds.Common;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_Book : MonoBehaviour {
        private static readonly int INTENSITY = Shader.PropertyToID("_Intensity");
        private static readonly int WARP_AMOUNT = Shader.PropertyToID("_Warp_Amount");
        private static readonly int WAVE_AMOUNT = Shader.PropertyToID("_Wave_Amount");
        
        [SerializeField] private Transform scaleRoot;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private float pulseScaleAmount;
        [SerializeField] private float pulseScaleDuration;
        [SerializeField] private float defaultIntensity;
        [SerializeField] private float maxIntensity;
        [SerializeField] private float maxWarpAmount;

        private Material material;
        private EnvelopeBasic scaleEnvelope;

        private void Awake() {
            material = meshRenderer.material;
            scaleEnvelope = new EnvelopeBasic {
                Duration = pulseScaleDuration,
                Invert = true,
                InterpolationType = InterpolationType.EaseOut
            };
        }

        private void LateUpdate() {
            float deltaTime = Time.deltaTime;

            scaleRoot.localScale = (1f + pulseScaleAmount * scaleEnvelope.Update(deltaTime)) * Vector3.one;
        }

        public void PulseScale() => scaleEnvelope.Trigger();

        public void TriggerParticle() => particleSystem.Play();

        public void SetIntensity(float value) => material.SetFloat(INTENSITY, maxIntensity * value);

        public void SetWaveAmount(float value) => material.SetFloat(WAVE_AMOUNT, value);

        public void SetWarpAmount(float value) => material.SetFloat(WARP_AMOUNT, maxWarpAmount * value);

        public void DoReset() {
            scaleEnvelope.Reset();
            particleSystem.Clear();
            material.SetFloat(INTENSITY, defaultIntensity);
            material.SetFloat(WAVE_AMOUNT, 0f);
            material.SetFloat(WARP_AMOUNT, 0f);
        }
    }
}
