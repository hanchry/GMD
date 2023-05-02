using UnityEngine;
using UnityEngine.UI;

namespace PlayerControls.PlayerControl
{
    public class PlayerHealthCanvas : MonoBehaviour
    {
        [SerializeField]
        private HealthSystem _healthSystem;
        [SerializeField]
        private Slider _slider;
        public void Setup(HealthSystem healthSystem)
        {
            this._healthSystem = healthSystem;
            healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }
        void Start()
        {
            _slider = GetComponent<Slider>();
          //  _slider.value = _healthSystem.GetHealthPercent();
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
        {
            _slider.value = _healthSystem.GetHealthPercent();
        }
        // Update is called once per frame
        void LateUpdate()
        {
          transform.LookAt(Camera.main.transform);
          transform.Rotate(0,180,0 );
        }
        
    }
}
