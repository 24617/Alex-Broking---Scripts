using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHolder : MonoBehaviour {

    Animator anim;
    private BombExplode isGettingTrown;
    private PlayerMovement gotBomb;
    private GameObject bomb;
    public bool holdingBomb = false;
    private float distance = 0.01f;
    private float trowTimer = 0;
    private float maxtrowTimer = 0.3f;
    private bool canBomb = true;
    private float canBombTimer = 0;
    private float maxBombTimer = 3;
    private bool playerCanMove = true;
    
     

    private void Start()
    {
        anim = GetComponent<Animator>();
        gotBomb = GetComponent<PlayerMovement>();
    }

    void Update () {
        //When the boss is Down you can get a bomb
        if (holdingBomb == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetInteger("State", 4);
                isGettingTrown.isFlying = true;
                holdingBomb = false;
                gotBomb.GotBomb = false;
                playerCanMove = false;
                canBomb = false;
            }
            Vector3 newObjectLocation = (this.transform.forward * distance) + this.transform.position;
            bomb.transform.position = new Vector3(newObjectLocation.x, newObjectLocation.y + 1.1f, newObjectLocation.z);
            bomb.transform.rotation = Quaternion.Slerp(transform.rotation, this.transform.rotation, Time.deltaTime * 360);
        } 

        if (holdingBomb == false && canBomb == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                gotBomb.GotBomb = true;
                bomb = Instantiate(Resources.Load<GameObject>("Bomb"));
                isGettingTrown = bomb.gameObject.GetComponent<BombExplode>();
                bomb.name = "Bomb";
                holdingBomb = true;
            }
        }

        if (playerCanMove == false)
        {
            trowTimer += Time.deltaTime;
            if (trowTimer >= maxtrowTimer)
            {
                anim.SetInteger("State", 1);
                trowTimer = 0;
                gotBomb.canMove = true;
            }
        }

        if (canBomb == false)
        {
            canBombTimer += Time.deltaTime;
            if (canBombTimer >= maxBombTimer)
            {
                canBombTimer = 0;
                canBomb = true;
            }
        }


	}
}
