using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lab3 : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] Transform player;
    Animator anim;

    public float speed;
    public float agroDistance;
    public float attackDistance;
    float distToPlayer;
    bool canMove = true;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            if (canMove)
            {
                StartHunting();
            }
        }
        else
        {
            StopHunting();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(2);
    }

    void StartHunting()
    {
        if(distToPlayer < attackDistance)
        {
            canMove= false;
            anim.Play("atack");
            physic.velocity = Vector3.zero;
            Invoke("Restart", 0.8f);
        }
        if (canMove)
        {
            anim.Play("move");
            transform.LookAt(player);
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            if (player.position.x < transform.position.x)
            {
                physic.velocity = new Vector3(-speed, 0, physic.velocity.z); ;
            }
            else if (player.position.x > transform.position.x)
            {
                physic.velocity = new Vector3(speed, 0, physic.velocity.z); ;
            }

            if (player.position.z < transform.position.z)
            {
                physic.velocity = new Vector3(physic.velocity.x, 0, -speed);
            }
            else if (player.position.z > transform.position.z)
            {
                physic.velocity = new Vector3(physic.velocity.x, 0, speed);
            }
        }
    }

    void StopHunting()
    {
        anim.Play("Idle");
        physic.velocity = Vector3.zero;
    }
}
