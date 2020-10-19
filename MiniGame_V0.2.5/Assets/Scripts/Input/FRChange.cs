using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;
using MiniGame.Mechanics;
using UnityEngine.UI;

public class FRChange : MonoBehaviour
{
    public GameObject placeholder;
    public GameObject text;
    public GameObject eventsystem;
    private string input;

    void Start()
    {
        placeholder.GetComponent<Text>().text = eventsystem.GetComponent<Setting>().targetFrameRate.ToString();
    }

    public void End_Value()
    {
        input = text.GetComponent<Text>().text;
        placeholder.GetComponent<Text>().text = input;
        eventsystem.GetComponent<Setting>().targetFrameRate = int.Parse(input);
    }
}
