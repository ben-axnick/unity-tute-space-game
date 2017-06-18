using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject player_explosion;
    private GameController game;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        game = gameControllerObject.GetComponent<GameController>();
    }

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;

        game.NotifyAstroidDestroyed();

        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(player_explosion, other.transform.position, other.transform.rotation);
            game.NotifyPlayerDestroyed();
        }
    }
}
