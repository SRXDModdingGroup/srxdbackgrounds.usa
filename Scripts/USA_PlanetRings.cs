using SRXDBackgrounds.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SRXDBackgrounds.USA {
    public class USA_PlanetRings : MonoBehaviour {
        private static readonly int INTENSITY = Shader.PropertyToID("_Intensity");
        
        [SerializeField] private Transform scaleRoot;
        [SerializeField] private Transform[] transforms;
        [SerializeField] private MeshRenderer[] renderers;
        [SerializeField] private float[] rotationRates;
        [SerializeField] private float[] wobbleRates;
        [SerializeField] private float pulseScaleAmount;
        [SerializeField] private float pulseScaleDuration;
        [SerializeField] private float defaultIntensity;
        [SerializeField] private float maxIntensity;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float maxWobble;

        private Material[] materials;
        private float[] rotations;
        private float[] wobbleAngles;
        private float speed = 1f;
        private float wobble;
        private EnvelopeBasic scaleEnvelope;
        private float pulseValue;

        private void Awake() {
            materials = new Material[renderers.Length];
            
            for (int i = 0; i < renderers.Length; i++)
                materials[i] = renderers[i].material;

            rotations = new float[transforms.Length];
            wobbleAngles = new float[transforms.Length];

            for (int i = 0; i < transforms.Length; i++) {
                rotations[i] = Random.Range(0f, 360f);
                wobbleAngles[i] = Random.Range(0f, 360f);
            }
            
            scaleEnvelope = new EnvelopeBasic {
                Duration = pulseScaleDuration,
                Invert = true,
                InterpolationType = InterpolationType.EaseOut
            };

            wobble = maxWobble;
        }

        private void LateUpdate() {
            float deltaTime = Time.deltaTime;
            
            for (int i = 0; i < rotations.Length; i++) {
                rotations[i] = Mathf.Repeat(rotations[i] + deltaTime * speed * rotationRates[i], 360f);
                wobbleAngles[i] = Mathf.Repeat(wobbleAngles[i] + deltaTime * speed * wobbleRates[i], 360f);
                
                transforms[i].localRotation = Quaternion.AngleAxis(wobble, Quaternion.AngleAxis(wobbleAngles[i], Vector3.forward) * Vector3.right)
                                         * Quaternion.AngleAxis(rotations[i], Vector3.forward);
            }
            
            scaleRoot.localScale = (1f + pulseScaleAmount * pulseValue * scaleEnvelope.Update(deltaTime)) * Vector3.one;
        }
        
        public void PulseScale(float value) {
            pulseValue = value;
            scaleEnvelope.Trigger();
        }

        public void SetIntensity(int index, float value) => materials[index].SetFloat(INTENSITY, maxIntensity * value);

        public void SetSpeed(float value) => speed = maxSpeed * value;

        public void SetWobble(float value) => wobble = maxWobble * value;

        public void DoReset() {
            scaleEnvelope.Reset();
            speed = 1f;
            wobble = 0f;

            foreach (var material in materials)
                material.SetFloat(INTENSITY, defaultIntensity);
        }
    }
}
