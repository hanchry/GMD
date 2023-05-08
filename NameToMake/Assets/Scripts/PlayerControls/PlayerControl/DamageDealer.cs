using System.Collections.Generic;
using Model;
using Objects;
using PlayerControls.CreatureControl;
using Sound;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Serialization;

namespace PlayerControls.PlayerControl
{
    public class DamageDealer : MonoBehaviour
    {
        private bool _canDealDamage;
        private Damage _damageGiven;
        
        private List<GameObject> _hasDealtDamage;

        [SerializeField] private float weaponLength;
        [FormerlySerializedAs("_combatValues")] 
        [SerializeField] private CombatValues combatValues;
        void Start()
        {
            _canDealDamage = false;
            _hasDealtDamage = new List<GameObject>();
            
            // Will be changed when 
            // will be taken from Andrej's ui/ or add a listener to those values
            _damageGiven = combatValues.DamageGiven();
      
        }

        // Update is called once per frame
        void Update()
        {
            if (_canDealDamage)
            {
                RaycastHit hit;
                int layerMask = 1 << 9;
                if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
                {
                    if (hit.transform.TryGetComponent(out Creature creature) && !_hasDealtDamage.Contains(hit.transform.gameObject))
                    { 
                        var position = creature.transform.position;
                        creature.TakeDamage(combatValues.DamageReceived(_damageGiven));
                        
                        SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerSwordMetalHit, position);
                        _hasDealtDamage.Add(hit.transform.gameObject);
                        SoundManager.PlayCharacterSound(SoundManager.CharacterSound.CreatureDamage,position);
                    }
                }
            }
        }

        public void StartDealDamage()
        {
            _canDealDamage = true; 
            _hasDealtDamage.Clear();
        }
        public void EndDealDamage()
        {
            _canDealDamage = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = transform;
            var position = transform1.position;
            Gizmos.DrawLine(position, position - transform1.up * weaponLength);
            
            Gizmos.color = Color.red;
            var transform2 = transform;
            Gizmos.DrawRay(transform2.position, -transform2.up);
        }
    }
}
