using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using PlayerControls.PlayerControl;
using UnityEngine;

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
        {
            Invoke(nameof(SpawnObject), 1f);
        }
    }
}
