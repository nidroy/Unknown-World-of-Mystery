using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public int statueNumber;
    public GameObject button;
    public SecondLocation secondLocation;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(statueNumber == 2 && !secondLocation.isChoosingShape || statueNumber == 1 && !secondLocation.isEquations)
                button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }


}
