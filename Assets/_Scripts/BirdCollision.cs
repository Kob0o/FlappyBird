using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public bool isDead;
    public GameObject GameOverText;
    public GameObject RestartButton;
    public GameObject BGMusic;
    public AudioClip deathSound;
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
        audioSource.clip = deathSound;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tuyau" || collision.gameObject.tag == "Limit")
        {
            isDead = true;
            GetComponentInChildren<BirdController>().speed = 0;
            GetComponentInChildren<BirdController>().jumpSpeed = 0;
            GetComponentInChildren<Rigidbody>().isKinematic = true;
            GameOverText.SetActive(true);
            RestartButton.SetActive(true);
            BGMusic.SetActive(false);
            if (deathSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(deathSound);
            }
        }
    }
}
