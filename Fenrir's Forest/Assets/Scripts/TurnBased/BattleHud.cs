using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public virtual void SetHud(Stats unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.health.initialValue;
        hpSlider.value = unit.health.runtimeValue;
    }

    public void SetHP(float hp)
    {
        hpSlider.value = hp;
    }


}
