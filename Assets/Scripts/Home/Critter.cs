﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour
{
    public GameObject target;
    public float scaling = 1f;
    public float speed = 2f;
    public float limit = 0.01f;
    public GameObject critter;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered)
            return;
        StartCoroutine(RunToEnd());
    }

    private IEnumerator RunToEnd()
    {
        Vector3 direction = target.transform.position - critter.transform.position;
        direction.z = 0;
        float angle = Vector3.Angle(Vector3.up, direction.normalized);

        critter.transform.Rotate(Vector3.forward, angle);
        critter.GetComponent<Animator>().SetBool("scared", true);

        while ((target.transform.position - critter.transform.position).sqrMagnitude >= limit)
        {
            critter.transform.localScale *= scaling;
            critter.transform.Translate(direction * speed * Time.deltaTime, Space.World);
            yield return null;
        }
        critter.gameObject.SetActive(false);
        yield return null;
        this.enabled = false;
        yield return null;
    }
}
