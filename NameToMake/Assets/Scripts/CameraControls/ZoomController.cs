using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float fieldOfViewMin = 30f;
    [SerializeField] private float fieldOfViewMax = 110f;
    private float targetFieldOfView = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
      HandleCameraZoom();
    }

    private void HandleCameraZoom()
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
}
