using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	float speed = 20f;
	float tiltAngle = 45f;
	float tiltSpeed = 5f;
	Rigidbody rbody;
	bool hit = false;

	private void Start()
	{
		rbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float moveX = 0f;
		float moveY = 0f;

		if (Keyboard.current.aKey.isPressed)
		{
			moveX = -1f;
			float targetZ = moveX * tiltAngle;
			Quaternion targetRotation = Quaternion.Euler(0,0,targetZ);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
		}
		if (Keyboard.current.dKey.isPressed)
		{
			moveX = 1f;
			float targetZ = moveX * tiltAngle;
			Quaternion targetRotation = Quaternion.Euler(0,0,targetZ);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
		}
		if (Keyboard.current.wKey.isPressed)
		{
			moveY = 1f;
			float targetX = -moveY * tiltAngle;
			Quaternion targetRotation = Quaternion.Euler(targetX,0,0);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
		}
		if (Keyboard.current.sKey.isPressed)
		{
			moveY = -1f;
			float targetX = -moveY * tiltAngle;
			Quaternion targetRotation = Quaternion.Euler(targetX,0,0);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
		}

		Vector3 Move = new(moveX, moveY, 0);

		rbody.linearVelocity = Move * speed;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Rock") && !hit)
		{
			hit = true;
			StartCoroutine(GameOverCoroutine());
		}
	}
	IEnumerator GameOverCoroutine()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("GameOverScene");
	}
}
