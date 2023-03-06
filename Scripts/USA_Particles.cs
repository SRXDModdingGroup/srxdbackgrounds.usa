using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_Particles : MonoBehaviour {
        private static readonly int INTENSITY = Shader.PropertyToID("_Intensity");

        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private ParticleSystemRenderer renderer;
        [SerializeField] private float maxIntensity;
        [SerializeField] private float maxSpeed;

        private Material material;

        private void Awake() {
            material = renderer.material;
            renderer.enabled = false;
        }

        public void SetIntensity(float value) {
            material.SetFloat(INTENSITY, maxIntensity * value);
            renderer.enabled = value > 0f;
        }

        public void SetSpeed(float value) {
            var main = particleSystem.main;

            main.simulationSpeed = maxSpeed * value;
        }

        public void DoReset() {
            var main = particleSystem.main;

            main.simulationSpeed = 1f;
            renderer.enabled = false;
        }
    }
}
