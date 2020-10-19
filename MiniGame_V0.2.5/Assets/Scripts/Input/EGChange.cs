﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;
using MiniGame.Mechanics;
using UnityEngine.UI;

public class EGChange : MonoBehaviour
{
    public GameObject placeholder;
    public GameObject text;
    public GameObject player;
    private string input;

    void Start()
    {
        placeholder.GetComponent<Text>().text = player.GetComponent<PlayerController>().playerExtraGravity.ToString();
    }

    public void End_Value()
    {
        input = text.GetComponent<Text>().text;
        placeholder.GetComponent<Text>().text = input;
        player.GetComponent<PlayerController>().playerExtraGravity = int.Parse(input);
    }
}
