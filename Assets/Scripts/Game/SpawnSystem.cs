using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject mainMenu;
    [SerializeField] float timeSpawn = 3f;
    float rightBorder = 5f;
    float leftBorder = 1.5f;
    float zCoord = -5f;
    bool isGame;
    private void Start()
    {
        
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        isGame = true;
        StartCoroutine(nameof(Spawn));
    }

    private Vector3 GetRandomPositon()
    {
        float rand = Random.Range(leftBorder, rightBorder);
        if (Random.Range(0, 4) > 2) rand *= -1f;
        Vector3 pos = new Vector3(rand, 0.05f, zCoord);
        return pos;
    }

    private IEnumerator Spawn()
    {
        while (isGame)
        {
            Instantiate(cubePrefab, GetRandomPositon(), Quaternion.Euler(90,0,180));
            yield return new WaitForSeconds(timeSpawn);
        }
        
    }
    
}
