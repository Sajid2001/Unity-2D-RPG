using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public GameObject destroyObject;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.runtimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            ActivateSwitch();
        }
    }
    public void ActivateSwitch()
    {
        active = true;
        storedValue.runtimeValue = active;
        mySprite.sprite = activeSprite;
        Destroy(destroyObject);
    }

    

}
