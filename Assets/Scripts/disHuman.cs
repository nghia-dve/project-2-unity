﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disHuman : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cog")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "knock hand")
        {
            Destroy(gameObject);
        }
    }
}
