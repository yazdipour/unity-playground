using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float timeLeft = 30;
    public int score = 0;
    public GameObject textTitleUI;
    public GameObject scoreTitleUI;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
            SceneManager.LoadScene("SampleScene");
        textTitleUI.gameObject.GetComponent<Text>().text = "Time:" + timeLeft;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 7;
        Debug.Log(score);
        Destroy(collision.gameObject);
        scoreTitleUI.gameObject.GetComponent<Text>().text = "Score:" + score;
    }
}
