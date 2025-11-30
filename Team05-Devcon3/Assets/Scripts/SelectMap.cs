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
    bool isLoadingMars = true;
    bool isLoadingEuropa = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moon.onClick.AddListener(MoonClick);
        mars.onClick.AddListener(MarsClick);
        europa.onClick.AddListener(EuropaClick);
        
    }

    public void MoonClick()
    {
        if (isLoadingMoon)
        {
            SceneManager.LoadScene("MoonMap");
            isLoadingMoon = false;
        }
    }

    public void MarsClick()
    {
        if (isLoadingMars)
        {
            SceneManager.LoadScene("MarsMap");
            isLoadingMars = false;
        }
    }
    public void EuropaClick()
    {
        if (isLoadingEuropa)
        {
            SceneManager.LoadScene("EuropaMap");
            isLoadingEuropa = false;
        }
    }
}
