using System.Collections;
using System.Collections.Generic;
using SRXDCustomVisuals.Core;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_Scene : MonoBehaviour {
        [SerializeField] private USA_Book book;
        [SerializeField] private USA_PixelRing pixelRing;
        [SerializeField] private USA_LaserRing laserRing;
        [SerializeField] private USA_PlanetRings planetRings;
        [SerializeField] private USA_WaveLines waveLines;
        [SerializeField] private USA_Particles particles;
        [SerializeField] private USA_Earth earth;
            
        private VisualsEventReceiver eventReceiver;
        
        private void Awake() {
            eventReceiver = GetComponent<VisualsEventReceiver>();
            eventReceiver.On += EventOn;
            eventReceiver.Off += EventOff;
            eventReceiver.ControlChange += EventControlChange;
            eventReceiver.Reset += EventReset;
        }

        private void EventOn(VisualsEvent visualsEvent) {
            
        }

        private void EventOff(VisualsEvent visualsEvent) {
            
        }

        private void EventControlChange(VisualsEvent visualsEvent) {
            
        }

        private void EventReset() {
            
        }
    }
}
