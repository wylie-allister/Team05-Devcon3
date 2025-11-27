using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolfBallCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* private void OnCollisionEnter(Collision collision)
     {
         //Debug.Log(collision.gameObject.tag);
         if(collision.collider.tag == "Hole")
         {
             winner.SetActive(true);
         }
     } */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            winner.SetActive(true);
        }
    }
}
