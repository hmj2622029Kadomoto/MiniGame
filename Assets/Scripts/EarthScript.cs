using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthScript : MonoBehaviour
{
	public void EarthComing(Vector3 dir)
	{
		GetComponent<Rigidbody>().AddForce(dir);
	}

	private void Start()
	{
		EarthComing(new Vector3(0,0,-10000));
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Sparrow"))
		{
			SceneManager.LoadScene("ClearScene");
		}
	}
}
