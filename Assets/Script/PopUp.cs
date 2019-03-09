using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

	public GameObject pop;
     // Detection du joueur dans le cube d'entrÃ©e
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            
            pop.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            pop.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
           
            pop.SetActive(false);

        }
    }
}
