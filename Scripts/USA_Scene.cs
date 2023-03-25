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
            eventReceiver.ControlChange += EventControlChange;
            eventReceiver.Reset += EventReset;
        }

        private void EventOn(VisualsEvent visualsEvent) {
            int index = visualsEvent.Index;
            float valueNormalized = visualsEvent.Value / 256f;

            switch (index) {
                case 0:
                    book.PulseScale(valueNormalized);
                    break;
                case 1:
                    book.TriggerParticle();
                    break;
                case < 10:
                    pixelRing.Trigger(index - 2, valueNormalized);
                    break;
                case 10:
                    laserRing.Trigger();
                    break;
                case 11:
                    planetRings.PulseScale(valueNormalized);
                    break;
            }
        }

        private void EventControlChange(VisualsEvent visualsEvent) {
            int index = visualsEvent.Index;
            float valueNormalized = visualsEvent.Value / 256f;

            switch (index) {
                case 0:
                    book.SetIntensity(valueNormalized);
                    break;
                case 1:
                    book.SetWaveAmount(valueNormalized);
                    break;
                case 2:
                    book.SetWarpAmount(valueNormalized);
                    break;
                case < 7:
                    planetRings.SetIntensity(index - 3, valueNormalized);
                    break;
                case 7:
                    planetRings.SetSpeed(valueNormalized);
                    break;
                case 8:
                    planetRings.SetWobble(valueNormalized);
                    break;
                case < 13:
                    waveLines.SetAlpha(index - 9, valueNormalized);
                    break;
                case 13:
                    particles.SetIntensity(valueNormalized);
                    break;
                case 14:
                    particles.SetSpeed(valueNormalized);
                    break;
                case 15:
                    earth.SetTransition(valueNormalized);
                    break;
            }
        }

        private void EventReset() {
            book.DoReset();
            pixelRing.DoReset();
            laserRing.DoReset();
            planetRings.DoReset();
            waveLines.DoReset();
            particles.DoReset();
            earth.DoReset();
        }
    }
}
