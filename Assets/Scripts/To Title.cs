using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
	void Update()
	{
		// クリックしたときにゲームシーンに移行する
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("StartScene");
		}
		else if( Keyboard.current.enterKey.wasPressedThisFrame) 
		{
			SceneManager.LoadScene("GameScene");
		}
	}
}
