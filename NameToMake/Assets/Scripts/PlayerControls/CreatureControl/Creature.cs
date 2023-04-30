using UnityEngine;

namespace PlayerControls.CreatureControl
{
    public class Creature :MonoBehaviour
    {
        private HealthSystem _healthSystem;

        public Animator Animator;
        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Damage = Animator.StringToHash("damage");
        
        public Creature(HealthSystem healthSystem)
        {
            this._healthSystem =  healthSystem;
            healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
        {
             float healthValue = _healthSystem.GetHealthPercent();
             if (healthValue <= 0)
             {
                 Animator.SetTrigger(Die);
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