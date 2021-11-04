using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoretext;
    public float scoreAmount;
    public float pointIncrease;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       scoretext.Text = (int) scoreAmount + " Score";
       scoreAmount += pointIncrease * Time.deltaTime;
    }
}
