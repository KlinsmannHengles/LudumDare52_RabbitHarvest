using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBehaviour : MonoBehaviour
{

    public Sprite toUISprite; // the sprite that goes to the UI when the item is taken

    public bool ableToInteract = false; // used when you are inside the object collider

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    public abstract void Interact();

}
