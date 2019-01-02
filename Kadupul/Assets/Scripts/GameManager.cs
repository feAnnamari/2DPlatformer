using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	[SerializeField] private GameObject _textPoint;
	[SerializeField] private GameObject _endText;

	private int prevPoint;

	private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
		_endText.GetComponent<TextMeshProUGUI>().text = "0 of 5 crystals have been collected";
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
		_endText.GetComponent<TextMeshProUGUI>().text = text + " of 5 crystals have been collected";
		prevPoint = prevPoint+point;
		Debug.Log(text);
	}
}
