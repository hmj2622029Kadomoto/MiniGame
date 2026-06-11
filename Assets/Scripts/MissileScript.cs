using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class MissileScript : MonoBehaviour
{
	public void Shoot(Vector3 dir)
	{
		GetComponent<Rigidbody>().AddForce (dir);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Rock"))
		{
			GetComponent<ParticleSystem>().Play();
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
			//Destroy(collision.gameObject);
		}
	}
	private void Update()
	{
		if (transform.position.z > 2000.0f)
		{
			Destroy(gameObject);
		}
	}
}
