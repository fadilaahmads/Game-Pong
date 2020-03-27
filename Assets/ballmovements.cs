using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovements : MonoBehaviour
{
    public int speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1,-1)*speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     //Ketika bola menabrak objek  
    void OnCollisionEnter2D(Collision2D other) {
         if(other.collider.name=="WallRight" || other.collider.name=="WallLeft"){
            StartCoroutine(jeda());
           
         }
    }
    IEnumerator jeda(){
        GetComponent<Rigidbody2D>().velocity =  Vector2.zero;
        GetComponent<Transform>().position = new Vector2(0,0);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1,-1)*speed;
    }
}
