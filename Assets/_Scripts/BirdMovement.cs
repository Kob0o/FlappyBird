using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 4f;
    public float jumpSpeed = 4f;
    private BirdCollision bc;
    public AudioClip pointSound;
    private AudioSource audioSource;
    private Animation birdAnimation;

    private void Start()
    {
        bc = GetComponent<BirdCollision>();
        // Récupère le composant AudioSource attaché à ce GameObject
        audioSource = GetComponent<AudioSource>();

        // Vérifie si un AudioSource est attaché, sinon en ajoute un
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();

        }

        // Attribue le clip audio au AudioSource
        audioSource.clip = pointSound;
        birdAnimation = GetComponent<Animation>();
    }
    void Update()
    {
        //Translation continue vers la droite
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        // Si le joueur appuie sur la touche espace sauter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pointSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(pointSound);
            }
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}
