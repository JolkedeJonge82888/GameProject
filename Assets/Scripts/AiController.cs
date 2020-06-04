using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent Enemy;
    public GameObject finish;

    public GameObject hitParticle;

    private Vector3 posFinish;

    void Start()
    {
        posFinish = finish.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(!Finish.finished)
        {           
            Enemy.SetDestination(posFinish);
            anim.SetBool("WonGame", false);
        } else {
            anim.SetBool("isWalking", false);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Enemy.ResetPath();

            Enemy.SetDestination(posFinish);

            GameObject particle = Instantiate(hitParticle, this.transform.position, Quaternion.identity);

            /* Hier laat ik de particle afspelen */
            particle.GetComponent<ParticleSystem>().Play();

        }

    }


}
