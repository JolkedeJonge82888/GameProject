using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
 	
 	Animator anim;
	private Vector3 moveDirection = Vector3.zero;
	public GameObject player;
	public float turnspeed=180f;

	public float gravity = 20.0F;

	CharacterController controller;
   
    public float Sensitivity = 100f;

    

    void Start() {
        anim = GetComponent<Animator>();
		anim.SetBool("WonGame", false);
		
		controller = GetComponent<CharacterController>();

    }
 
    void Update() {

		if(GameManager.Speed != 0) {

			if(GameManager.FirstPerson) {

		        float input_x = Input.GetAxis("Horizontal");
		        float input_z = Input.GetAxis("Vertical");

				bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_z)) > 0;

				anim.SetBool("isWalking", isWalking);
				Vector3 move = (transform.right * input_x + transform.forward * input_z);
				if(isWalking)
				{

					controller.Move( move * GameManager.Speed * Time.deltaTime);

				}



			} else {
				float input_x = -Input.GetAxisRaw("Horizontal");
				float input_y = -Input.GetAxisRaw("Vertical");

				bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

				anim.SetBool("isWalking", isWalking);

				if(isWalking)
				{

					

					moveDirection = new Vector3 (-Input.GetAxis ("Horizontal"), 0, -Input.GetAxis ("Vertical"));

					player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.LookRotation (moveDirection), turnspeed * Time.deltaTime);

					moveDirection.y -= gravity * Time.deltaTime;

					controller.Move(moveDirection * GameManager.Speed * Time.deltaTime);


				}
			}
		} else {

			anim.SetBool("isWalking", false);
		}
		
    }


}
