﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - transform.position.z > 11)
        {
            Destroy(gameObject);
        }
    }
}
