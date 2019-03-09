using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
	 [SerializeField]
    private float Vitesse = 5f;
    private Vector3 velocity;

    BoatManager manag;


    // Start is called before the first frame update
    void Start()
    {
        manag = GetComponent<BoatManager>();
    }

    // Update is called once per frame
    void Update()
    {
         float _zMov = Input.GetAxisRaw("Vertical");

          Vector3 _movVertical = transform.forward * _zMov;
          Vector3 _velocity = _movVertical.normalized * Vitesse;

          manag.Move(_velocity);
    }

}
