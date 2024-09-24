using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnState
{
    NotStart,
    Spawning,
    End
}
public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance { get; private set; }
    public List<Transform> spawnPointList;
    public List<GameObject> zombiePrefabList;
    public float refreshTime = 3;
    public int zombieNum = 5;//每一波僵尸基数
    private int sortingOrder = 0;
    private SpawnState spawnState = SpawnState.NotStart;
    private readonly List<Zombie> zombieList = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //由GameManager控制僵尸的开始刷新
        //StratSpawn();
    }

    private void Update()
    {
        if (spawnState == SpawnState.End && zombieList.Count == 0)
        {
            GameManager.Instance.GameCompletion();//当生成点处于结束状态且僵尸列表长度为0时，游戏通关
        }
    }

    public void StratSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }

    IEnumerator SpawnZombie()
    {
         yield return new WaitForSeconds(refreshTime * 4);   
        //第一波
        for (int i = 0; i < zombieNum; i++)
        {
            RandomSpawnZombie();
            yield return new WaitForSeconds(refreshTime);
        }

        yield return new WaitForSeconds(refreshTime * 2);

        //第二波
        for (int i = 0; i < zombieNum * 2; i++)
        {
            RandomSpawnZombie();
            yield return new WaitForSeconds(refreshTime);
        }

        yield return new WaitForSeconds(refreshTime * 3);
        AudioManager.Instance.PlayClip(Config.finalwave);
        //第三波
        for (int i = 0; i < zombieNum * 3; i++)
        {
            RandomSpawnZombie();
            yield return new WaitForSeconds(refreshTime);
        }

        //将生成点状态设置为结束状态
        spawnState = SpawnState.End;
    }

    private void RandomSpawnZombie()
    {
        int index = Random.Range(0, spawnPointList.Count);
        int zombieKindIndex = Random.Range(0, zombiePrefabList.Count);
        GameObject zombie = Instantiate(zombiePrefabList[zombieKindIndex], spawnPointList[index].position, Quaternion.identity);

        int order = spawnPointList[index].GetComponent<SpriteRenderer>().sortingOrder; //得到生成点的渲染图层
        zombie.GetComponent<SpriteRenderer>().sortingOrder = order + sortingOrder;//设置生成僵尸的渲染图层,即下面的僵尸比上面的僵尸渲染优先级高，后生成的僵尸比先生成的僵尸渲染优先级高
        
        zombieList.Add(zombie.GetComponent<Zombie>());

        if (sortingOrder >50) sortingOrder = 0;
        else sortingOrder++;

    }

    public void RemoveZombie(Zombie zombie)
    {
        zombieList.Remove(zombie);
    }
}
