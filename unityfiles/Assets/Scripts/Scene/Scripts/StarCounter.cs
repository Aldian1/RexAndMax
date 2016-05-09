using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {



    public GameObject starcounter;

    void Start()
    {
        starcounter = this.gameObject;
    }

    public void AddStars(int amount)
    {
        int current;
        current = int.Parse(starcounter.GetComponent<Text>().text);

        current += amount;

        starcounter.GetComponent<Text>().text = current.ToString();
    }
}
