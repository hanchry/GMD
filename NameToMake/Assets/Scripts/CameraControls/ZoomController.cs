using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace CameraControls
{
    public class ZoomController : MonoBehaviour
    {
    
        [FormerlySerializedAs("_virtualCamera")] 
        public CinemachineVirtualCamera virtualCamera;

        private const float FollowOffsetMin = 20f;
        private const float FollowOffsetMax = 60f;
        private Vector3 _followOffset;
        
        public static ZoomController Instance { get; private set; }

        private void Awake()
        {
            _followOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        // Update is called once per frame
        void LateUpdate()
        {
            HandleCameraZoom_MoveCamera();
        }
        
        private void HandleCameraZoom_MoveCamera()
        {
            Vector3 zoomDir = _followOffset.normalized;
            float zoomAmount = 2f; 
            if (Input.mouseScrollDelta.y > 0)
            {
                _followOffset += zoomDir* zoomAmount;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                _followOffset -= zoomDir* zoomAmount;
            }

            if (_followOffset.magnitude < FollowOffsetMin)
            {
                _followOffset = zoomDir * FollowOffsetMin;
            }
            if (_followOffset.magnitude > FollowOffsetMax)
            {
                _followOffset = zoomDir * FollowOffsetMax;
            }

            float zoomSpeed = 10f;
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = 
                Vector3.Lerp(virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset,
                    _followOffset, Time.deltaTime * zoomSpeed);

            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _followOffset;
        }
    
    }
}
