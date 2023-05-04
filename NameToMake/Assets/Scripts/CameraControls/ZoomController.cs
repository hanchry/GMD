using Cinemachine;
using UnityEngine;

namespace CameraControls
{
    public class ZoomController : MonoBehaviour
    {
    
        public CinemachineVirtualCamera _virtualCamera;

        private float followOffsetMin = 20f;
        private float followOffsetMax = 60f;
        private Vector3 followOffset;

        private void Awake()
        {
            followOffset = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        }
        
        // Update is called once per frame
        void LateUpdate()
        {
            HandleCameraZoom_MoveCamera();
        }
        
        private void HandleCameraZoom_MoveCamera()
        {
            Vector3 zoomDir = followOffset.normalized;
            float zoomAmount = 2f; 
            if (Input.mouseScrollDelta.y > 0)
            {
                followOffset += zoomDir* zoomAmount;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                followOffset -= zoomDir* zoomAmount;
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
            _virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = 
                Vector3.Lerp(_virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset,
                    followOffset, Time.deltaTime * zoomSpeed);

            _virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = followOffset;
        }
    
    }
}
