using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    Collider colliderHumanFinal;
    [SerializeField]
    Rigidbody rigidbodyPlayer;
    [SerializeField]
    GameObject knockHand;

    GameObject box;
    GameObject box1;
    GameObject humanFinal;
    float speedHumanFinal = 10f;
    float jumpHumanFinal = 2.5f;
    float jumpPlayer = 1f;
    float x = 1.5f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        humanFinal = GameObject.FindGameObjectWithTag("human final");
        box = GameObject.FindGameObjectWithTag("box");
        box1 = GameObject.FindGameObjectWithTag("box1");
    }
    public bool ktr = true;

    bool checkDie = true;
    bool checkJump = false;
    bool checkfly = false;
    bool checkBox = false;
    public List<MoveToPlayer> MoveToPlayerList = new List<MoveToPlayer>();
    // Update is called once per frame
    void Update()
    {
        if (humanFinal.transform.position.z - transform.position.z > 4 && checkDie)
        {
            if (Input.GetMouseButton(0))
            {

                if (Input.GetAxis("Mouse X") < 0)
                {
                    Vector3 move = transform.right * -x * Time.deltaTime;
                    transform.Translate(move);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    Vector3 move = transform.right * x * Time.deltaTime;
                    transform.Translate(move);
                }
            }
            if (checkBox == false)
            {
                velocity = transform.forward * speed * Time.deltaTime;
                transform.Translate(velocity);
            }
        }
        else if (ktr && checkDie)
        {
            transform.position = Vector3.Lerp(
            transform.position,
            humanFinal.transform.position,
            2 * Time.deltaTime);
        }
        if (checkBox)
        {
            gameObject.tag = "hide";
            box.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
            Destroy(box1, 2f);
        }
        else if (checkBox == false)
        {
            gameObject.tag = "Player";
        }
        if (ktr == false)
        {
            colliderHumanFinal.isTrigger = false;
            humanFinal.transform.Translate(Vector3.up * jumpHumanFinal * Time.deltaTime);
            humanFinal.transform.Translate(Vector3.forward * speedHumanFinal * Time.deltaTime);

            if (humanFinal.transform.position.y > 2)
            {
                jumpHumanFinal *= -1;
            }
            if (humanFinal.transform.position.z > 110)
            {
                speedHumanFinal *= 0;
            }
        }
        if (checkJump)
        {
            rigidbodyPlayer.useGravity = false;

            transform.Translate(Vector3.up * jumpPlayer * Time.deltaTime);
            if (transform.position.y > 3)
            {
                jumpPlayer *= -1f;
                checkfly = true;
            }
            if (transform.position.y < 1 && checkfly)
            {
                rigidbodyPlayer.useGravity = true;
                jumpPlayer = 0;
            }
        }
        if (speed > 2)
        {
            speed -= 0.01f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            checkBox = true;
            foreach (var m in MoveToPlayerList)
            {
                m.ktr = false;
            }
            foreach (var m in MoveToPlayerList)
            {
                m.ktrbox = true;
            }
        }
        if (other.gameObject.tag == "human final")
        {
            ktr = false;
        }

        if (other.gameObject.tag == "up speed")
        {
            speed = 6;
        }
        if (other.gameObject.tag == "jump")
        {

            checkJump = true;
        }
        if (other.gameObject.tag == "check knock hand")
        {
            knockHand.transform.Translate(Vector3.up * 3);
            Destroy(knockHand, 0.3f);
        }
        if (other.gameObject.tag == "check final finish ")
        {
            checkDie = false;
        }
        if (other.gameObject.tag == "human_finish")
        {
            speedHumanFinal += 0.1f;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "box")
        {
            checkBox = false;
            foreach (var m in MoveToPlayerList)
            {
                m.ktrbox = false;
            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cog")
        {
            checkDie = false;
        }

    }
}
