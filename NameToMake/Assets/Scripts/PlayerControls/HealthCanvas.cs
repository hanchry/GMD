using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PlayerControls
{
    public class HealthCanvas : MonoBehaviour
    {
        [SerializeField]
        private HealthSystem _healthSystem;
        [FormerlySerializedAs("_slider")] [SerializeField]
        private Slider slider;
        public void Setup(HealthSystem healthSystem, Slider slider)
        {
            _healthSystem = healthSystem;
            this.slider = slider;
            healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
        {
            slider.value = _healthSystem.GetHealthPercent();
        }
        // Update is called once per frame
        void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0,180,0 );
        }
        
    }
}