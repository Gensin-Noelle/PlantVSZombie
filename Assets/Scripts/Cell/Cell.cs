using System.Collections;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private Plant currentPlant;
    private Vector2 currentCellIndex;
    private bool haveZombie = false;
    private static readonly Cell[,] cellArray = new Cell[5, 9];
    public static Cell Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    protected virtual void Start()
    {
        cellArray[(int)currentCellIndex.x, (int)currentCellIndex.y] = this;
    }

    private void OnMouseDown()
    {
        HandManager.Instance.OnCellClick(this);
    }

    public Vector2 AddPlant(Plant plant)
    {
        if (currentPlant != null) return new Vector2(10, 0); //当前位置已经有植物了，添加失败,返回一个不存在的索引
        currentPlant = plant;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable(); //启用动画
        AudioManager.Instance.PlayClip(Config.palnt);//播放种植音效
        return currentCellIndex; //返回当前索引
    }

    public void SetCurrentCellIndex(Vector2 index)
    {
        //在这里设置当前方格的索引
        currentCellIndex = index;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            haveZombie = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            haveZombie = false;
        }
    }

    public Vector2 GetCellIndex()
    {
        return currentCellIndex;
    }

    public bool GetHaveZombie()
    {
        return haveZombie;
    }

    public Cell GetCell(Vector2 index)
    {
        int x = (int)index.x;
        int y = (int)index.y;

        // 检查索引是否超出数组范围
        if (x < 0 || x >= cellArray.GetLength(0) || y < 0 || y >= cellArray.GetLength(1))
        {
            Debug.LogWarning("Trying to access a cell outside the bounds of the array.");
            return null; // 返回空引用
        }

        return cellArray[x, y];
    }

    public int GetCellArrayLength()
    {
        return cellArray.Length;
    }

    // public void SetCurrentPlantToNull()
    // {
    //     currentPlant = null;
    // }
}
