using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	[SerializeField] private GameObject _textPoint;

	private int prevPoint;

	private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPoint(int point)
	{
		string text = (prevPoint+point).ToString();
		_textPoint.GetComponent<TextMeshProUGUI>().text = text;
		prevPoint = point;
	}
}
