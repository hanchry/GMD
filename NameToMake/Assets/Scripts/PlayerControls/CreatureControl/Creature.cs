using System;
using System.Collections;
using Objects;
using Sound;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PlayerControls.CreatureControl
{
    public class Creature :MonoBehaviour
    {
        
        [FormerlySerializedAs("_atributesSkills")] [SerializeField]
        private AtributesSkills atributesSkills;
        private HealthSystem _healthSystem;
        [FormerlySerializedAs("_healthCanvas")] [SerializeField]
        private HealthCanvas healthCanvas;
        [FormerlySerializedAs("_slider")] [SerializeField]
        private Slider slider;
        [FormerlySerializedAs("Animator")] public Animator animator;

        private AtributesSkills _atributesSkills;
        
       
        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Damage = Animator.StringToHash("damage");
        
        private void Start()
        {
            _atributesSkills =  transform.GetComponent<AtributesSkills>();
            _healthSystem = new HealthSystem( Convert.ToInt32(_atributesSkills.Hp));
            healthCanvas.Setup(_healthSystem,slider);
            _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private  void HealthSystem_OnHealthChanged(object sender, EventArgs e)
        {
             float healthValue = _healthSystem.GetHealthPercent();
             
             if (healthValue <= 0)
             {  
                 atributesSkills.IncreaseXp(5);
                 animator.SetTrigger(Die);
                 GetComponent<Collider>().enabled = false;
                 SoundManager.PlayCharacterSound(SoundManager.CharacterSound.CreatureDying, transform.position);
                 StartCoroutine(DeathCreature());
             }
             else
             {
                 animator.SetTrigger(Damage);
             }
        }
        IEnumerator DeathCreature()
        {
            yield return new WaitForSeconds(10);
            Destroy(this.gameObject);
        }

        public void TakeDamage(Damage damage)
        {
            _healthSystem.Damage(damage.Value);
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