using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCog : MonoBehaviour
{
    [SerializeField]
    float speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "check right")
        {
            speed = Mathf.Abs(speed);
        }
        if (other.gameObject.tag == "check left")
        {
            speed *= -1;
        }
    }
}
