using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    public static PlayerController instance;
    public float speed = 5;
    private Vector3 startpos;
    public GameObject explosionParticle;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startpos = transform.position;
        PlayerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        PlayerRb.AddForce(Vector3.forward * forwardInput * -speed * Time.deltaTime, ForceMode.Impulse);
        float horizontalInput = Input.GetAxis("Horizontal");
        PlayerRb.AddForce(Vector3.right * horizontalInput * -speed * Time.deltaTime, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("walls"))
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            SpawnManager.Instance.playAudio();
            SpawnManager.Instance.healthloss();
            transform.position = startpos;

        }
    }
}
