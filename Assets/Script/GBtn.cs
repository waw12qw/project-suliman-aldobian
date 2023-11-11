using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GBtn : MonoBehaviour
{
    public GameObject[] activate;
    bool activated =false;
   private void OnCollisionEnter(Collision other){
    if (other.gameObject.CompareTag("Player") && activated ==false)
    {
        GetComponent<Animator>().Play("Activate");
        for (int i = 0; i < activate.Length; i++)
        {
            activate[i].GetComponent<Animator>().Play("Activate");
        }
    }
   }
}
