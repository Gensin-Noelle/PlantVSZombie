using UnityEngine;
using UnityEngine.UI;

public class SunManager : MonoBehaviour
{
    public Text sunPointText;
    public float produceTime = 10;
    public GameObject sunPrefab;
    public static SunManager Instance { get; private set; }
    [SerializeField]
    private int sunPoint;
    private float produceTimer;
    private Vector2 sunPointTextPosition;
    private bool isStartProduce = false;

    private void Awake()
    {
        Instance = this;
        //由GameManager控制阳光的开始生成
        //StartProduce();
    }

    private void Start()
    {
        UpdateSunPointerText();
        CalcSunPointTextPosition();
    }

    private void Update()
    {
        if (isStartProduce)
        {
            ProduceSun(); //从外界掉入阳光
        }
    }

    public void StartProduce()
    {
        isStartProduce = true;
    }

    public int SunPoint
    {
        get { return sunPoint; }
    }

    private void UpdateSunPointerText()
    {
        sunPointText.text = sunPoint.ToString();
    }

    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointerText();
    }

    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointerText();
    }

    public Vector2 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }

    public void CalcSunPointTextPosition()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        sunPointTextPosition = position;
    }

    private void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceTime)
        {
            produceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-6f, 5f), 6, -1); //在屏幕外面随机生成，将Z轴设为-1，优先检测
            GameObject sun = Instantiate(sunPrefab, position, Quaternion.identity);

            position.y = Random.Range(-4, 3f);
            //StartCoroutine(sun.GetComponent<Sun>().MoveToTarget2(position));
            StartCoroutine(MyTools.MoveToTarget(sun, position, () => 
            {
                StartCoroutine(sun.GetComponent<Sun>().DelayedOnMouseDown());
            }));
        }
    }
}
