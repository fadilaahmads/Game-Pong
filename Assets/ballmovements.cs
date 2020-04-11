using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovements : MonoBehaviour
{
    public int speed = 30;
    public Animation anim;
    public Rigidbody2D sesuatu;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1,-1)*speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(GetComponent<Rigidbody2D>().velocity.x > 0){ //ke kanan
                sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);
       }else
       {
                sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
       }
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
