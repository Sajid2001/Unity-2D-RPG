using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserHud : BattleHud
{
    public Text healsLeftText;
    public GameObject actionBox;

    public override void SetHud(Stats unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.health.initialValue;
        hpSlider.value = unit.health.runtimeValue;
        healsLeftText.text = "Heals left: " + unit.totalHeals.runtimeValue;

    }

    public void UpdateHealsLeft(Stats unit)
    {
        healsLeftText.text = "Heals left: " + unit.totalHeals.runtimeValue;
    }

}
