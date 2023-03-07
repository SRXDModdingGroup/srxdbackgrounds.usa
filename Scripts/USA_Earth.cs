using UnityEngine;

namespace SRXDBackgrounds.USA {
    public class USA_Earth : MonoBehaviour {
        private static readonly int TRANSITION = Shader.PropertyToID("_Transition");
        
        [SerializeField] private MeshRenderer renderer;

        private Material material;

        private void Awake() => material = renderer.material;

        public void SetTransition(float value) => material.SetFloat(TRANSITION, value);

        public void DoReset() => material.SetFloat(TRANSITION, 1f);
    }
}
