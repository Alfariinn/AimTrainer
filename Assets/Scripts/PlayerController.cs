using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    //Camera
    [SerializeField] public static float fov = 103f;
    [SerializeField] public static float mouseSensitivity = 1f;
    [SerializeField] Transform cameraHolder;
    private Camera playerCamera;

    private float rotationY;
    private float rotationX;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        playerCamera.fieldOfView = fov;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        //Camera
        rotationX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        cameraHolder.Rotate( new Vector3(0, rotationX, 0));
        playerCamera.transform.localEulerAngles = new Vector3(rotationY, 0, 0);



    }


    void OnEnable()
    {
        GameTime.OnGameEnd += GameEnd;
    }

    void OnDisable()
    {
        GameTime.OnGameEnd -= GameEnd;
    }

    private void GameEnd()
    {
        enabled = false;
    }
}
