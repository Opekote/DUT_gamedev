using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnterT : MonoBehaviour
{
    private Animator CaveWarning;
    public string LevelToLoad;
    [SerializeField] Collider2D Player;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider == Player)
        {
            CaveWarning.SetBool("PlayerEnter", true);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider == Player && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider == Player)
        {
            CaveWarning.SetBool("PlayerEnter", false);
        }
    }
}