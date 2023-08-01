using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActiveCreditsUI()
    {
        MainMenuManager.Instance.creditsMenu.SetActive(true);
    }

    public void ActiveMainMenuUI()
    {
        MainMenuManager.Instance.mainMenu.SetActive(true);
    }

}
