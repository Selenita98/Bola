using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Vector3 direction;

    Rigidbody body;

    [SerializeField]
    float impulse = 2f;

    float totalCoins;

    [SerializeField]
    TextMeshProUGUI labelTotalCoins;

    [SerializeField]
    GameObject coinParticles;

    [SerializeField]
    TextMeshProUGUI labelTime;

    [SerializeField]
    GameObject finalPartida;

    float tiempoJugando;
    bool estaJugando = true;

    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        direction.z = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.x = - Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        transform.Translate(direction);

        labelTotalCoins.text = totalCoins.ToString() + " Coins";

        if(totalCoins == 10f)
        {
            finalPartida.SetActive(true);
            estaJugando = false;
            labelTime.text = tiempoJugando.ToString("00.00");
           

        }

        if (estaJugando == true)
        {
            tiempoJugando = tiempoJugando + Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Coins")
            totalCoins += 1f;

        collision.GetComponent<AudioSource>().Play();
    

        Destroy(collision.gameObject, 0.3f);
    }
}




