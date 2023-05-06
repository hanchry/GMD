using PlayerControls.PlayerControl;
using UnityEngine;

namespace PlayerControls.CreatureControl
{
    public class CreatureDamageDealer : MonoBehaviour
    {
        
        [SerializeField]
        private float radius;
        [SerializeField]
        private float maxDistance;

        private bool canDealDamage;
        private bool hasDealtDamage;

        private int weaponDamage = 10;
        
        // Start is called before the first frame update
        void Start()
        { 
            canDealDamage = false;
            hasDealtDamage = false;
            radius = 0.5f;
            maxDistance = 3f;
        }

        // Update is called once per frame
        void Update()
        {
            if (canDealDamage && !hasDealtDamage)
            {
                RaycastHit hit;
                Vector3 origin = transform.position;
                Vector3 direction = transform.forward;
                int layerMask = LayerMask.GetMask("Player");
                if (Physics.SphereCast(origin, radius,direction, out hit, maxDistance, layerMask))
                {
                    if (hit.transform.TryGetComponent(out Player player))
                    {
                        Debug.Log("damage");
                     //   player.TakeDamage(weaponDamage);
                        
                        hasDealtDamage = true;
                    }
                }
            }
        
        }

        public void StartDealDamage()
        {
            canDealDamage = true;
            hasDealtDamage = false;
        }
        
        public void EndDealDamage()
        {
            canDealDamage = false;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;
            float radius = 0.5f;
            Gizmos.DrawSphere(origin, radius);
        }
    }
}
