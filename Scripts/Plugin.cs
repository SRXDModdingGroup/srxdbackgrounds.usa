using BepInEx;
using UnityEngine;

namespace SRXDBackgrounds.USA {
    [BepInDependency("srxd.customvisuals", "1.2.5")]
    [BepInDependency("srxd.backgrounds.common","1.0.2")]
    [BepInPlugin("srxd.backgrounds.usa", "srxdbackgrounds.usa", "1.0.1")]
    public class Plugin : BaseUnityPlugin {
        private void Awake() => Destroy(gameObject);
    }
}
