using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject Finish;
    public GameObject InGame;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PLayer"))
        {
            Finish.SetActive(true);
            InGame.SetActive(true);
        }
    }
}
