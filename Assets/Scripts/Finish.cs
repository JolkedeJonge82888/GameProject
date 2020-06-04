using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using UnityEngine.AI;

public class Finish : MonoBehaviour
{
    public  NavMeshAgent Enemy;

    public static bool finished = false;

    public  GameObject winnerObj;
    public  Text winnerText;

    private Transform target;

	public float smoothSpeed = 0.01f;
	public Vector3 offset;

	public GameObject camera, PlayerC;

	public GameObject Hat;



    private IEnumerator OnTriggerEnter(Collider other)
    {
    	camera.SetActive(true);
    	if(GameManager.FirstPerson) {
			 camera.SetActive(true);
             PlayerC.SetActive(false);
		}
        Enemy.ResetPath();
        GameManager.Speed = 0;
        winnerObj.SetActive(true);
        winnerText.text = "The winner is: " + other.tag;
        finished = true;
        Destroy(Hat);
        target = other.GetComponent<Transform>();

        yield return new WaitForSeconds(5f);
     	other.GetComponent<Animator>().SetBool("WonGame", true);

    }

	void FixedUpdate()
	{
		if(finished) {

			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, desiredPosition, smoothSpeed);
			camera.transform.position = smoothedPosition;

			camera.transform.LookAt(target);
			camera.transform.RotateAround(target.transform.position, Vector3.down, smoothSpeed);


		}

	}
}
