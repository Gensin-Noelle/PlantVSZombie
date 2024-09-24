using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public GameObject shovel;
    // Start is called before the first frame update
    void Start()
    {
        shovel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        gameObject.SetActive(false);
        shovel.SetActive(true);
        AudioManager.Instance.PlayClip(Config.shovel);
    }

    public void OnNextClick()
    {
        gameObject.SetActive(true);
        shovel.SetActive(false);
        AudioManager.Instance.PlayClip(Config.button_click);
    }
}
