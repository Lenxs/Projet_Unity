using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lum : MonoBehaviour {

    public GameObject lumiere;
    public GameObject msg;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            msg.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            
            lumiere.SetActive(true);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            msg.SetActive(false);
        }
    }

    

}
