using System.Collections.Generic;
using Objects;
using PlayerControls.CreatureControl;
using Sound;
using Unity.Properties;
using UnityEngine;

namespace PlayerControls.PlayerControl
{
    public class DamageDealer : MonoBehaviour
    {
        private bool canDealDamage;

        private List<GameObject> hasDealtDamage;

        [SerializeField] private float weaponLength;
        [SerializeField] private int weaponDamage;
        [SerializeField] private CombatValues _combatValues;
        void Start()
        {
            canDealDamage = false;
            hasDealtDamage = new List<GameObject>();
            
            // Will be changed when 
            // will be taken from Andrej's ui/ or add a listener to those values
            weaponDamage = _combatValues.DamageGiven().Value;
        }

        // Update is called once per frame
        void Update()
        {
            if (canDealDamage)
            {
                RaycastHit hit;
                int layerMask = 1 << 9;
                if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
                {
                    if (hit.transform.TryGetComponent(out Creature creature) && !hasDealtDamage.Contains(hit.transform.gameObject))
                    { 
                        var position = creature.transform.position;
                        creature.TakeDamage(weaponDamage);
                        SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerSwordMetalHit, position);
                        hasDealtDamage.Add(hit.transform.gameObject);
                        SoundManager.PlayCharacterSound(SoundManager.CharacterSound.CreatureDamage,position);
                    }
                }
            }
        }

        public void StartDealDamage()
        {
            canDealDamage = true; 
            hasDealtDamage.Clear();
        }
        public void EndDealDamage()
        {
            canDealDamage = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = transform;
            var position = transform1.position;
            Gizmos.DrawLine(position, position - transform1.up * weaponLength);
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, -transform.up);
        }
    }
}
