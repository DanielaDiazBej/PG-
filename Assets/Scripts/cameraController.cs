    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform myCamera;
    private CharacterController myCameraController;

    public float sensitivity;
    public float moveSpeed;
    public float scrollSpeed;

    private float xRotationAxisClamp;
    private float xDirectionAxisClamp;
    private float yDirectionAxisClamp;
    private float zDirectionAxisClamp;

    private bool isClickLeftButton;
    private bool isClickCenterButton;

    public bool mode3D;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // Init camera controller
        myCameraController = GetComponent<CharacterController>();

        xRotationAxisClamp = 0;
        isClickLeftButton = false;
        isClickCenterButton = false;
        mode3D = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* Right Mouse Button */
        if (Input.GetMouseButtonDown(1) && mode3D)
        {
            isClickLeftButton = true;
            // Hide cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1) && mode3D)
        {
            isClickLeftButton = false;
            // Show cursor
            Cursor.lockState = CursorLockMode.None;
        }

        /* Center Mouse Button */
        if (Input.GetMouseButtonDown(2))
        {
            isClickCenterButton = true;
            // Hide cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(2))
        {
            isClickCenterButton = false;
            // Show cursor
            Cursor.lockState = CursorLockMode.None;
        }

        rotateCamera();
        moveCamera();
        zoomCamera();
    }

    private void rotateCamera()
    {
        if(isClickLeftButton){
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotationAmountX = mouseX * sensitivity;
            float rotationAmountY = mouseY * sensitivity;
            
            xRotationAxisClamp -= rotationAmountY;      

            Vector3 rotationCamera = myCamera.transform.rotation.eulerAngles;

            rotationCamera.x -= rotationAmountY;
            rotationCamera.z -= 0;
            rotationCamera.y += rotationAmountX;

            if(xRotationAxisClamp > 90){
                xRotationAxisClamp = 90;
                rotationCamera.x = 90;
            }
            else if (xRotationAxisClamp < -90){
                xRotationAxisClamp = -90;
                rotationCamera.x = 270;
            }

            myCamera.rotation = Quaternion.Euler(rotationCamera);
        }
    }

    private void moveCamera()
    {

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            if(mode3D)
            {
                Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
                moveDirection = transform.TransformDirection(moveDirection);

                moveDirection *= moveSpeed;

                myCameraController.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                float movementAmountX = moveX * moveSpeed;
                float movementAmountZ = moveZ * moveSpeed;

                xDirectionAxisClamp -= movementAmountX;
                zDirectionAxisClamp -= movementAmountZ;

                Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

                moveDirection.x -= movementAmountX;
                moveDirection.y += 0;
                moveDirection.z -= movementAmountZ;

                myCameraController.Move(moveDirection * Time.deltaTime);
            }
        
    }

    private void zoomCamera()
    {
        if (!mode3D)
        {
            float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 moveDirection = new Vector3(0, mouseScroll, 0);
            
            float movementAmountY = mouseScroll * scrollSpeed;

            xDirectionAxisClamp -= movementAmountY;


            moveDirection.y -= movementAmountY;

            myCameraController.Move(moveDirection * Time.deltaTime);
        }

    }
    public void changeMode(bool value)
    {
        mode3D = !mode3D;

        Debug.Log("Entre");
        Debug.Log(mode3D);        

        Vector3 rotationCamera = myCamera.transform.rotation.eulerAngles;

        if(mode3D)
        {
            rotationCamera.x = 40;
            rotationCamera.y = 180;
            rotationCamera.z = 0;
        }
        else
        {
            rotationCamera.x = 90;
            rotationCamera.y = 180;
            rotationCamera.z = 0;
        }

        myCamera.rotation = Quaternion.Euler(rotationCamera);
    }
}
