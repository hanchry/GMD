using Objects;
using PlayerControls.PlayerControl;
using Sound;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerControls.CreatureControl
{
    public class CreatureDamageDealer : MonoBehaviour
    {
        
        [FormerlySerializedAs("_combatValues")] [SerializeField] 
        private CombatValues combatValues;
        [SerializeField]
        private float radius;
        [SerializeField]
        private float maxDistance;

        private bool _canDealDamage;
        private bool _hasDealtDamage;
        private Damage _damageGiven;
        
        // Start is called before the first frame update
        void Start()
        { 
            _canDealDamage = false;
            _hasDealtDamage = false;
            radius = 0.5f;
            maxDistance = 3f;
            _damageGiven = combatValues.DamageGiven();
        }

        // Update is called once per frame
        void Update()
        {
            if (_canDealDamage && !_hasDealtDamage)
            {
                RaycastHit hit;
                var transform1 = transform;
                
                Vector3 origin = transform1.position;
                Vector3 direction = transform1.forward;
                
                int layerMask = LayerMask.GetMask("Player");
                
                if (Physics.SphereCast(origin, radius,direction, out hit, maxDistance, layerMask))
                {
                    if (hit.transform.TryGetComponent(out Player player))
                    { 
                         player.TakeDamage(combatValues.DamageReceived(_damageGiven));
                        
                         _hasDealtDamage = true;
                         SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerDamage, player.transform.position);
                    }
                }
            }
        
        }

        public void StartDealDamage()
        {
            _canDealDamage = true;
            _hasDealtDamage = false;
        }
        
        public void EndDealDamage()
        {
            _canDealDamage = false;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var transform1 = transform;
            Vector3 origin = transform1.position;
            Vector3 direction = transform1.forward;
            float radius = 0.5f;
            Gizmos.DrawSphere(origin, radius);
        }
    }
}
