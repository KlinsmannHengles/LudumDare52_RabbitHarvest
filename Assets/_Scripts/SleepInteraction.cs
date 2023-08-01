using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInteraction : ItemBehaviour
{

    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && ableToInteract && firstTime)
        {
            GameManager.Instance.playerMov.moveSpeed = 0f;
            firstTime = false;
            Interact();
        } else if (Input.GetKeyDown("e") && ableToInteract && firstTime == false)
        {
            DialogueManager.Instance.DisplayNextSentence();

            //Play sound
            AudioManager.Instance.Play("nextSentence");

            if (DialogueManager.Instance.conversationIsHappening == false)
            {
                GameManager.Instance.backToMainMenuButton.SetActive(true);
            }

        }
    }

    public override void Interact()
    {

        // Make the light animation to dark
        GameManager.Instance.globalLight.GetComponent<Animator>().SetBool("GoDark", true);

        // Play sound
        AudioManager.Instance.Play("interaction");

        // Disable ambient sound
        GameManager.Instance.mainCamera.GetComponent<AudioSource>().volume = 0f;

        // Disable Inventory UI
        GameManager.Instance.allInventory.SetActive(false);

        Debug.Log("Will call final");
        StartCoroutine(CallFinal());



        //Destroy(this.gameObject);
    }

    public IEnumerator CallFinal()
    {

        Debug.Log("Calling Final");

        // Change conversation
        DialogueManager.Instance.actualDialogue = 6;

        yield return new WaitForSeconds(5f);

        Debug.Log("Passed Final");

        //Enable just the Grandma Dialogue Box
        GameManager.Instance.grandmaDialogueBox.SetActive(true);

        // Start the dialogue
        DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }

}
