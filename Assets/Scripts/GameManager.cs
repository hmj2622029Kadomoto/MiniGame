using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject timerText;
	float time = 0f;


	private void Update()
	{
		time += Time.deltaTime;
		timerText.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F1");
	}
}
