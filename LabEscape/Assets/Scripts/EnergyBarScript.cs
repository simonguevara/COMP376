using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    //Code taken from : https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys
    //As well as health bar sprites


    public Slider slider;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        slider.value = player.GetComponent<PlayerSam>().energy;
    }
}
