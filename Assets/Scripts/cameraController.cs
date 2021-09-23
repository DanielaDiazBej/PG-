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
            // Hide cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(2))
        {
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

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (mode3D)
        {
            Vector3 direction = new Vector3(moveX, 0f, moveZ).normalized;
            if (direction.magnitude >= 0.1f){
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + myCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);                
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                myCameraController.Move(moveDir * 500f * Time.deltaTime);
            }
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
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if(myCamera.position.y < -190){

            myCamera.position = new Vector3(myCamera.position.x, -180, myCamera.position.z);
        }
        else if(myCamera.position.y > 5000)
        {
            myCamera.position = new Vector3(myCamera.position.x, 4990, myCamera.position.z);
        }
        else
        {
            if (mode3D)
            {   
                    Vector3 moveDirection = new Vector3(0f, 0f, mouseScroll);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= moveSpeed;

                    myCameraController.Move(moveDirection * 100 * Time.deltaTime);            
            }
            else
            {
                Vector3 moveDirection = new Vector3(0, mouseScroll, 0);            
                float movementAmountY = mouseScroll * scrollSpeed;
                moveDirection.y -= movementAmountY;

                myCameraController.Move(moveDirection * Time.deltaTime);
            }
        }
    }
    
    public void changeMode(bool value)
    {
        mode3D = !mode3D;      

        Vector3 rotationCamera = myCamera.transform.rotation.eulerAngles;

        if(mode3D)
        {
            rotationCamera.x = 40;
            rotationCamera.y = 0;
            rotationCamera.z = 0;
        }
        else
        {
            rotationCamera.x = 90;
            rotationCamera.y = 0;
            rotationCamera.z = 0;
        }

        myCamera.rotation = Quaternion.Euler(rotationCamera);
    }
}
