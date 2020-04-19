using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private bool nametagSolved = false;
    private bool continentSolved = false;

    [SerializeField] private GameObject nametag;
    [SerializeField] private GameObject continent;
    [SerializeField] private Light[] lights;

    [SerializeField] private Color32 standardColor;
    [SerializeField] private Color32 solvedColor;

    private string socket1 = "socket_europe";
    private string socket2 = "socket_southamerica";
    private string socket3 = "socket_africa";
    private string socket4 = "socket_antarctica";
    private string socket5 = "socket_australia";
    private string socket6 = "socket_northamerica";
    private string socket7 = "socket_asia";

    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip solveSound;

    private void SwitchBools(bool boolean)
    {
        if (gameObject.name == socket1)
        {
            GameManager.puzzle1Solved = boolean;
        }
        else if (gameObject.name == socket2)
        {
            GameManager.puzzle2Solved = boolean;
        }
        else if (gameObject.name == socket3)
        {
            GameManager.puzzle3Solved = boolean;
        }
        else if (gameObject.name == socket4)
        {
            GameManager.puzzle4Solved = boolean;
        }
        else if (gameObject.name == socket5)
        {
            GameManager.puzzle5Solved = boolean;
        }
        else if (gameObject.name == socket6)
        {
            GameManager.puzzle6Solved = boolean;
        }
        else if (gameObject.name == socket7)
        {
            GameManager.puzzle7Solved = boolean;
        }

    }
    private void SolvePuzzle()
    {
        SwitchBools(true);

        foreach (Light light in lights)
        {
            light.color = solvedColor;
        }

        audioSrc.PlayOneShot(solveSound, 0.5f);
    }

    private void UnsolvePuzzle()
    {
        SwitchBools(false);

        foreach (Light light in lights)
        {
            light.color = standardColor;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
       if(GameManager.gameWon == false)
        {
            if (collision.gameObject.name == nametag.name)
            {
                nametagSolved = true;
                Debug.Log("nametag true");

                if (continentSolved == true)
                {
                    SolvePuzzle();
                }
            }

            if (collision.gameObject.name == continent.name)
            {
                continentSolved = true;
                Debug.Log("continent true");

                if (nametagSolved == true)
                {
                    SolvePuzzle();
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (GameManager.gameWon == false)
        {
            if (collision.gameObject.name == nametag.name)
            {
                nametagSolved = false;
                Debug.Log("nametag false");

                UnsolvePuzzle();
            }

            if (collision.gameObject.name == continent.name)
            {
                continentSolved = false;
                Debug.Log("continent false");

                UnsolvePuzzle();
            }
        }
    }
}
