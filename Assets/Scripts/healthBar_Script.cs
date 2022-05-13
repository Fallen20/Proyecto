using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthBar_Script : MonoBehaviour
{
    public Slider slider;
    public playerScript_Chapter3 player;
    
    public void Start()
	{
		slider.maxValue = player.maxHealth;
		slider.value = player.maxHealth;

	}

    public void SetHealth(int health){slider.value = player.health;}

	
}
