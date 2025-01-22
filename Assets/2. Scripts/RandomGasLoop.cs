using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RandomGasLoop : MonoBehaviour
{
    private GameManager manager;
    
    public GameObject gasPrefab;
    public int poolSize = 5;
    private List<GameObject> gasPool = new ();
    
    public float gasLoopSpeed = 25.0f;
    public float spawninterval = 2.0f;
    private float[] gasXPositions = { -2, -1, 0, 1, 2 };
    
    void Start()
    {
        InitializeGasPool();
        manager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnGas());
    }
    
    void Update()
    {
        if (manager.isGameOver)
        {
            return;
        }

        MoveAndReuseGases();
    }

    private void InitializeGasPool()
    {
        gasPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gas = Instantiate(gasPrefab);
            gasPool.Add(gas);
            gas.SetActive(false);
        }
    }

    private IEnumerator SpawnGas()
    {
        while (!manager.isGameOver)
        {
            yield return new WaitForSeconds(spawninterval);

            GameObject gas = GetInactiveGasFromPool();
            
            if (gas != null)
            {
                int randomIndex = Random.Range(0, gasXPositions.Length);
                float randomX = gasXPositions[randomIndex];
                gas.transform.position = new Vector3(randomX, 1, 10); // 생성 위치
                gas.SetActive(true);                                 // 활성화
            }
        }
    }
    
    private GameObject GetInactiveGasFromPool()
    {
        foreach (GameObject gas in gasPool)
        {
            if (!gas.activeSelf) // 비활성화된 오브젝트 찾기
            {
                return gas;
            }
        }

        return null; // 사용 가능한 오브젝트가 없으면 null 반환
    }
    
    private void MoveAndReuseGases()
    {
        for (int i = 0; i < gasPool.Count; i++)
        {
            GameObject gas = gasPool[i];

            // 오브젝트가 파괴되었는지 확인
            if (gas == null)
            {
                gasPool.RemoveAt(i);
                i--; // 리스트 인덱스 조정
                continue;
            }

            // 활성화된 가스를 이동
            if (gas.activeSelf)
            {
                gas.transform.position += Vector3.back * gasLoopSpeed * Time.deltaTime;

                // 범위를 벗어나면 비활성화
                if (gas.transform.position.z <= -10)
                {
                    gas.SetActive(false);
                }
            }
        }
    }
}
