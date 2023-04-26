using UnityEngine;
using UnityEngine.AI;

namespace PlayerControls
{
    public class Movement : MonoBehaviour
    {
        public NavMeshAgent agent;
    
        public float rotateSpeedMovement = 0.05f;

        private float rotateVelocity;

        public Animator anim;
    
        private float motionSmoothTime = 0.1f;
        private static readonly int Speed = Animator.StringToHash("Speed");


        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            Animation();
            Move();
        }

        public void Move()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        agent.SetDestination(hit.point);
                        agent.stoppingDistance = 0;

                        Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement* (Time.deltaTime*5));

                        transform.eulerAngles = new Vector3(0, rotationY, 0);
                    }
                }
            }
        }
        
        
        public void Animation()
        {
           float speed = agent.velocity.magnitude/agent.speed;
            anim.SetFloat(Speed, speed, motionSmoothTime, Time.deltaTime);
        }
    }
}
