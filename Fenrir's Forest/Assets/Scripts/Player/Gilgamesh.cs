using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerState
{
    idle,
    attack,
    dead,
}
public class Gilgamesh : Stats
{
  
    // Start is called before the first frame update
     void Start()
    {
        unitName = "Gilgamesh";
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
