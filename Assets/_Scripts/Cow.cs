using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : ItemBehaviour
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
        // You already interacted with the Cow
        GameManager.Instance.interactedWithCow = true;

        // Disable cow interaction
        GameManager.Instance.cow.GetComponent<CapsuleCollider2D>().enabled = false;

        // Muu
        GameManager.Instance.cowMuuu.SetActive(true);

        //Play sound
        AudioManager.Instance.Play("interaction");

        // Change next Dialogue
        DialogueManager.Instance.actualDialogue = 4;

        GameManager.Instance.missionState = MissionState.ENABLE_TO_FINISH;
    
    }

}
