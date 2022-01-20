using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject particleSystem;
    [SerializeField]
    Rigidbody rig;
    [SerializeField]
    Collider collider;
    [SerializeField]
    float speedHuman = 3f;
    float distance = 3f;
    float jump = 0f;
    float flyrun = 0f;


    GameObject player;
    GameObject finishLine;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        finishLine = GameObject.FindGameObjectWithTag("finish line");
    }
    bool run = false;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ktr + "move");
        if (ktr == true)
        {
            if (collider.gameObject.tag == "human special" && run && Mathf.Abs(player.transform.position.z - transform.position.z) >= distance)
            {
                collider.isTrigger = false;
                transform.position = Vector3.Lerp(
                    transform.position,
                    player.transform.position,
                    speedHuman * Time.deltaTime);
                rig.useGravity = true;
                if (distance > 0)
                {
                    distance -= 0.01f;
                }
                if (distance <= 0.1)
                {
                    jump = -4.5f;
                    flyrun = 2.5f;
                    //speedHuman = 2;

                    transform.Translate(Vector3.down * jump * Time.deltaTime);
                    transform.Translate(Vector3.forward * flyrun * Time.deltaTime);
                    //transform.position = Vector3.forward * 2 * Time.deltaTime;
                    if (Mathf.Abs(player.transform.position.z - transform.position.z) > 0.5)
                    {
                        speedHuman += 0.003f;
                    }
                }
            }
            else
            if (collider.gameObject.tag == "human normal")
            {
                if (player.transform.position.z - transform.position.z >= Random.Range(2f, 4f) && run)
                {
                    collider.isTrigger = false;
                    transform.position = Vector3.Lerp(
                        transform.position,
                        player.transform.position,
                        5 * Time.deltaTime);
                    rig.useGravity = true;

                }
            }
            if (transform.position.z - player.transform.position.z > 0f && transform.position.z - player.transform.position.z < 3f)
            {
                //speedHuman = 0f;
                jump = 0;
                flyrun = 0;
                distance = 3;
            }

            if (Mathf.Abs(player.transform.position.z - transform.position.z) >= 6)
            {
                run = true;
            }
        }

        if (ktrbox && transform.position.z - player.transform.position.z < 4)
        {
            Vector3 moveHuman = transform.forward * 3 * Time.deltaTime;

            transform.Translate(moveHuman);


        }
        else if (ktr == false)
        {
            collider.isTrigger = true;
            rig.useGravity = false;
        }

        if (finishLine.transform.position.z - player.transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {


        //Debug.Log("nga");
        if (other.gameObject.tag == "Player")
        {

            GameObject o = Instantiate(particleSystem, transform.position, transform.rotation) as GameObject;
            Destroy(o, 0.5f);
        }


    }
    public bool ktr = false;
    public bool ktrbox = false;
    bool ktrHuman = false;
    private void OnTriggerExit(Collider other)
    {

        //Debug.Log("duoi");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerControl>().MoveToPlayerList.Add(this);
            ktr = true;
        }

    }
    /*private void OnCollisionExit(Collision collision)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<playerControl>().MoveToPlayerList.Add(this);
            ktr = true;
            Debug.Log("davao");
        }
    }*/
}
