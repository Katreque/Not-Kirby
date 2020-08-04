using UnityEngine;
using System.Collections;

public class poolColunas : MonoBehaviour 
{
    public GameObject columnPrefab;
    public int columnPoolSize = 7;
    public float spawnRate = 3f;
    public float columnMin = -3f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private int currentColumn = 0;
    private int lastColumn = 6;

    private float spawnXPosition = 7f;
    private float spawnYPosition;

    private Vector2 objectPoolPosition;

    void Start()
    {
        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++) {
            spawnYPosition = Random.Range(columnMin, columnMax);
            objectPoolPosition = new Vector2 (spawnXPosition + (i * spawnRate), spawnYPosition);
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameControl.instancia.gameOver == false) {
            if (columns[currentColumn].transform.position.x <= -10f) {

                spawnXPosition = columns[lastColumn].transform.position.x;
                spawnYPosition = Random.Range(columnMin, columnMax);

                columns[currentColumn].transform.position = new Vector2(spawnXPosition + spawnRate, spawnYPosition);
                lastColumn = currentColumn;
                currentColumn ++;
            }

            if(currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}