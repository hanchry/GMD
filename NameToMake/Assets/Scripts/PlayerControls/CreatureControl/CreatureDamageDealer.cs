using UnityEngine;

namespace PlayerControls.CreatureControl
{
    public class CreatureDamageDealer : MonoBehaviour
    {
        
        [SerializeField]
        private float weaponLength;
        [SerializeField]
        private float weaponDamage;

        private bool canDealDamage;

        private bool hasDealtDamage;
        // Start is called before the first frame update
        void Start()
        { 
            canDealDamage = false;
            hasDealtDamage = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (canDealDamage && !hasDealtDamage)
            {
                RaycastHit hit;
                int layerMask = 1 << 8;
                Debug.DrawRay(transform.position,-transform.up);
                if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
                {
                    Debug.Log("ENEMY GAVE DAMAGE");
                    hasDealtDamage = true;
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
            Gizmos.color = Color.yellow;
            var transform1 = transform;
            var position = transform1.position;
            Gizmos.DrawLine(position, position - transform1.up * weaponLength);
        }
    }
}
