using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Apple : ItemBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && ableToInteract)
        {
            Interact();
        }
    }

    public override void Interact()
    {
        GameManager.Instance.applesCollected += 1;
        //check if the player took all the apples
        if (GameManager.Instance.CheckMission01Completed())
        {
            GameManager.Instance.missionState = MissionState.ENABLE_TO_FINISH;
            DialogueManager.Instance.actualDialogue = 2;
        }

        //Play sound
        AudioManager.Instance.Play("interaction");

        //GameManager.Instance.item_Slot01.gameObject.SetActive(true);
        //GameManager.Instance.item_Slot01.sprite = toUISprite;
        GameManager.Instance.SelectInventorySlot(toUISprite);
        Destroy(this.gameObject);
    }

}
