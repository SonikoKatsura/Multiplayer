using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed, jforce;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.position = transform.position + (transform.forward * -5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            anim.SetFloat("velX", Mathf.Abs(rb.velocity.x));
            anim.SetFloat("velY", rb.velocity.y);

            rb.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) + (transform.up * rb.velocity.y);
            if (rb.velocity.x > 0.1f && GetComponent<SpriteRenderer>().flipX)
                GetComponent<PhotonView>().RPC("RotateSprite", RpcTarget.All, false);
            else if (rb.velocity.x < -0.1f && !GetComponent<SpriteRenderer>().flipX)
                GetComponent<PhotonView>().RPC("RotateSprite", RpcTarget.All, true);
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.up * jforce);
            }
            anim.SetFloat("velX", Mathf.Abs(rb.velocity.x));
            anim.SetFloat("velY", rb.velocity.y);
        }
    }

    [PunRPC]
    public void RotateSprite(bool rotate)
    { 
        GetComponent<SpriteRenderer>().flipX = rotate;
    }
}
