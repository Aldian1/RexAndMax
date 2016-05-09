using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeadZone : MonoBehaviour
{ 

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("working");
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

}
