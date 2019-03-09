using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;

public class TestCar : MonoBehaviour {

    public GameObject player;
	public GameObject car;
    public GameObject carCamera;
    public GameObject pop;

    private bool canEnter;
    private bool isInside;
    private AudioSource[] carAudio;


    private float timeLeft;
    private bool canLeave = false;

    PlayerStats stat;

    private void Start()
    {
        car = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        stat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        timeLeft = 1f;
    }

    void Update()
    {

        // Si on entre dans la voiture
        if (canEnter && Input.GetKeyDown("e"))
        {
            isInside = true;

            player.transform.parent = car.transform;
            player.SetActive(false);

            carCamera.SetActive(true);

            Debug.Log("dans la voiture");
            car.GetComponent<CarController>().enabled = true;
            car.GetComponent<CarUserControl>().enabled = true;
            car.GetComponent<CarAudio>().enabled = true;

            timeLeft = 1f;
            // On récupére et on active toutes les audio sources
            carAudio = car.GetComponents<AudioSource>();

            foreach (AudioSource single in carAudio)
            {
                single.enabled = true;
            }


        }

        // Si on sort de la voiture
        if (isInside && canLeave && Input.GetKeyDown("e"))
        {
            player.transform.parent = null;
            player.SetActive(true);

            carCamera.SetActive(false);

            Debug.Log("sorti");
            car.GetComponent<CarController>().enabled = false;
            car.GetComponent<CarUserControl>().enabled = false;
            car.GetComponent<CarAudio>().enabled = false;


            isInside = false;
            canLeave = false;

            timeLeft = 1f;

            foreach (AudioSource single in carAudio)
            {
                single.enabled = false;
            }

        }

        // DÃ©lais d'attente entre l'entrÃ©e et la sortie de la voiture
        // (Permet aussi d'utiliser la mÃªme touche pour entrer et sortir)
        if (timeLeft > 0 && isInside)
        {
            timeLeft -= Time.deltaTime;
            canLeave = false;
        }
        else if (timeLeft <= 0 && isInside)
        {
            canLeave = true;
        }
    }

    // Detection du joueur dans le cube d'entrÃ©e
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            canEnter = true;
            pop.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && canEnter == true)
        {
            pop.SetActive(false);
            stat.currentLib += 2;

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            canEnter = false;
            pop.SetActive(false);

        }
    }

}
