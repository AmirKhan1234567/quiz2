using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject fireprefab;
    public static SpawnManager Instance;
    private GameObject player;
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    public Transform PlayerPos;
    private float StartDelay = 2;
    private float spawnInterval = 5f;
    private float[] spawnX = { 8, -8 };
    private float[] spawnZ = { 8, -8 };
    public AudioClip clip;
    public AudioSource audio;
    public TMP_Text currentscore;
    public int score = 0;
    public TMP_Text healths;
    public int health = 100;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateSpawnPosition", StartDelay, spawnInterval);
        currentscore.text = score.ToString();
        enemyRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fireprefab, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
        }
    }
    void GenerateSpawnPosition()
    {

        Vector3 randomPos = new Vector3(spawnX[Random.Range(0, spawnX.Length)], 0, spawnZ[Random.Range(0, spawnZ.Length)]);
         Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        
      
    }
    public void playAudio()
    {
        audio.PlayOneShot(clip);
    }
    public void Add()
    {
        score += 25;
        currentscore.text = score.ToString();
    }
    public void healthloss()
    {
        health -= 10;
        healths.text = health.ToString();

    }

}
