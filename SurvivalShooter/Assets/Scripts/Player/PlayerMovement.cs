using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public float playerIndex;
	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal" + playerIndex) * Time.deltaTime * 150;
		float v = Input.GetAxisRaw("Vertical" + playerIndex) * speed * Time.deltaTime;

		Move(v);
		Turning(h);
		Animating(h, v);
	}

	void Move(float v)
	{

		transform.Translate(0, 0, v);
		/*movement.Set(0f, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);*/
	}

	void Turning(float h)
	{
		transform.Rotate(0, h, 0);
		/*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}*/
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
	}
}
