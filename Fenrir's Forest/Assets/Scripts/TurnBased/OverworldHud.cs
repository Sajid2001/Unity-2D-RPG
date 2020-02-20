using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldHud : MonoBehaviour
{
    public Slider hpSlider;
    public PlayerMovement player;

    void Update()
    {
        SetOverworldHud(player);
    }

    public void SetOverworldHud(PlayerMovement player)
    {
        hpSlider.maxValue = player.currentHealth.initialValue;
        hpSlider.value = player.currentHealth.runtimeValue;
    }
}
