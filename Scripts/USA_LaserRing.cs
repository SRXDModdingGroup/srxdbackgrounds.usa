using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_LaserRing : MonoBehaviour {
        [SerializeField] private ParticleSystem particleSystem;

        public void Trigger() => particleSystem.Play();

        public void DoReset() => particleSystem.Clear();
    }
}
