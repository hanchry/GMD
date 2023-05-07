using System;
using System.Collections;
using System.Threading.Tasks;
using Objects;
using PlayerControls.PlayerControl;
using Sound;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerControls.CreatureControl
{
    public class Creature :MonoBehaviour
    {
        
        [SerializeField]
        private AtributesSkills _atributesSkills;
        private HealthSystem _healthSystem;
        [SerializeField]
        private HealthCanvas _healthCanvas;
        [SerializeField]
        private Slider _slider;
        public Animator Animator;

        private GameObject _player;
        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Damage = Animator.StringToHash("damage");
        
        
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            
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
                 _atributesSkills.IncreaseXp(5);
                 Animator.SetTrigger(Die);
                 GetComponent<Collider>().enabled = false;
                 SoundManager.PlayCharacterSound(SoundManager.CharacterSound.CreatureDying, transform.position);
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