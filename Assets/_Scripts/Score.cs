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
        // Récupère le composant AudioSource attaché à ce GameObject
        audioSource = GetComponent<AudioSource>();

        // Vérifie si un AudioSource est attaché, sinon en ajoute un
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

            // Vérifie si le clip audio est assigné
            if (pointSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(pointSound);
            }
        }
    }
}
