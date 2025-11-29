using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityModifier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "MoonMap")
        {
            Physics.gravity = new Vector3(0, -1.62f, 0);
        }

        if (SceneManager.GetActiveScene().name == "MarsMap")
        {
            Physics.gravity = new Vector3(0, -3.73f, 0);
        }
    }

    
}
