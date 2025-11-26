using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public GameObject player;

    public float mouseSensitivity = 5f;
    public float smoothing = 1.5f; // Smoother mouse movement 

    // Vectors to store the calculations
    private Vector2 mouseLook;
    private Vector2 smoothMovement;
    private bool firstrun = true;
    // Start is called before the first frame update
    void Start()
    {
        //player = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = player.transform.position + Vector3.up * 30;

        if (Input.GetMouseButton(1)|| firstrun)
        {
            firstrun = false;
            Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"),
                                Input.GetAxis("Mouse Y"));

            // Times the mouse input by the mouseSensitivity and smoothing
            mouseDirection.x *= mouseSensitivity * smoothing;
            mouseDirection.y *= mouseSensitivity * smoothing;



            smoothMovement.x = Mathf.Lerp(smoothMovement.x, mouseDirection.x, 1f / smoothing);
            smoothMovement.y = Mathf.Lerp(smoothMovement.y, mouseDirection.y, 1f / smoothing);



            // Add these calculations together
            mouseLook += smoothMovement;

            // Restrict the mouse position to make sure the player cannot rotate forever on the x-axis
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 0f);
            //mouseLook.y += 90;

            // Move the camera to the newest calculated position.
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            transform.localPosition = new Vector3(transform.localPosition.x, 1f + mouseLook.y / -40 + 5, transform.localPosition.z);
            // Move the player object on the x-axis only
            Quaternion rotation = player.transform.rotation;
            Quaternion rotation3 = Quaternion.AngleAxis(180, player.transform.forward);

            transform.parent.transform.rotation = Quaternion.Euler(0f, mouseLook.x, 0f);
            
        }
        transform.parent.transform.position = player.transform.position;
    }
}
