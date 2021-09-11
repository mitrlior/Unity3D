using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed, angularSpeed;
    private CharacterController controller;
    private float rotaionAboutX, rotaionAboutY;
    public GameObject playerCamera;
    void Start()
    {
        speed = 2;
        angularSpeed = 200;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy = -1, dz; // dy = -1 is gravity
        // Can be one of -1,0,1
        //Player Rotaion
        rotaionAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotaionAboutY, 0);
        // Camera Rotaion
        rotaionAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        playerCamera.transform.localEulerAngles = new Vector3(rotaionAboutX, 0, 0);
        //KeyboardRotaion
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // right/left
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;  //Forward/Backwords
        //motion using character controller
        Vector3 motion = new Vector3(dx, dy, dz); //Motion is defined in Local Coordinates
        motion = transform.TransformDirection(motion); //Now motion is in Global coordiantes
        controller.Move(motion); //must recive Vector3 in Global coordinates
    }
}
