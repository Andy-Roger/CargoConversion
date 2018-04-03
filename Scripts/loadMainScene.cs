using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMainScene : MonoBehaviour, IHittable {

    public Scene mainScene;

    void Start () {
		
	}

    public void receiveHit(RaycastHit hit)
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
