using UnityEngine;
using UnityEngine.InputSystem;

public class MissileGenerator : MonoBehaviour
{
	[SerializeField] GameObject missilePrefab;
	[SerializeField] Transform player;
	float missileSpeed = 10000f;

	private void Update()
	{
		if(Mouse.current.leftButton.wasPressedThisFrame)
		{
			GameObject missile = Instantiate(missilePrefab,player.position,player.rotation);
			missile.GetComponent<MissileScript>().Shoot(player.forward * missileSpeed);
		}
	}
}
