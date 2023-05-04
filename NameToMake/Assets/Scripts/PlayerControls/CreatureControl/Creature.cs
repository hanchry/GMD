using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerControls.CreatureControl
{
    public class Creature :MonoBehaviour
    {
        [SerializeField]
        private HealthSystem _healthSystem;
        [SerializeField]
        private HealthCanvas _healthCanvas;
        [SerializeField]
        private Slider _slider;
        public Animator Animator;

        private GameObject player;
        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Damage = Animator.StringToHash("damage");
        
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            // get from ui
            _healthSystem = new HealthSystem(100);
            _healthCanvas.Setup(_healthSystem,_slider);
            _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private  void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
        {
             float healthValue = _healthSystem.GetHealthPercent();
             
             if (healthValue <= 0)
             {
                 Animator.SetTrigger(Die);
                 GetComponent<Collider>().enabled = false;
                 //  Destroy(this.gameObject);
             }
             else
             {
                 Animator.SetTrigger(Damage);
             }
        }

        public void TakeDamage(int damage)
        {
            this._healthSystem.Damage(damage);
        }
    }
}