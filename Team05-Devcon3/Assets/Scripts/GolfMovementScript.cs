using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GolfMovementScript : MonoBehaviour
{
    public Camera cam;
    private bool shotPrimed =  false;
    public GameObject linee;
    public Vector3 offsett = new Vector3(136f, -474f, 284f);
    public Vector3 offsett2 = new Vector3(0f, 0f, 0f);
    public float VerticalHit = 0f;
    public float powerTotal = 1f;
    public Vector3 ballAntiDirection;
    public int strokes = 0;
    public GameObject txtStrokes;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //click
        if (Input.GetMouseButton(0))
        {
            if (!shotPrimed)
            {
                linee.SetActive(true);
            }
            
            shotPrimed = true;
            Ray rayed = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 ballAntiDirection = rayed.GetPoint(15);
            RaycastHit hit;
            Physics.Raycast(rayed, out hit);
            ballAntiDirection = hit.point;
            ballAntiDirection.y = this.transform.position.y+offsett2.y; //limit x and z direciton;
            ballAntiDirection.x = MaxPrimed(ballAntiDirection.x, this.transform.position.x);
            ballAntiDirection.z = MaxPrimed(ballAntiDirection.z, this.transform.position.z);
            //this.transform.position = ballAntiDirection;
            //Debug.Log(ballAntiDirection);
            /*
            ballAntiDirection.x = MaxPrimed(ballAntiDirection.x, this.transform.position.x);
            ballAntiDirection.z = MaxPrimed(ballAntiDirection.z, this.transform.position.z);
            ballAntiDirection += offsett2;
            */
            linee.GetComponent<LineRenderer>().SetPosition(0, ballAntiDirection);
            linee.GetComponent<LineRenderer>().SetPosition(1, this.transform.position);


            //this.transform.position = ballAntiDirection; // comment out later
            //Debug.Log(ballAntiDirection);
        }
        else if (shotPrimed)
        { // letgo.
            Ray rayed = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 ballAntiDirection = rayed.GetPoint(15);
            RaycastHit hit;
            Physics.Raycast(rayed, out hit);
            ballAntiDirection = hit.point;
            //Debug.Log(ballAntiDirection);
            linee.SetActive(false);
            shotPrimed = false;


            
            ballAntiDirection.x = MaxPrimed(ballAntiDirection.x, this.transform.position.x);
            ballAntiDirection.z = MaxPrimed(ballAntiDirection.z, this.transform.position.z);

            

            var heading = ballAntiDirection+(Vector3.up*VerticalHit) - this.transform.position + offsett2;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            
            //direction += Vector3.up;
            this.GetComponent<Rigidbody>().AddForce(direction*distance*powerTotal, ForceMode.Impulse);
            strokes++;
            txtStrokes.GetComponent<TextMeshProUGUI>().text = "Strokes: " + strokes;
        }


        //make point and attach other point to mouse

        // add string or rope or whatever

        //dragback

        // when released, move ball

        // force = distance between ball and mouse.

        // 
    }
    private float MaxPrimed(float q, float ball)
    {
        int max = 20;
        if (q < ball - max)
        {
            q = ball - max;
        }
        else if (q > ball + max)
        {
            q = ball + max;
        }

            return (q);
    }

    private Vector3 CircleCalc(Vector3 input)
    {

        Vector3 output = Vector3.zero;


        return (output);
    }
}
