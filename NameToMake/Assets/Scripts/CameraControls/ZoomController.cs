using Cinemachine;
using UnityEngine;

namespace CameraControls
{
    public class ZoomController : MonoBehaviour
    {
    
        public CinemachineVirtualCamera _virtualCamera;
        private float fieldOfViewMin = 30f;
        private float fieldOfViewMax = 180f;
        private float targetFieldOfView = 50;
        
        private float followOffsetMin = 10f;
        private float followOffsetMax = 60f;
        private Vector3 followOffset;

        private void Awake()
        {
            followOffset = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset;
        }

        // Start is called before the first frame update
        void Start()
        {
            // HandleCameraZoom_MoveCamera();
        }
    
        // Update is called once per frame
        void Update()
        {

             HandleCameraZoom_MoveCamera();
        }

        private void HandleCameraZoom_FieldOfView()
        {
            float fieldOfViewIncreaseAmount = 5f;
            if (Input.mouseScrollDelta.y > 0)
            {
                targetFieldOfView -= fieldOfViewIncreaseAmount;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                targetFieldOfView += fieldOfViewIncreaseAmount;
            }

            targetFieldOfView = Mathf.Clamp(targetFieldOfView, fieldOfViewMin, fieldOfViewMax);
            float zoomSpeed = 3f;
            _virtualCamera.m_Lens.FieldOfView = 
                Mathf.Lerp(_virtualCamera.m_Lens.FieldOfView, targetFieldOfView, Time.deltaTime * zoomSpeed);
        }
        private void HandleCameraZoom_MoveCamera()
        {
            Vector3 zoomDir = followOffset.normalized;
            if (Input.mouseScrollDelta.y > 0)
            {
                followOffset += zoomDir;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                followOffset -= zoomDir;
            }

            if (followOffset.magnitude < followOffsetMin)
            {
                followOffset = zoomDir * followOffsetMin;
            }
            if (followOffset.magnitude > followOffsetMax)
            {
                followOffset = zoomDir * followOffsetMax;
            }

            float zoomSpeed = 10f;
            _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = 
                Vector3.Lerp(_virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset,
                    followOffset, Time.deltaTime * zoomSpeed);

            _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = followOffset;
        }
    
    }
}
