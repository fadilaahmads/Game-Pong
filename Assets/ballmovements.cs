using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovements : MonoBehaviour
{
    //public int speed = 30;
    public Animation anim;
    public Rigidbody2D sesuatu;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 2) * 2 - 1; //nilai x bisa bernilai 1 atau -1
        int y = Random.Range(0, 2) * 2 - 1; //nilai y bisa bernilai 1 atau -1
        int speed = Random.Range(20,26); //Kecepatan berubah secara random antara 20 sampai 25
        GetComponent<Rigidbody2D>().velocity = new Vector2(x,y)*speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
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
        GetComponent<Rigidbody2D>().velocity =  Vector2.zero; //menghentikan bola
        GetComponent<Transform>().position = new Vector2(0,0); // mengubah posisi bola

        yield return new WaitForSeconds(1);

        int x = Random.Range(0, 2) * 2 - 1; //nilai x bisa bernilai 1 atau -1
        int y = Random.Range(0, 2) * 2 - 1; //nilai y bisa bernilai 1 atau -1
        int speed = Random.Range(20,26); //Kecepatan berubah secara random antara 20 sampai 25
        GetComponent<Rigidbody2D>().velocity = new Vector2(x,y)*speed; //mengatur kecepatan
    }
}
