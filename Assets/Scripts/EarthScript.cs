using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EarthScript : MonoBehaviour
{
	[SerializeField] AudioClip CrashSE;
	AudioSource aud;
	int hit = 0;

	public void EarthComing(Vector3 dir)
	{
		GetComponent<Rigidbody>().AddForce(dir);
	}

	private void Start()
	{
		EarthComing(new Vector3(0,0,-5000));
		aud = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Sparrow"))
		{
			SceneManager.LoadScene("ClearScene");
		}

		if (other.gameObject.CompareTag("Missile"))
		{
			hit++;
			if (hit >= 10)
			{
				StartCoroutine(GameOverCoroutine());
			}
		}
	}
	IEnumerator GameOverCoroutine()
	{

		GetComponent<ParticleSystem>().Play();
		aud.PlayOneShot(CrashSE);
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("GameOverScene");
	}
}
