using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    public Button moon;
    public Button mars;
    public Button europa;
    bool isLoadingMoon = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moon.onClick.AddListener(MoonClick);
        
    }

    public void MoonClick()
    {
        if (isLoadingMoon)
        {
            SceneManager.LoadScene("MoonMap");
            isLoadingMoon = false;
        }
    }
}
