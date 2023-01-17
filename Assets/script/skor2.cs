using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class skor2 : MonoBehaviour
{
    public float score;
    public Text zaman;
    public TextMeshProUGUI puan1;
    // Start is called before the first frame update
    void Start()
    {
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        Debug.Log(Mathf.Ceil(13.224f));

        puan1.text = "skor : " + Mathf.Ceil(score);

    }
}
