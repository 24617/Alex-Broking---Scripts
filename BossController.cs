using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private PointTowards lookAt;

    Vector3 currentRotation;
    private Rigidbody rb;

    private GameObject pointTowards;

    private Vector3 target;

    private bool goDown = false;

    void Start () {
        pointTowards = GameObject.Find("BossPivot");
        //lookAt = i.GetComponent<PointTowards>();
        rb = GetComponent<Rigidbody>();
    }
	

	void Update () {
        //Make Boss Fall Down When Hit 2 Times
        currentRotation = transform.rotation.eulerAngles;
        if (Input.GetKeyDown(KeyCode.P))
        {
            goDown = true;
            target = new Vector3(transform.position.x, 3.5f , transform.position.z);
            pointTowards.GetComponent<PointTowards>().isActive = false;
            transform.eulerAngles = new Vector3(0, currentRotation.y, 0);
            openMouth();
        }
        // --------------------------------------------------
        if (goDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 10 *Time.deltaTime);
        }


    }

    //To Throw bomb into
    void openMouth()
    {

    }
}
