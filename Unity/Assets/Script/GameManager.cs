using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private Text TimeText;
	[SerializeField]
	public Vector3 LimitTimeVector3;
	public static bool isGameOver = false;
	public static TimeSpan RestTime;



	private static DateTime StartTime;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		StartTime = DateTime.Now;
		StartCoroutine(Timer());
	}

	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// 制限時間の設定と残り時間を計算するメソッドの実行
	/// </summary>
	private IEnumerator Timer()
	{
		Text Timetext = TimeText;
		TimeSpan LimitTime = new TimeSpan((int)LimitTimeVector3.x, (int)LimitTimeVector3.y, (int)LimitTimeVector3.z);
		while (!isGameOver)
		{
			//StartCoroutine(DisplayTime(Timetext, LimitTime));
			yield return null;
		}
	}

	/// <summary>
	/// 残り時間をString型に変換
	/// </summary>
	public static string TimeCastToString(TimeSpan Time)
	{
		return Time.Minutes.ToString("D2") + ":" + Time.Seconds.ToString("D2");//timeString;
	}

	/// <summary>
	/// GUITextに残り時間を表記する。
	/// </summary>
	/// <param name="Timetext">Timetext.</param>
	/// <param name="limitTime">Limit time.</param>
	private static IEnumerator DisplayTime(Text Timetext, TimeSpan limitTime)
	{
		TimeCalculation(limitTime);
		Timetext.text = TimeCastToString(RestTime);
		yield return null;
	}

	/// <summary>
	/// 残り時間を計算
	/// </summary>
	private static void TimeCalculation(TimeSpan limitTime)
	{
		TimeSpan elapsedTime = (TimeSpan)(DateTime.Now - StartTime);
		RestTime = limitTime - elapsedTime;
	}

	private static void StopGame()
	{
		isGameOver = true;
		Time.timeScale = 0.015f;
	}

	public static GameObject FirstParent(GameObject child)
	{
		return child.transform.parent == null ? child : FirstParent(child.transform.parent.gameObject);
	}


	/// <summary>
	/// ベジェ曲線
	/// </summary>
	/// <param name="t">T.</param>
	/// <param name="p1">P1.</param>
	/// <param name="p2">P2.</param>
	/// <param name="p3">P3.</param>
	/// <param name="p4">P4.</param>
	public float Veje(float t, float p1, float p2, float p3, float p4)
	{
		float pos = (1 - t) * (1 - t) * (1 - t) * p1 + 3 * (1 - t) * (1 - t) * t * p2 + 3 * (1 - t) * t * t * p3 + t * t * t * p4;
		return pos;
	}

	/// <summary>
	/// 符号を維持した三平方の定理 
	/// 二次元ベクトルの計算の場合はベクトルごとに分けて計算
	/// </summary>
	/// <returns>The theorem.</returns>
	/// <param name="a">The alpha component.</param>
	/// <param name="b">The blue component.</param>
	public float PythagoreanTheorem(float a, float b)
	{
		return a + b < 0 ? -(Mathf.Pow(a, 2) + Mathf.Pow(b, 2)) : Mathf.Pow(a, 2) + Mathf.Pow(b, 2);
	}

	/// <summary>
	/// 指定された2つのオブジェクトの親子関係を制御。親子関係を解除された場合、親オブジェクトは破壊される。
	/// </summary>
	/// <param name="origin"></param>
	/// <param name="parent"></param>
	/// <param name="isDocking"></param>
	public static void RemovableObject(GameObject origin, GameObject parent, bool isDocking)
	{
		origin.transform.parent = isDocking ? parent.transform : null;
		if (!isDocking)
		{
			Destroy(parent);
		}
	}


	/// <summary>
	/// 符号を維持した平方根
	/// </summary>
	/// <param name="sqrt">Sqrt.</param>
	/// <param name="origin">Origin.</param>
	public float ImaginarySqrt(float c, float sign)
	{
		float sqrt = Mathf.Sqrt(Mathf.Abs(c));
		return sign == -1 ? -sqrt : sqrt;
	}
}
