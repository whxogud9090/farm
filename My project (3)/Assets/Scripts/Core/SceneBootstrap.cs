using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow2D cameraFollow;

    private void Start()
    {
        if (playerPrefab == null || spawnPoint == null)
        {
            return;
        }

        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        player.tag = "Player";

        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(player.transform);
        }
    }
}
