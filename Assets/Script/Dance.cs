using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{

    public GameObject danceSet;
    public float timer =10f;
    public bool IsDance = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("J=dance");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            IsDance = !IsDance;
            if (IsDance == true)
            {
            	Debug.Log("Dance active");
                danceSet.SetActive(true);
                danceSet.transform.RotateAround(Vector3.zero, Vector3.right, timer * Time.deltaTime);
            }
            else
            {
            	Debug.Log("Dance inactive");
                danceSet.SetActive(false);
            }
        }
    }
}
