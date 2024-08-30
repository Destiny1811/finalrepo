using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Camera follows the player

    public GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
