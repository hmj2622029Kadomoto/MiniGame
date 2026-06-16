using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class MissileGenerator : MonoBehaviour
{
	[SerializeField] GameObject missilePrefab;
	[SerializeField] Transform player;
	float missileSpeed = 10000f;
	float offset = 3f;
	float nextShotTime;
	bool right;

	private void Update()
	{
		if(Mouse.current.leftButton.isPressed&&Time.time >= nextShotTime)
		{
			nextShotTime = Time.time + 0.1f;
			if (right)
			{
				Vector3 rightPos = player.position + player.right * offset + player.forward * 1.0f;
				GameObject rightMissile = Instantiate(missilePrefab, rightPos, player.rotation);
				rightMissile.GetComponent<MissileScript>().Shoot(player.forward * missileSpeed);
				StartCoroutine(ShotInterval());
				right = false;
			}
			else
			{
				Vector3 leftPos = player.position - player.right * offset + player.forward * 1.0f;
				GameObject leftMissile = Instantiate(missilePrefab, leftPos, player.rotation);
				leftMissile.GetComponent<MissileScript>().Shoot(player.forward * missileSpeed);
				StartCoroutine(ShotInterval());
				right = true;
			}
		}
	}
	IEnumerator ShotInterval()
	{
		yield return new WaitForSeconds(0.5f);
	}
}
