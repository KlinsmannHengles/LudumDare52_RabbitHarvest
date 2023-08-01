using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public static MainMenuManager Instance { get; private set; }

    public GameObject mainCamera;
    public GameObject mainMenu;
    public GameObject creditsMenu;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");

        gameObject.GetComponent<AudioSource>().Play();
    }

    public void CreditsButton()
    {
        Debug.Log("CreditsButton clicked");
        mainCamera.GetComponent<Animator>().SetBool("GoRight", true);

        gameObject.GetComponent<AudioSource>().Play();


        mainMenu.SetActive(false);
    }

    public void BackToMainMenuButton()
    {
        mainCamera.GetComponent<Animator>().SetBool("GoRight", false);

        gameObject.GetComponent<AudioSource>().Play();

        creditsMenu.SetActive(false);
    }

    public void QuitButton()
    {

        gameObject.GetComponent<AudioSource>().Play();

        Application.Quit();
    }

}
