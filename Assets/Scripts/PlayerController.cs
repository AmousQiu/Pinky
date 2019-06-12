using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameScene, winScene, gameOverScene;
    public GameObject coverLayer, deathParticle;
    public AudioSource popcorn, jump;
    private DataController dataController;
    private GameData gameData;
    private GameSceneData gameSceneData;
    //private AudioClip jump;
    Rigidbody2D pinky;
    public int wickHitCount = 0;
    public static int wicksNeededToWin = 7;
    public static float sideVelocity = 0.1f, upThrust = 0.1f, forceOfGravity;

    void OnEnable()
    {
        gameScene.SetActive(true);
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        gameSceneData = gameData.gameSceneData;
        wickHitCount = 0;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        pinky = gameObject.GetComponent<Rigidbody2D>();
        pinky.gravityScale = gameSceneData.forceOfGravity;
        
        gameObject.transform.localPosition = new Vector3(-1200, 200, 0);
        gameObject.GetComponent<Renderer>().enabled = true;
        coverLayer.GetComponent<Renderer>().material.color = new Color((float)9 / 256, (float)9 / 256f, (float)14 / 256f, 0.95f);

    }

    void Update()
    {
        if (Input.touchCount > 0) 
       //if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pinky.velocity = Vector2.zero;
            pinky.AddForce(new Vector2(0, upThrust));
            //is.GetComponent<Animation>().Play("GamePinky");
            jump.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //player touches the wick
        if (other.gameObject.CompareTag("Goal"))           
        {
            //wickHitCount++;
            other.gameObject.GetComponent<Renderer>().enabled = false;
            coverLayer.GetComponent<Renderer>().material.color = new Color((float)9 / 256, (float)9 / 256f, (float)14 / 256f, (1 - (float)wickHitCount / wicksNeededToWin));
            if (wickHitCount == wicksNeededToWin)
            {
                gameScene.SetActive(false);
                winScene.SetActive(true);
            }
        }

        //player touches the fire
        if (other.gameObject.CompareTag("touch"))
        {
            wickHitCount++;
            other.gameObject.GetComponent<Renderer>().enabled = true;
            coverLayer.GetComponent<Renderer>().material.color = new Color((float)9 / 256, (float)9 / 256f, (float)14 / 256f, (1 - (float)wickHitCount / wicksNeededToWin));
            if (wickHitCount == wicksNeededToWin)
            {
                gameScene.SetActive(false);
                winScene.SetActive(true);
            }
        }

        //player touches the pillar
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            popcorn.Play();
            Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
            gameObject.GetComponent<Renderer>().enabled = false;
            StartCoroutine("KilledCo");
            
        }
    }

    public IEnumerator KilledCo()
    {
        yield return new WaitForSeconds(0.5f);
        popcorn.Stop();
        gameScene.SetActive(false);
        gameOverScene.SetActive(true);
    }

    public static int GetWicksNeededToWin()
    {
        return wicksNeededToWin;
    }
    public static void SetWicksNeededToWin(int set)
    {
        wicksNeededToWin = set;
    }

    public static float getForceOfGravity()
    {
        return forceOfGravity;
    }

    public static void setForceofGravity(float gravity)
    {
        forceOfGravity = gravity;
    }

    public static float getSidevelocity()
    {
        return sideVelocity;
    }
    public static void setSideVelocity(float sideVel)
    {
        sideVelocity = sideVel;
    }
    public static float getUpThrust()
    {
        return upThrust;
    }
    public static void setUpThrust(float upThr)
    {
        upThrust = upThr;
    }
}

