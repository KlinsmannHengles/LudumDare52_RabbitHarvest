using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaBehaviour : MonoBehaviour
{

    public bool ableToInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && ableToInteract)
        {
            GrandmaInteraction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.pressEButton.transform.position = this.transform.position + new Vector3(0, 1, 0);
            GameManager.Instance.pressEButton.SetActive(true);
            ableToInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.pressEButton.SetActive(false);
            ableToInteract = false;
        }
    }

    public void GrandmaInteraction()
    {

        if (DialogueManager.Instance.conversationIsHappening)
        {
            DialogueManager.Instance.DisplayNextSentence();

            //Play sound
            AudioManager.Instance.Play("nextSentence");

            return;
        }

        if (GameManager.Instance.actualMission == 0) // Mission 01: Apple Mission
        {
            if (GameManager.Instance.missionState == MissionState.ENABLE_TO_START)
            {

                //Enable just the Grandma Dialogue Box
                GameManager.Instance.grandmaDialogueBox.SetActive(true);
                //Play sound
                AudioManager.Instance.Play("interaction");

                // Start de dialogue
                DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

                // Enable all the apples to be collected
                GameManager.Instance.Mission01_Apples(GameManager.Instance.mission01_Apples);

                // change the state
                GameManager.Instance.missionState = MissionState.STARTED;
                DialogueManager.Instance.actualDialogue = 1;
            } else if (GameManager.Instance.missionState == MissionState.STARTED)
            {

                //Enable just the Grandma Dialogue Box
                GameManager.Instance.grandmaDialogueBox.SetActive(true);
                //Play sound
                AudioManager.Instance.Play("interaction");

                // Start de dialogue
                DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

                // colocar um diálogo pra ficar repetindo
                Debug.Log("Come back when you take all the apples");
            } else if (GameManager.Instance.missionState == MissionState.ENABLE_TO_FINISH)
            {

                //Enable just the Grandma Dialogue Box
                GameManager.Instance.grandmaDialogueBox.SetActive(true);
                //Play sound
                AudioManager.Instance.Play("interaction");

                // Start de dialogue
                DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

                // Change to the next mission
                GameManager.Instance.actualMission =1;
                GameManager.Instance.missionState = MissionState.STARTED;

                // Enable cow interaction
                GameManager.Instance.cow.GetComponent<CapsuleCollider2D>().enabled = true;

                // Change the conversation
                DialogueManager.Instance.actualDialogue = 3;

                // desativar o que for necessário
                GameManager.Instance.CleanInventory();
            }
        } else if (GameManager.Instance.actualMission == 1) // Take the milk from the cow
        {
            if (GameManager.Instance.missionState == MissionState.STARTED)
            {
                //Enable just the Grandma Dialogue Box
                GameManager.Instance.grandmaDialogueBox.SetActive(true);
                //Play sound
                AudioManager.Instance.Play("interaction");

                // Start dialogue
                DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();
            } else if (GameManager.Instance.missionState == MissionState.ENABLE_TO_FINISH)
            {
                //Enable just the Grandma Dialogue Box
                GameManager.Instance.grandmaDialogueBox.SetActive(true);
                //Play sound
                AudioManager.Instance.Play("interaction");

                // Start de dialogue
                DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

                //Change to the next mission
                GameManager.Instance.actualMission = 2;
                GameManager.Instance.missionState = MissionState.STARTED;

                // Enable sleep interaction
                GameManager.Instance.sleepInteraction.SetActive(true);

                // Change conversation
                DialogueManager.Instance.actualDialogue = 5;

            }
        } else if (GameManager.Instance.actualMission == 2) // Go to sleep
        {
            //Enable just the Grandma Dialogue Box
            GameManager.Instance.grandmaDialogueBox.SetActive(true);
            //Play sound
            AudioManager.Instance.Play("interaction");

            // Start de dialogue
            DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

}
