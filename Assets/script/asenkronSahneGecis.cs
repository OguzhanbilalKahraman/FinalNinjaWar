using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asenkronSahneGecis : MonoBehaviour
{


    public bool bolumGecildiMi = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }





    // Update is called once per frame
    void Update()
    {

        if (bolumGecildiMi)
        {
            StartCoroutine(Gec());
        }
        
    }

    IEnumerator Gec()
    {
        yield return new WaitForSeconds(5.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
