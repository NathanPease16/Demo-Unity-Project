using UnityEngine;
using UnityEngine.SceneManagement;
//                ^^^^^^^^^^^^^^^
// Must import SceneManagement package to manipulate scenes

public class NextLevel : MonoBehaviour
{
    // Another Unity message, similar to Update or Awake
    void OnTriggerEnter(Collider other)
    {
        // Checks to make sure the object that collided is the player, and not some other object with a collider
        if (other.gameObject.CompareTag("Player")
            // LoadScene will load a scene based on either a given name, or a given number representing the index
            // of that scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
