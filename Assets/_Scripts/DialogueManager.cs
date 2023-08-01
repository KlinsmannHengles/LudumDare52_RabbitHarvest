using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private Queue<string> sentences;

    public bool conversationIsHappening = false;

    public int actualDialogue = 0;

    public PlayerMovement playerMovement;

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
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        playerMovement.moveSpeed = 0f;

        conversationIsHappening = true;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // MUDAR ISSO AQUI PORQUE SÓ APARECE O QUE A VÓ FALA
        GameManager.Instance.grandmaDialogueText.text = sentence;
    }

    void EndDialogue()
    {
        GameManager.Instance.grandmaDialogueBox.SetActive(false);
        conversationIsHappening = false;

        playerMovement.moveSpeed = 5f;

        Debug.Log("End of conversation");
    }

}
