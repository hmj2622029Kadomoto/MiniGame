using UnityEditor.Build.Content;
using UnityEngine;

public class RockScript : MonoBehaviour
{
	[SerializeField] AudioClip RockSE;
	AudioSource aud;
	public void RockComing(Vector3 dir)
	{
		GetComponent<Rigidbody>().AddForce(dir);
	}

	private void Start()
	{
		RockComing(new Vector3(Random.Range(5000,-5001), Random.Range(5000,-5001), Random.Range(-10000,-50001)));
		aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (transform.position.z < -10.0f)
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Rock"))
		{
		}
		else
		{
			GetComponent<ParticleSystem>().Play();
			aud.PlayOneShot(RockSE);
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
		}
	}
}
