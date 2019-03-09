using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rag : MonoBehaviour {

    public GameObject ragtest;
    public GameObject norag;
    public Pnj pnj;
    public Animator anim;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Car")
        {
            ragtest.SetActive(true);
            norag.SetActive(false);
            pnj.Stop();
            anim.enabled = false;
        }
    }
}
