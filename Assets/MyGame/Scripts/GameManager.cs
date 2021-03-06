﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool puzzle1Solved = false;
    public static bool puzzle2Solved = false;
    public static bool puzzle3Solved = false;
    public static bool puzzle7Solved = false;
    public static bool puzzle4Solved = false;
    public static bool puzzle5Solved = false;
    public static bool puzzle6Solved = false;
    public static bool gameWon = false;

    private bool callOnce = false;

    [SerializeField] private GameObject winText;

    [SerializeField] private Light roomLight;
    [SerializeField] private Color32 winColor1;
    [SerializeField] private Color32 winColor2;
    private float duration = 2.0f;

    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip winSound;

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;

        if (puzzle1Solved == true && puzzle2Solved == true && puzzle3Solved == true && puzzle4Solved == true && puzzle5Solved == true && puzzle6Solved == true && puzzle7Solved == true && callOnce == false)
        {
            gameWon = true;
            winText.SetActive(true);
            audioSrc.PlayOneShot(winSound, 0.75f);
            callOnce = true;
        }

        if (gameWon == true)
        {
            
            roomLight.color = Color.Lerp(winColor1, winColor2, t);
        }
    }
}
