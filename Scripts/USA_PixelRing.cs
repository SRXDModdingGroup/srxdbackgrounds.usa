using System;
using System.Collections;
using System.Collections.Generic;
using SRXDBackgrounds.Common;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_PixelRing : MonoBehaviour {
        private static readonly int PHASE = Shader.PropertyToID("_Phase");
        
        [SerializeField] private MeshRenderer[] meshRenderers;
        [SerializeField] private float maxPhase;
        [SerializeField] private float maxDuration;

        private Material[] materials;
        private EnvelopeBasic[] envelopes;

        private void Awake() {
            materials = new Material[meshRenderers.Length];
            envelopes = new EnvelopeBasic[meshRenderers.Length];

            for (int i = 0; i < meshRenderers.Length; i++) {
                materials[i] = meshRenderers[i].material;
                envelopes[i] = new EnvelopeBasic();
            }
        }

        private void LateUpdate() {
            float deltaTime = Time.deltaTime;
            
            for (int i = 0; i < envelopes.Length; i++)
                materials[i].SetFloat(PHASE, maxPhase * envelopes[i].Update(deltaTime));
        }

        public void Trigger(int index, float value) {
            var envelope = envelopes[index];

            envelope.Duration = maxDuration * value;
            envelopes[index].Trigger();
        }

        public void DoReset() {
            foreach (var envelope in envelopes)
                envelope.Reset();
        }
    }
}
