using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PhysicsAnimConvertor : MonoBehaviour {
	
	public bool IsRecording { get; private set; }

	[SerializeField] private string _recordTargetTag;
	[SerializeField] private float _interval = 1;
	[SerializeField] private string _generatePath = "Assets/NewAnimationClip.anim";
	[SerializeField] private KeyCode stopCode = KeyCode.Escape;
	
	public string RecordTargetTag
	{
		get { return _recordTargetTag; }
		set { _recordTargetTag = value; }
	}

	public float Interval
	{
		get { return _interval; }
		set { _interval = value; }
	}

	public string GeneratePath
	{
		get { return _generatePath; }
		set { _generatePath = value; }
	}

	public KeyCode StopCode
	{
		get { return stopCode; }
		set { stopCode = value; }
	}

	private AnimationClip _animclip;
	private readonly List<IRecorder> _recorders = new List<IRecorder>();
	
	private void Start()
	{	
		_animclip = new AnimationClip();
		
		//記録するTransformを追加する
		foreach (var t in HierarchyObject.GetTransforms(transform))
		{
			//ターゲットのオブジェクトが衝突したときに記録を開始するコンポーネントを追加する
			var rt = t.gameObject.AddComponent<RecordTrigger>();
			rt.Convertor = this;
			rt.TargetTag = _recordTargetTag;
			
			//Positionの登録
			_recorders.Add(new PosXRecorder(_interval, _animclip, t));
			_recorders.Add(new PosYRecorder(_interval, _animclip, t));
			_recorders.Add(new PosZRecorder(_interval, _animclip, t));
			
			//Rotationの登録
			_recorders.Add(new RoteXRecorder(_interval, _animclip, t));
			_recorders.Add(new RoteYRecorder(_interval, _animclip, t));
			_recorders.Add(new RoteZRecorder(_interval, _animclip, t));
			_recorders.Add(new RoteWRecorder(_interval, _animclip, t));						
		}
	}

	//本当はエディタ拡張とかでうまくやりたいがとりあえずこれでアニメーションの記録をやめる
	private void Update()
	{
		if(!Input.GetKeyDown(stopCode) || !IsRecording) return;
		
		StopRecorder();
	}

	//記録開始
	public void StartRecorder()
	{
		IsRecording = true;

		foreach (var recorder in _recorders)
		{
			StartCoroutine(recorder.RegisterKey());
		}
	}

	//記録終了
	public void StopRecorder()
	{
		IsRecording = false;
		
		foreach (var recorder in _recorders)
		{
			recorder.EndRegistration();
		}

		WriteAnimationCurve();
	}
	
	// AnimationClipファイルの書き出し
	private void WriteAnimationCurve()
	{
		AssetDatabase.CreateAsset(
			_animclip, 
			AssetDatabase.GenerateUniqueAssetPath(_generatePath)
		);
		
		AssetDatabase.Refresh();
	}
}
