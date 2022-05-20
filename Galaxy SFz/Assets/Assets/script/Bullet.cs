using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject player;
    public GameObject bullet1;
// Use this for initialization
 void Start () {
     
 }
 
 // Update is called once per frame
 void Update () {
     if (Input.GetButtonDown("Fire1"))
     {
         //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //Vector2 direction = (Vector2)((worldMousePos - player.transform.position));
         //Vector2 direction = new Vector2(90.0f, 0.0f);
         //Vector2 direction = worldMousePos;

         //Debug.Log("Maus:"+worldMousePos.ToString());
         //Debug.Log("PlayerX:"+player.transform.position.x.ToString());
         //Debug.Log("PlayerY:"+player.transform.position.y.ToString());

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection-player.transform.position;



         //shootDirection.Normalize();
         // Creates the bullet locally
         GameObject bullet = (GameObject)Instantiate(
                                 bullet1,
                                 //transform.position + (Vector3)(shootDirection * 0.5f),
                                 transform.position,
                                 Quaternion.identity);
         // Adds velocity to the bullet
         bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletVelocity;
         StartCoroutine(SelfDestruct(bullet));    
     }
 }

 IEnumerator SelfDestruct(GameObject bullet)
 {
     yield return new WaitForSeconds(2f);
     Destroy(bullet);
 }

}
 