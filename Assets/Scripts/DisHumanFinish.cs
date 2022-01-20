using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisHumanFinish : MonoBehaviour
{
    [SerializeField]
    GameObject particleSystem;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {


        //Debug.Log("nga");
        if (other.gameObject.tag == "Player")
        {

            GameObject o = Instantiate(particleSystem, transform.position, transform.rotation) as GameObject;
            Destroy(o, 0.5f);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
