﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereBaita : MonoBehaviour
{ 
    JeepBaita jeep;
    Camera[] telecamere;
    Camera cameranow = null;
    public AudioClip telefonata;
    // Start is called before the first frame update
    void Start()
    {
        jeep = GameObject.Find("Jeep").GetComponent<JeepBaita>();
        telecamere = GetComponentsInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jeep.GetCamera() >= 0)
        {
            if (cameranow != telecamere[jeep.GetCamera()])
            {
                telecamere[jeep.GetCamera()].enabled = true;
                if (cameranow != null)
                    cameranow.enabled = false;
                cameranow = telecamere[jeep.GetCamera()];
            }
        }
    }

    public void DisableCamera(int numero)
    {
        telecamere[numero].enabled = false;
    }

    public void EnablePlayerCamera()
    {
        foreach(Camera figlio in telecamere)
        {
            figlio.enabled = false;
        }
        GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
    }

    public void TriggerDialogue()
    {
        //if(!GameObject.Find("Player").GetComponent<AudioSource>().isPlaying)
        //GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(telefonata);
        if(GetComponent<AudioSource>().isPlaying)
        GetComponent<AudioSource>().PlayOneShot(telefonata);
        //do something
    }
}
