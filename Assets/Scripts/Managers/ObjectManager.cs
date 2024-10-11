using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject cupPrefab;
    [SerializeField] private RectTransform UISpawnZoneRect;
    private GameObject cup;

    void OnEnable()
    {
        EventManager.instance.OnCollectableDrop += SpawnObjectInZone;
        EventManager.instance.OnCollect += SpawnObjectInZone;
    }

    void OnDisable()
    {
        EventManager.instance.OnCollectableDrop -= SpawnObjectInZone;
        EventManager.instance.OnCollect -= SpawnObjectInZone;
    }

    void Start()
    {
        cup = Instantiate(cupPrefab, UIManager.instance.GetHandleWorldPosition(), Quaternion.identity);
    }

    // Update is called once per frame
    public void UpdateCupPosition(Vector3 newPosition)
    {
        cup.transform.position = newPosition;
    }

    public void SpawnObjectInZone() {
        Vector3[] worldCorners = new Vector3[4];
        UISpawnZoneRect.GetWorldCorners(worldCorners);

        // Get the width and height of the spawn zone
        float width = Vector3.Distance(worldCorners[0], worldCorners[3]); // Bottom-left to bottom-right
        float height = Vector3.Distance(worldCorners[0], worldCorners[1]); // Bottom-left to top-left

        // Generate random position within these dimensions
        float randomX = Random.Range(0, width);
        float randomY = 1000f;//Random.Range(0, height);

        // Find the bottom-left corner of the RectTransform
        Vector3 bottomLeftCorner = worldCorners[0];

        // Calculate the random position in world space
        Vector3 randomWorldPosition = bottomLeftCorner + new Vector3(randomX, randomY, 0);

        Vector3 worldPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(UISpawnZoneRect, randomWorldPosition, Camera.main, out worldPosition);

        Debug.Log("Random World Position: " + worldPosition);

        Instantiate(PickRandomCollectablePrefab(), worldPosition, Quaternion.identity);
    }

    private GameObject PickRandomCollectablePrefab() {
        // pick one in Resources/Prefabs/Collectables

        GameObject[] collectablePrefabs = Resources.LoadAll<GameObject>("Prefabs/Collectables");
        return collectablePrefabs[Random.Range(0, collectablePrefabs.Length)];
    }
}
