using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool nametagSolved = false;
    public bool continentSolved = false;
    public bool puzzleSolved = false;

    public GameObject nametag;
    public GameObject continent;
    public Light[] lights;

    public Color32 standardColor;
    public Color32 solvedColor;

    private void SolvePuzzle()
    {
        puzzleSolved = true;

        foreach (Light light in lights)
        {
            light.color = solvedColor;
        }
    }

    private void UnsolvePuzzle()
    {
        puzzleSolved = false;

        foreach (Light light in lights)
        {
            light.color = standardColor;
        }
    }

    public void OnCollisionEnter(Collision collision)
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

    private void OnCollisionExit(Collision collision)
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
