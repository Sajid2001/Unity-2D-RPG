using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Message raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange )
        {
            if (!isOpen)
            {
                //Open Chest
                OpenChest();
            }
            else
            {
                //Chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        //Dialog window on
        dialogBox.SetActive(true);
        //text = content text
        dialogText.text = contents.itemDescription;
        //add item to inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //raise signal to animate
        raiseItem.Raise();
        isOpen = true;
        anim.SetBool("Opened", true);
    }
    public void ChestAlreadyOpen()
    {
            //dialog off
            dialogBox.SetActive(false);
            //raise signal to player to stop animating
            raiseItem.Raise();
            //set chest open
            isOpen = true;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && isOpen)
        {
            playerInRange = false;
        }
    }
}
