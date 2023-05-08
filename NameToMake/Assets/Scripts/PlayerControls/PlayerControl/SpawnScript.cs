using Cinemachine;
using UnityEngine;

namespace PlayerControls.PlayerControl
{
    public class SpawnScript : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera cmVirtualCamera;
        [SerializeField]
        public GameObject prefab;
        private GameObject _spawnedObject;
    
        private void Start()
        {
            SpawnObject();
            Player.Subscribe(OnObjectDestroyed);
        }

        private void SpawnObject()
        {
            _spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
            cmVirtualCamera.Follow = _spawnedObject.transform;
        }

        private void OnDestroy()
        {
            Player.Unsubscribe(OnObjectDestroyed);
        }
        private void OnObjectDestroyed(GameObject destroyedObject)
        {
            if (_spawnedObject != null)
            { GameObject deathUi2 = GameObject.Find("DeadPopUp(Clone)");
                if(deathUi2 != null)
                    Destroy(deathUi2);
                Invoke(nameof(SpawnObject), 1f);
            }
        }
    }
}
