using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player Instance;

    public int health, mana, type, str, spd, arm, exp, pulse;
    public Text HealthText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealth(int value)
    {
        health += value;
        HealthText.text = $"HP: {health}";
    }

    public void UpdateArm(int value)
    {
        arm += value;
    }

    public void UpdateMana(int value)
    {
        mana += value;
    }

    public void UpdateSpd(int value)
    {
        spd += value;
    }

    public void UpdateStr(int value)
    {
        str += value;
    }
    
    public void UpdateExp(int value)
    {
        exp += value;
    }

    public void UpdatePulse(int value)
    {
        pulse += value;
    }
}
