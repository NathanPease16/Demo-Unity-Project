using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= _damage;
    }
}
