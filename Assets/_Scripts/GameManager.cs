using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum MissionState { ENABLE_TO_START, STARTED, ENABLE_TO_FINISH}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("General")]
    public GameObject globalLight;
    public GameObject mainCamera;
    public PlayerMovement playerMov;

    [Header("UI")]
    public GameObject allInventory;

    public GameObject pressEButton; // it is not in UI, will apear above the object

    public Image item_Slot01;
    public Image item_Slot02;
    public Image item_Slot03;

    public GameObject backToMainMenuButton;

    [Header("Dialogue")]

    public GameObject allDialogueUI;
    public GameObject grandmaDialogueBox;
    public GameObject granddaughterDialogueBox;

    public TextMeshProUGUI grandmaDialogueText;
    public TextMeshProUGUI granddaughterDialogueText;

    [Header("General Missions")]
    public int actualMission = 0;
    public MissionState missionState = MissionState.ENABLE_TO_START;

    [Header("Mission 1: Apples")]
    public bool mission01_Apples = false;
    public int applesCollected = 0;
    public GameObject[] apples;

    [Header("Mission 2: Milk")]
    public bool mission02_Milk = false;
    public bool interactedWithCow = false;
    public GameObject cow;
    public GameObject cowMuuu;

    [Header("Mission 3: Sleep")]
    public bool mission03_Sleep = false;
    public GameObject sleepInteraction;

    private void Awake()
    {

        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is the one who is called by the item
    public void SelectInventorySlot(Sprite toUISprite)
    {
        if (item_Slot01.sprite == null)
        {
            AddToInventory(item_Slot01, toUISprite);
        } else if (item_Slot02.sprite == null)
        {
            AddToInventory(item_Slot02, toUISprite);
        } else if (item_Slot03.sprite == null)
        {
            AddToInventory(item_Slot03, toUISprite);
        } else
        {
            Debug.Log("There is no empty place in your inventory");
        }
    }

    // This one is called just by SelectInventorySlot, and NOT by the item
    public void AddToInventory(Image slot, Sprite toUISprite)
    {
        slot.gameObject.SetActive(true);
        slot.sprite = toUISprite;
    }

    public void Mission01_Apples(bool mission)
    {
        mission = true;

        foreach(GameObject apple in apples)
        {
            apple.SetActive(true);
        }
    }

    public bool CheckMission01Completed()
    {
        if (GameManager.Instance.applesCollected == 3)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void CleanInventory()
    {
        // clean images
        item_Slot01.sprite = null;
        item_Slot02.sprite = null;
        item_Slot03.sprite = null;
        
        // disable images
        item_Slot01.enabled = false;
        item_Slot02.enabled = false;
        item_Slot03.enabled = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
