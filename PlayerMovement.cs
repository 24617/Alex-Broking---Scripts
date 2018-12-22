using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    private PlayerTechnique dashing;
    private float moveSpeed = 3f;
    private float cameraRotation;
    public GameObject cameraPosition;
    private bool leftMovement = true; private bool rightMovement = true; private bool forwardMovement = true; private bool backwardMovement = true;
    private bool leftCorner = true; private bool rightCorner = true;
    private bool cornerMovement = false;
    public bool lockedMovement = false;
    public bool GotBomb = false;
    public bool canMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        dashing = gameObject.GetComponent<PlayerTechnique>();

    }
    void Update()
    {
        cameraRotation = cameraPosition.transform.rotation.eulerAngles.y;

        //Can Player Move?
        if (canMove == true)
        {
            // Going Forward
            if (forwardMovement == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    backwardMovement = false; leftMovement = false; rightMovement = false;

                    if (lockedMovement == false && Input.GetKey(KeyCode.W) && (cornerMovement == false) && (dashing.isDashing == false))
                    {
                        anim.SetInteger("State", 2);
                        if (GotBomb == false)
                        {
                            anim.SetFloat("Blend", 1);
                        }
                        if (GotBomb == true)
                        {
                            anim.SetFloat("Blend", 2);
                        }
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                    if (lockedMovement == true && Input.GetKey(KeyCode.W) && (cornerMovement == false))
                    {
                        anim.SetInteger("State", 11);
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Backwards
            if (backwardMovement == true)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    forwardMovement = false; leftMovement = false; rightMovement = false;

                    if (lockedMovement == false && Input.GetKey(KeyCode.S) && (cornerMovement == false) && (dashing.isDashing == false))
                    {
                        anim.SetInteger("State", 2);
                        if (GotBomb == false)
                        {
                            anim.SetFloat("Blend", 1);
                        }
                        if (GotBomb == true)
                        {
                            anim.SetFloat("Blend", 2);
                        }
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation - 180, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                    }
                    if (lockedMovement == true && Input.GetKey(KeyCode.S) && (cornerMovement == false))
                    {
                        anim.SetInteger("State", 6);
                        transform.position += transform.forward * -1 * (moveSpeed -1.5f) * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Left
            if (leftMovement == true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    forwardMovement = false; backwardMovement = false; rightMovement = false;

                    if (lockedMovement == false && Input.GetKey(KeyCode.A) && (cornerMovement == false) && (dashing.isDashing == false))
                    {
                        anim.SetInteger("State", 2);
                        if (GotBomb == false)
                        {
                            anim.SetFloat("Blend", 1);
                        }
                        if (GotBomb == true)
                        {
                            anim.SetFloat("Blend", 2);
                        }
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation - 90, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                    }
                    if (lockedMovement == true && Input.GetKey(KeyCode.A) && (cornerMovement == false))
                    {
                        anim.SetInteger("State", 10);
                        transform.position += transform.right * -1 * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }

                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }
            // Going Right
            if (rightMovement == true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    forwardMovement = false; backwardMovement = false; leftMovement = false;

                    if (lockedMovement == false && Input.GetKey(KeyCode.D) && (cornerMovement == false) && (dashing.isDashing == false))
                    {
                        anim.SetInteger("State", 2);
                        if (GotBomb == false)
                        {
                            anim.SetFloat("Blend", 1);
                        }
                        if (GotBomb == true)
                        {
                            anim.SetFloat("Blend", 2);
                        }
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation + 90, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);

                    }
                    if (lockedMovement == true && Input.GetKey(KeyCode.D) && (cornerMovement == false))
                    {
                        anim.SetInteger("State", 9);
                        transform.position += transform.right * moveSpeed * Time.deltaTime;
                        Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    }
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    forwardMovement = true; backwardMovement = true; leftMovement = true; rightMovement = true;
                }
            }

            // Going Right Up / Right Down
            if (rightCorner == true)
            {
                if (Input.GetKey(KeyCode.D) && (dashing.isDashing == false))
                {
                    leftCorner = false;
                    // Right Up
                    if (Input.GetKey(KeyCode.W))
                    {
                        cornerMovement = true;
                        if (lockedMovement == false)
                        {
                            anim.SetInteger("State", 2);
                            if (GotBomb == false)
                            {
                                anim.SetFloat("Blend", 1);
                            }
                            if (GotBomb == true)
                            {
                                anim.SetFloat("Blend", 2);
                            }
                            transform.position += transform.forward * moveSpeed * Time.deltaTime;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation + 45, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                        if (lockedMovement == true)
                        {
                            anim.SetInteger("State", 9);
                            transform.position += ((transform.right * moveSpeed * Time.deltaTime) + (transform.forward * moveSpeed * Time.deltaTime)) / 2;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                    }
                    // Right Down
                    if (Input.GetKey(KeyCode.S))
                    {
                        cornerMovement = true;
                        if (lockedMovement == false)
                        {
                            anim.SetInteger("State", 2);
                            if (GotBomb == false)
                            {
                                anim.SetFloat("Blend", 1);
                            }
                            if (GotBomb == true)
                            {
                                anim.SetFloat("Blend", 2);
                            }
                            transform.position += transform.forward * moveSpeed * Time.deltaTime;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation + 135, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                        if (lockedMovement == true)
                        {
                            anim.SetInteger("State", 9);
                            transform.position += ((transform.right * moveSpeed * Time.deltaTime) + (transform.forward * moveSpeed * Time.deltaTime * -1)) / 2;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                    }
                }
                if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
                {
                    cornerMovement = false;
                    leftCorner = true;
                }
            }

            // Going Left Up / Left Down
            if (leftCorner == true)
            {
                if (Input.GetKey(KeyCode.A) && (dashing.isDashing == false))
                {
                    rightCorner = false;
                    // Left Up
                    if (Input.GetKey(KeyCode.W))
                    {
                        cornerMovement = true;
                        if (lockedMovement == false)
                        {
                            anim.SetInteger("State", 2);
                            if (GotBomb == false)
                            {
                                anim.SetFloat("Blend", 1);
                            }
                            if (GotBomb == true)
                            {
                                anim.SetFloat("Blend", 2);
                            }
                            transform.position += transform.forward * moveSpeed * Time.deltaTime;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation - 45, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                        if (lockedMovement == true)
                        {
                            anim.SetInteger("State", 10);
                            transform.position += ((transform.right * moveSpeed * Time.deltaTime * -1) + (transform.forward * moveSpeed * Time.deltaTime)) / 2;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                    }
                    // Right Up
                    if (Input.GetKey(KeyCode.S))
                    {
                        cornerMovement = true;
                        if (lockedMovement == false)
                        {
                            anim.SetInteger("State", 2);
                            if (GotBomb == false)
                            {
                                anim.SetFloat("Blend", 1);
                            }
                            if (GotBomb == true)
                            {
                                anim.SetFloat("Blend", 2);
                            }
                            transform.position += transform.forward * moveSpeed * Time.deltaTime;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation - 135, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                        if (lockedMovement == true)
                        {
                            anim.SetInteger("State", 10);
                            transform.position += ((transform.right * moveSpeed * Time.deltaTime * -1) + (transform.forward * moveSpeed * Time.deltaTime * -1)) / 2;
                            Quaternion q = Quaternion.AngleAxis(cameraRotation, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                        }
                    }
                }
                if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
                {
                    cornerMovement = false;
                    rightCorner = true;
                }
            }

            // Idle 
            if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S)) && (!Input.GetKey(KeyCode.D)))
            {
                anim.SetInteger("State", 1);
                if (GotBomb == false)
                {
                    anim.SetFloat("Blend", 1);
                }
                if (GotBomb == true)
                {
                    anim.SetFloat("Blend", 2);
                }
            }
            
        }

        // Set Locked Movement
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (lockedMovement == false)
            {
                lockedMovement = true;
                
            } else
            {
                lockedMovement = false;
            }
        }
        

    }
}

    
 
