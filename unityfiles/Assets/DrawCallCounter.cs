using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.MemoryProfiler;


public class DrawCallCounter : MonoBehaviour {


    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = UnityEditor.UnityStats.triangles.ToString();
    }
}
