using UnityEngine;
using UnityEngine.InputSystem;

public class RockGenerate : MonoBehaviour
{
	[SerializeField] GameObject RockPrefab;
	[SerializeField] GameObject EarthPrefab;
	Rigidbody rbody;
	float time = 0f;
	float speed = 20f;

	private void Start()
	{
		rbody = GetComponent<Rigidbody>();
	}
	
	private void Update()
	{
		time += Time.deltaTime;
		if (time < 30f)
		{
			GameObject rock = Instantiate(RockPrefab, transform.position,Quaternion.identity);
		}

		if (time >= 30f && time <= 30.1f)
		{
			GameObject Earth = Instantiate(EarthPrefab, transform.position, Quaternion.identity);
		}
	}

	private void FixedUpdate()
	{
		float moveX = 0f;
		float moveY = 0f;

		if (Keyboard.current.aKey.isPressed)
		{
			moveX = -1f;
		}
		if (Keyboard.current.dKey.isPressed)
		{
			moveX = 1f;
		}
		if (Keyboard.current.wKey.isPressed)
		{
			moveY = 1f;
		}
		if (Keyboard.current.sKey.isPressed)
		{
			moveY = -1f;
		}

		Vector3 Move = new(moveX, moveY, 0);

		rbody.linearVelocity = Move * speed;
	}
}