using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterMovement : MonoBehaviour
{
    private bool _stopSpawning = false;
    public GameObject _engel1;
    public GameObject _engel2;
    public AudioSource audioSource_walk;
    public GameObject zaman_nesnesi;
    Rigidbody2D rigid;
    Vector3 move;
    float puan;


    public Animator animator;

    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnRoutine());
        print(SceneManager.GetActiveScene().buildIndex);
        GoNextLevel();
    } 
    //float mapSpeed=5.0f;
    float characterUpSpeed = 5.0f;
    float horizontalTransformSpeed = 10.0f;

    bool bas = false;
    bool bas2 = false;
    // Update is called once per frame
    bool degdi = false;
    int mevcut_sahne;
    void Update()
    {
       // DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mevcut_sahne = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("PauseMenu");
        }


        if (!degdi)
        {
            if (Input.GetAxis("Vertical") > 0f)
            {   
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 180.0f);
                bas = true;
                //transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
            }
            if (bas)
            {
                print("tek bas");
                rigid.AddForce(Vector3.up * characterUpSpeed);
                move = new Vector3(0f, Input.GetAxisRaw("Vertical"),0f);

                //transform.rotation = Quaternion.Euler(0f,0f, 180f);
                bas = false;
                rigid.gravityScale = -9.8f;
                //transform.position += move * characterUpSpeed * Time.deltaTime;
            }
        }



        if (Input.GetAxis("Vertical") < 0f)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            bas2 = true;
        }
        if (bas2)
        {
            rigid.gravityScale = 9.8f;
            rigid.AddForce(Vector3.down * characterUpSpeed);
            move = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            //transform.rotation = Quaternion.Euler(180f, 0f, 0f);
            bas2 = false;
            //transform.position += move * characterUpSpeed * Time.deltaTime;
        }


        move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += horizontalTransformSpeed * move * Time.deltaTime;

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, transform.rotation.z);
            
            
        }
        else if(Input.GetAxis("Horizontal") > 0.0f) { 
            
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z);
          
        }

        if(Input.GetAxis("Horizontal") != 0.0f && !audioSource_walk.isPlaying)
        {
            audioSource_walk.Play();
        }
        
        animator.SetFloat("Speed", Mathf.Abs( Input.GetAxis("Horizontal")));


        if (transform.position.x<-12.0f)
        {
            int mevcut_sahne = SceneManager.GetActiveScene().buildIndex;
            if(mevcut_sahne == 1)
            {
                zaman_nesnesi = GameObject.Find("zaman");
                skor skor_sc = zaman_nesnesi.GetComponent<skor>();
                puan = skor_sc.score;
                Debug.Log("Kaydettiðimiz deðer : " + Mathf.Ceil(puan));
                PlayerPrefs.SetFloat("topScore" , Mathf.Ceil(puan));
            }
            else if(mevcut_sahne == 2)
            {
                //skor2 skor2_sc = zaman_nesnesi.GetComponent<skor2>();
                //puan = skor2_sc.score;
                //Debug.Log("Kaydettiðimiz deðer : " + Mathf.Ceil(puan));
                //PlayerPrefs.SetFloat("topScore", Mathf.Ceil(puan));

            }
            Destroy(this.gameObject);
            Destroy(GameObject.Find("bg_music"));
            SceneManager.LoadScene("SampleScene");
        }


       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "taban")
        {
            //degdi = true;
            print("taban");
            bas = false;
            transform.position = new Vector3(transform.position.x,collision.transform.position.y-0.32f, 0f);
            print(transform.position.x);
            print(collision.transform.position.y - 1);
        }

        if (collision.gameObject.tag == "alttaban")
        {
            print("alttaban");
            bas = false;
            transform.position = new Vector3(transform.position.x, collision.transform.position.y+0.32f, 0f);
            print(transform.position.x);
            print(collision.transform.position.y - 1);
        }
    }


    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            
            Vector3 position = new Vector3(13f, -1.51f, 0);
            if (Random.Range(1, 7) <3.5f)
            {
                //Vector3 position = new Vector3(13f, -1.51f, 0);
                Instantiate(_engel1, position, Quaternion.identity);
               // Vector3 position = new Vector3(13f, -1.51f, 0);
            }
            else
            {
                //Vector3 position = new Vector3(13f, 1.79f, 0);
                Instantiate(_engel2, position, Quaternion.identity);
            }
           

            yield return new WaitForSeconds(3.0f);

        }
    }


    void GoNextLevel()
    {
        StartCoroutine(Gec());
    }
    IEnumerator Gec()
    {
        yield return new WaitForSeconds(10.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }



}
