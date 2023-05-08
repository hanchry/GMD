using Cinemachine;
using UnityEngine;

namespace CameraControls
{
    public class CameraManager : MonoBehaviour
    {
        public CinemachineVirtualCamera cmVirtualCamera;
        public Camera mainCamera;

        private bool _usingVirtualCam = true;
        
        private static CameraManager Instance { get; set; }

        private void Awake()
        {
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
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _usingVirtualCam = !_usingVirtualCam;

                if (_usingVirtualCam)
                {
                    cmVirtualCamera.gameObject.SetActive(true);
                }
                else
                {
                    cmVirtualCamera.gameObject.SetActive(false);
                }
            }

            if (!_usingVirtualCam)
            {
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;

                if (x < 10)
                {
                    mainCamera.transform.position -= Vector3.forward * (Time.deltaTime * 10);
                }
                else if (x > Screen.width - 10)
                {
                    mainCamera.transform.position -= Vector3.back * (Time.deltaTime * 10);
                }

                if (y < 10)
                {
                    mainCamera.transform.position -= Vector3.left * (Time.deltaTime * 10);
                }
                else if(y > Screen.height - 10)
                {
                    mainCamera.transform.position -= Vector3.right * (Time.deltaTime * 10);

                }
            }
        }
    }
}
