﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventWarning : MonoBehaviour {

	public GameObject Element_01;
	public GameObject Element_02;
	public GameObject Element_03;
	public GameObject Element_04;
	public GameObject Element_05;
	public GameObject Element_06;

	// Use this for initialization
	void Start ()
	{
		Element_02.SetActive(false);
		Element_03.SetActive(false);
		Element_04.SetActive(false);
		Element_05.SetActive(false);
		Element_06.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Element_01.GetComponent<TypingText>().finish)
		{
			Element_02.SetActive(true);
		}
		if (Element_02.GetComponent<TypingText>().finish)
		{
			Element_03.SetActive(true);
			Element_04.SetActive(true);
			Element_05.SetActive(true);
		}
		if (Element_05.GetComponent<TypingText>().finish)
		{
			Element_06.SetActive(true);
		}

		if (Input.GetKeyDown("return"))
		{
			if (Element_06.activeSelf)
			{
				SceneManager.LoadScene("gameIntro");
			}
		}
	}
}
