using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour {

    public bool isFlying = false;
    public bool intoMouth = false;
    private float flySpeed = 10f;
    private float rollSpeed = 100f;
    private float counter = 0;
    private float maxTime = 3;
    private float bossDistance = 2f;
    private float maxExplodeTime = 3;
    private float explodeTimer = 0;
    private Rigidbody rb;
    private GameObject bossCollider;
    public GameObject explosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Update () {
		if (isFlying == true)
        {
            transform.position += transform.forward * flySpeed * Time.deltaTime;
            rb.AddForce(transform.forward * flySpeed * Time.deltaTime);

        }

        if (intoMouth == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(bossCollider.transform.position.x, this.transform.position.y, bossCollider.transform.position.z), 1 * Time.deltaTime);
            explodeTimer += Time.deltaTime;
            if (explodeTimer >= maxExplodeTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.name == "Boss")
        {
            isFlying = false;
            bossCollider = collision.gameObject;
            gameObject.transform.rotation = Quaternion.identity;
            IntoMouth();
            Physics.IgnoreCollision(bossCollider.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (collision.collider.tag == "Environment")
        {
            rb.AddForce(transform.forward * rollSpeed * Time.deltaTime);
            Physics.IgnoreLayerCollision(11,10, false);
            isFlying = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Environment")
        {
            counter += Time.deltaTime;
            if (counter >= maxTime)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        
    }

    void IntoMouth()
    {
        isFlying = false;
        intoMouth = true;
        Vector3 newObjectLocation = (bossCollider.transform.forward * -1 * bossDistance) + bossCollider.transform.position;
        gameObject.transform.position = new Vector3(newObjectLocation.x, newObjectLocation.y - 2.1f, newObjectLocation.z);
        rb.useGravity = true;
        rb.constraints =  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }


}
