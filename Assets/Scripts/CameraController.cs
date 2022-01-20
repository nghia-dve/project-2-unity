using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : HCMonobehavior
{
    public static CameraController Instance;

    public float TransitionSpeed;
    GameObject player;
    GameObject huhumanFinal;
    public Transform TargetFollow;
    public Vector3 Offset;
    [SerializeField] playerControl playerControl;
    private void Start()
    {
        /*player = GameObject.FindGameObjectWithTag("Player");
        huhumanFinal = GameObject.FindGameObjectWithTag("human final");*/
        //playerControl = new playerControl();
        //Debug.Log(playerControl.ktr);
    }
    private void Update()
    {
        //playerControl = new playerControl();
        //Debug.Log(playerControl.getKtra());
        if (playerControl.ktr == false)
        {
            Awake();
        }
    }
    private void Awake()
    {
        if (playerControl.ktr)
        {
            TargetFollow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (playerControl.ktr == false)
        {
            TargetFollow = GameObject.FindGameObjectWithTag("human final").transform;
        }

        Instance = this;
        Offset = Transform.position - TargetFollow.position;
        originOffset = Offset;
    }

    private Vector3 originOffset;

    public void ResetOffset()
    {
        Offset = originOffset;
    }

    private void LateUpdate()
    {
        if (TargetFollow == null)
            return;

        if (playerControl.ktr)
        {
            Transform.position = Vector3.Lerp(Transform.position,
            TargetFollow.transform.position + Offset, Time.deltaTime * TransitionSpeed);
        }
        else if (playerControl.ktr == false)
        {
            Transform.position = Vector3.Lerp(Transform.position,
            TargetFollow.transform.position + Offset, Time.deltaTime * TransitionSpeed * 10);
        }
    }
}
