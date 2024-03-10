using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ReappearObjects : MonoBehaviour
{
    [SerializeField] private GameObject objectToReappear;
    [SerializeField] private GameObject[] positionsToReappear;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private VolleyballManager _VolleyballManagerScript;
    private Quaternion objectRotationToReappear;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        objectRotationToReappear = objectToReappear.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == objectToReappear.name)
        {
            ReappearBall();

            if (this.gameObject.name == "Point")
            {
                score++;
                _VolleyballManagerScript.score = score;
                scoreText.text = $"Your score: {score}";
            }
            else if (this.gameObject.name == "No Point")
            {
                if (score > 0)
                {
                    score--;
                    _VolleyballManagerScript.score = score;
                }
                scoreText.text = $"Your score: {score}";
            }
        }
    }

    private Vector3 KnowWhereReappear()
    {
        int randomIndex = Random.Range(0, positionsToReappear.Length);
        return positionsToReappear[randomIndex].gameObject.transform.position;
    }

    public void EndGame(string EndText)
    {
        scoreText.text = EndText;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = $"Your score: {score}";
    }

    public void ReappearBall()
    {
        objectToReappear.transform.position = KnowWhereReappear();
        objectToReappear.transform.rotation = objectRotationToReappear;
        Rigidbody rb = objectToReappear.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        rb.useGravity = false;
    }
}
