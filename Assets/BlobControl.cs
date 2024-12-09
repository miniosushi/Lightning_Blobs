using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlobControl : MonoBehaviour
{
    private string inthesaucer = "y";

    private float boundary = -5f;

    void Start()
    {
        // Add gravity to blobs that 
        // are spawned in the jar 
        if(transform.position.y < 4){
            inthesaucer = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void Update()
    {
        if(inthesaucer=="y"){
            Vector2 saucerPosition = SaucerControl.saucerxPos;
            float yOffset = -0.75f;  
            GetComponent<Transform>().position = new Vector3(saucerPosition.x, saucerPosition.y + yOffset, 0f);
        }

        // DROP BLOB
        // Add gravity to the blob once the 
        // mouse is clicked.
        if(Input.GetMouseButtonDown(0)){
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inthesaucer = "n";
            SaucerControl.spawnedYet = "n";
        }

        // END GAME 
        // when blob falls out of bounds
        // off the side of the jar
        if (transform.position.y < boundary)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("__Scene_0");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == gameObject.tag){
            // If blobs are gold - destroy both
            if(int.Parse(gameObject.tag) == 5){
                waitSec();
                Destroy(gameObject);
                ScoreCounter.blobNumber = 9;
                ScoreCounter.addPoints = "y";
                return;
            }
            // if blobs not gold, match - merge - spawn next
            // size blob in the same place
            SaucerControl.spawnPos = transform.position;
            SaucerControl.newblob = "y";
            SaucerControl.whichBlob = int.Parse(gameObject.tag);
            SaucerControl.combined = "y";
            ScoreCounter.blobNumber = int.Parse(gameObject.tag);
            ScoreCounter.addPoints = "y";
            fullSec();
            Destroy(gameObject);
            fullSec();
        }
    }

    // Wait methods for spawning blobs
    IEnumerator waitSec(){
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator fullSec(){
        yield return new WaitForSeconds(1);
    }
}