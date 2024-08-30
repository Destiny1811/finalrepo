
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
}
