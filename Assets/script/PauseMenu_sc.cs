using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_sc : MonoBehaviour
{

    GameObject sahne_number;
    int sahne = 0;
    int aktif_sahne;
    public void anaMenu() {

        SceneManager.LoadScene("SampleScene");


    }

    public void yenidenBaslat()
    {
        SceneManager.LoadScene("firstStage");

    }
    // Start is called before the first frame update
    void Start()
    {
        sahne_number = GameObject.Find("sahneNum");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            
            sahneNum sahneNum_sc = sahne_number.GetComponent<sahneNum>();
            SceneManager.LoadScene(sahneNum_sc.sahne_index);
           
        }

    }
}
