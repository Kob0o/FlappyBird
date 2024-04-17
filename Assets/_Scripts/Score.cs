using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public AudioClip pointSound; 
    private AudioSource audioSource;

    private void Start()
    {
        // R�cup�re le composant AudioSource attach� � ce GameObject
        audioSource = GetComponent<AudioSource>();

        // V�rifie si un AudioSource est attach�, sinon en ajoute un
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Attribue le clip audio au AudioSource
        audioSource.clip = pointSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            score += 1;
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);

            // V�rifie si le clip audio est assign�
            if (pointSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(pointSound);
            }
        }
    }
}
