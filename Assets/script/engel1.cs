using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engel1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed =4.5f;
    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += Vector3.left * speed * Time.deltaTime;





        if (transform.position.x < -20.0f)
        {
            Destroy(this.gameObject);
        }







    }
}
