using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private float movementSpeed = 10f;

    /* 
     * BounceCheckScroll is used to check if the camera is too close to the ground
     * If it is, it will bounce back up
     * And other way around with to high
     *
     * the problem with it is that it dosen't check if person holds the arrow key down
     * that might be a problem in the future regarding cheating
     */
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 movement = value.ReadValue<Vector2>();
        pos = new Vector3(movement.x, BounceCheckScroll(0), movement.y);
    }

    private bool _repeat = false;

    public void OnSpeedUp(InputAction.CallbackContext value)
    {
        if (value.ReadValue<float>() == 1 && !_repeat)
        {
            movementSpeed *= 10;
            _repeat = true;
        }
        else if (value.ReadValue<float>() == 0)
        {
            movementSpeed /= 10;
            _repeat = false;
        }
    }

    public void OnCenter(InputAction.CallbackContext value)
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float screenHeight = Camera.main.orthographicSize * 3f;
        transform.position = new Vector3(playerPos.x, playerPos.y + 20, playerPos.z + screenHeight);
    }

    private float _movement;
    private bool _slowDownScroll;
    [SerializeField] private float movementMultiplier = 130f;

    public void OnScroll(InputAction.CallbackContext value)
    {
        if ((value.ReadValue<float>() < 0 || (value.ReadValue<float>() > 0)))
        {
            int simpleValue = value.ReadValue<float>() > 0 ? 1 : -1;
            _movement += simpleValue * movementMultiplier * Time.deltaTime;
            movementMultiplier *= 2f;
            pos.y = BounceCheckScroll(_movement) * 10f;
            _slowDownScroll = false;
        }
        else
        {
            movementMultiplier = 130f;
            _slowDownScroll = true;
        }
    }

    void Start()
    {
        pos = new Vector3();
        _movement = 0;
        _slowDownScroll = false;
        _slowDownTick = 0;
    }

    private float _slowDownTick;
    private float _cameraHeightTick = 0f;
    void Update()
    {
        /*
         * This is the part that slows down the camera when scrolling
         *
         * Would be nice to have it outside of the update, improve for future
         */
        if (_slowDownScroll && _movement is < 0f or > 0f)
        {
            if (_slowDownTick > 0.22)
            {
                if (_movement is < 0.1f or > -0.1f)
                {
                    _slowDownTick = 0;
                    _movement = 0f;
                }
                else
                {
                    float simpleValue = _movement > 0f ? 1 : -1;
                    _movement -= simpleValue * Time.deltaTime;
                }

                pos.y = _movement;
            }
            else
            {
                _slowDownTick += Time.deltaTime;
            }
        }
        
        /*
         * This is the part that moves the camera
         * It is a bit messy, but it works
         */
        pos.x *= movementSpeed;
        pos.z *= movementSpeed;
        transform.position -= pos * Time.deltaTime;
        pos.x /= movementSpeed;
        pos.z /= movementSpeed;

        if (scrollChecked)
        {
            if (_cameraHeightTick > 0.7)
            {
                pos.y = 0;
                scrollChecked = false;
                _cameraHeightTick = 0;
            }
            else
            {
                _cameraHeightTick += Time.deltaTime;
            }
        }
    }

    float GetCameraHeight()
    {
        GameObject camera = GameObject.Find("Main Camera");
        Vector3 cameraLocation = camera.transform.position;
        Ray ray = new Ray(cameraLocation, Vector3.down);
        float cameraHeightDiff = 0;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            cameraHeightDiff = hit.distance;
        }

        return cameraHeightDiff;
    }
    
    private float lowHeight = 20f;
    private float highHeight = 60f;
    private bool scrollChecked = false;

    float BounceCheckScroll(float height)
    {
        float distance = GetCameraHeight();
        
        if (distance - height > highHeight && Math.Abs(height - highHeight) > 1f)
        {
            scrollChecked = true;
            return height + ((distance - height)- highHeight);
        }
        else if (distance - height < lowHeight && Math.Abs(height - lowHeight) > 1f)
        {
            scrollChecked = true;
            return height + ((distance - height) - lowHeight);
        }
        scrollChecked = false;
        return height;
    }
    

    
}