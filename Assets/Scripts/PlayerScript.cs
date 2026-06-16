using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	[SerializeField] AudioClip RockSE;
	[SerializeField] AudioClip CrashSE;
	[SerializeField] AudioClip EmergencySE;
	[SerializeField] AudioClip RowlingSE;
	[SerializeField] GameObject RowlingPrefab;
	AudioSource aud;
	float speed = 20f;
	float tiltAngle = 45f;
	float tiltSpeed = 5f;
	float invincibleTime = 2.0f;
	float rotateSpeed = 720.0f;
	Rigidbody rbody;
	bool hit = false;
	bool isInvincible = false;
	bool isRotating = false;

	private void Start()
	{
		rbody = GetComponent<Rigidbody>();
		aud = GetComponent<AudioSource>();
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
		if (Mouse.current.rightButton.wasPressedThisFrame && !isInvincible)
		{
			StartCoroutine(InvincibleMode());
		}
		if (isRotating)
		{
			transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
		}


		Vector3 Move = new(moveX, moveY, 0);

		rbody.linearVelocity = Move * speed;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Rock"))
		{
			aud.PlayOneShot(RockSE);
			aud.PlayOneShot(CrashSE);
			if (!hit)
			{
				aud.PlayOneShot(EmergencySE);
				hit = true;
				StartCoroutine(GameOverCoroutine());
			}
		}
	}

	IEnumerator GameOverCoroutine()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("GameOverScene");
	}

	IEnumerator InvincibleMode()
	{
		isInvincible = true;
		isRotating = true;
		aud.PlayOneShot(RowlingSE);
		float distance = 40.0f;

		Vector3 spawnPos = transform.position + transform.forward * distance;

		GameObject Rowling = Instantiate(
			RowlingPrefab,
			spawnPos,
			transform.rotation
		);

		yield return new WaitForSeconds(invincibleTime);

		isInvincible = false;
		isRotating = false;

		Destroy(Rowling);
	}
}
