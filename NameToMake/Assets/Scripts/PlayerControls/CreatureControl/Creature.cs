using System;
using System.Collections;
using System.Threading.Tasks;
using PlayerControls.PlayerControl;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerControls.CreatureControl
{
    public class Creature :MonoBehaviour
    {
        
        private HealthSystem _healthSystem;
        [SerializeField]
        private HealthCanvas _healthCanvas;
        [SerializeField]
        private Slider _slider;
        public Animator Animator;

        private GameObject _player;
        private ExperienceSystem _playerExperienceSystem;
        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Damage = Animator.StringToHash("damage");
        
        
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerExperienceSystem = ExperienceSystem.Instance(4);
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
                 _playerExperienceSystem.GetExperience(5);
                 Animator.SetTrigger(Die);
                 GetComponent<Collider>().enabled = false;
                 StartCoroutine(DeathCreature());
             }
             else
             {
                 Animator.SetTrigger(Damage);
             }
        }
        IEnumerator DeathCreature()
        {
            yield return new WaitForSeconds(10);
            Destroy(this.gameObject);
        }

        public void TakeDamage(int damage)
        {
            this._healthSystem.Damage(damage);
        }
        public void StartDealDamage()
        {
            GetComponentInChildren<CreatureDamageDealer>().StartDealDamage();
        }
        public void EndDealDamage()
        {
            GetComponentInChildren<CreatureDamageDealer>().EndDealDamage();
        }

    }
}