using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpener : MonoBehaviour
{
    public string sceneName;
    public VictoryUI victoryUI;
    public float delayBeforeNext = 2f;
    private bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;
        triggered = true;
        var move = other.GetComponent<PlayerMove>(); 
        if (move) move.enabled = false;
        var rb = other.GetComponent<Rigidbody2D>();
        if (rb) rb.linearVelocity = Vector2.zero;
        if (victoryUI) victoryUI.PlayVictory();
        StartCoroutine(LoadNextScene());
    }
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delayBeforeNext);
        SceneManager.LoadScene(sceneName);
    }
}
