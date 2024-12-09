using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerControl : MonoBehaviour
{

    public Transform[] blobObj;
    static public string spawnedYet = "n";
    static public string combined = "n";

    static public Vector2 saucerxPos;
    static public Vector2 spawnPos;
    static public string newblob="n";
    static public int whichBlob = 0;

    public float minX = -3.5f;  
    public float maxX = 3.5f;  

    private Camera mainCamera;

    public AudioSource combineSound;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        spawnBlob();
        replaceBlob();
        makeSound();
        // control the suacer's x position with the mouse
        Vector2 mousePosition = Input.mousePosition;

        Vector2 worldPosition = mainCamera
                .ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));

        Vector2 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX); 

        transform.position = objectPosition;
        saucerxPos = transform.position;

    }
    
    // make pop sound when blobs combine
    void makeSound(){
        if(combined == "y"){
            combineSound.Play();
            combined = "n";
        }
    }
    // spawn new blob
    void spawnBlob(){
        if(spawnedYet=="n"){
            StartCoroutine(spawntimer());
            spawnedYet="y";
        }
    }

    // spawn next biggest blob after merging 
    void replaceBlob(){
        if (newblob == "y"){
            newblob = "n";
            Instantiate(blobObj[whichBlob + 1], spawnPos, blobObj[0].rotation);
        }
    }
    // wait to spawn a new blob in saucer
    IEnumerator spawntimer(){
        yield return new WaitForSeconds(.5f);
        Instantiate(blobObj[Random.Range(0,3)], transform.position, blobObj[0].rotation);
    }

}
