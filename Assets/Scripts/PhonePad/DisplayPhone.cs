﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPhone : MonoBehaviour {

    public GameObject DisplayCanvas;
    public GameObject DisplayParticles;
    public GameObject PhoneSound;
    public GameObject SelectableButton;
    public AudioClip FoundSound;
   
    private bool clickable;

	// Use this for initialization
	void Start () {
        clickable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(clickable)
        {
            if (Input.GetButtonDown("Fire1") && !Move.instance.moveLocked)
            {
                if(PhoneSound != null)
                {
                    if(FoundSound != null)
                    {
                        AudioSource audio = PhoneSound.GetComponent<AudioSource>();
                        audio.clip = FoundSound;
                        audio.loop = false;
                        audio.Play();
                    }
                    else
                    {
                        PhoneSound.SetActive(false);
                    }
                }
                Debug.Log("Test1");
                if (DisplayCanvas != null)
                {
                    Debug.Log("Test2");
                    DisplayCanvas.SetActive(true);
                    if(SelectableButton != null)
                    {
                        SelectableButton.GetComponent<Button>().Select();
                    }
                }
                Move.instance.moveLocked = true;
                
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        clickable = true;
        if(DisplayParticles != null)
        {
            DisplayParticles.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clickable = false;
        if(DisplayParticles != null)
        {
            DisplayParticles.SetActive(false);
        }
    }
}
