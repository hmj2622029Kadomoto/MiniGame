using UnityEditor.Build.Content;
using UnityEngine;

public class RockScript : MonoBehaviour
{

	public void RockComing(Vector3 dir)
	{
		GetComponent<Rigidbody>().AddForce(dir);
	}

	private void Start()
	{
		RockComing(new Vector3(Random.Range(5000,-5001), Random.Range(5000,-5001), Random.Range(-10000,-50001)));
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
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
		}
	}
}
