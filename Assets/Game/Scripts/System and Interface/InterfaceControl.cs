using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceControl : MonoBehaviour
{
    private int zombie_death_amount;
    public TextMeshProUGUI TextDeathZombieAmount;
    public void UpdateDeathZombies()
    {
        zombie_death_amount++;
        TextDeathZombieAmount.text = string.Format("x {0}", zombie_death_amount);
    }

}
