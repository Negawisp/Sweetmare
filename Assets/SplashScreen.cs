using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {


    public Image splashImage;

    public string loadLevel;
	// Use this for initialization
    IEnumerator Start () {

        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(loadLevel);

	}
	
    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1f, 2f, false);
    }

}
