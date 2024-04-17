using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    void Start()
    {
        float rFloat = Random.Range(7f, -1f);
        Vector3 v3 = new Vector3(transform.position.x + 7, rFloat, transform.position.z);
        Instantiate(pipe, v3, transform.rotation);
    }
}
