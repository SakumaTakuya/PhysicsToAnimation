using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class BreakAnimGenerator : EditorWindow
{
	//各設定情報を保持するクラス
	public class PassingValues
	{
		public GameObject Target { get; set; }
		public Material CapMaterial { get; set; }
		public string Tag { get; set; }
		public float Interval { get; set; }
		public int Fineness { get; set; }
		public DefaultAsset Directory { get; set; }
		public string Name { get; set; }
		public bool IsFold { get; set; }
		public bool DoCut { get; set;}
		public bool DoAnimation { get; set; }

		public PassingValues(PassingValues passingValues)
		{
			Target = passingValues.Target;
			CapMaterial = passingValues.CapMaterial;
			Tag = passingValues.Tag;
			Interval = passingValues.Interval;
			Fineness = passingValues.Fineness;
			Directory = passingValues.Directory;
			Name = passingValues.Name;
			IsFold = passingValues.IsFold;
			DoCut = passingValues.DoCut;
			DoAnimation = passingValues.DoAnimation;
		}

		public PassingValues()
		{
			Target = null;
			CapMaterial = null;
			Tag = "Untagged";
			Interval = 0.5f;
			Fineness = 4;
			Directory = null;
			Name = "NewAnimationClip";
			IsFold = true;
			DoCut = false;
			DoAnimation = true;
		}
	}

	private readonly List<PassingValues> _values = new List<PassingValues>{new PassingValues()};
	private Vector2 _scrollPosition;
	private GameObject _part;
	
	[MenuItem("Tools/BreakAnimGenerator")]
	private static void Open()
	{
		GetWindow<BreakAnimGenerator>();
	}

	private void ApplyComponent()
	{
		foreach (var v in _values)
		{
			//カット処理
			if (v.DoCut)
			{
				//カット
				var i = v.Fineness;
				var victim = v.Target;
				while (i > 0)
				{
					var size = victim.GetComponent<Renderer>().bounds.size;
					EditorUtility.DisplayProgressBar("カット", "カットしているよ", (float) (v.Fineness - i) / v.Fineness);
					var pos = new Vector3(
						Random.Range(0, size.x / (i * 2)),
						Random.Range(0, size.y / (i * 2)),
						Random.Range(0, size.z / (i * 2))
					);
					var rote = new Quaternion(
						Random.Range(0, 1.0f),
						Random.Range(0, 1.0f),
						Random.Range(0, 1.0f),
						Random.Range(0, 1.0f)
					);

					var parts = BLINDED_AM_ME.MeshCut.Cut(victim, v.Target.transform.position + pos, rote * Vector3.right,
						v.CapMaterial);
					var tmp = victim;
					victim = parts[0];
					parts[1].name = "Part (" + i + ")";
					if (tmp != v.Target) DestroyImmediate(tmp);
					i--;
				}

				//カットしたゲームオブジェクトの処理
				foreach (Transform t in v.Target.transform)
				{
					t.gameObject.AddComponent<Rigidbody>();
				}
				DestroyImmediate(v.Target.GetComponent<MeshFilter>());
				DestroyImmediate(v.Target.GetComponent<MeshRenderer>());
				DestroyImmediate(v.Target.GetComponent<Collider>());
				EditorUtility.ClearProgressBar();
			}

			//Animation処理
			if (v.DoAnimation)
			{
				var pa = v.Target.AddComponent<PhysicsAnimConvertor>();
				pa.GeneratePath = AssetDatabase.GetAssetPath(v.Directory) + "/" + v.Name + ".anim";
				pa.Interval = v.Interval;
				pa.RecordTargetTag = v.Tag;
			}
		}
	}

	private void ResetList()
	{
		_values.Clear();
		_values.Add(new PassingValues());
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Add"))_values.Add(new PassingValues(_values.Last()));

		_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
		
		var hasError = false;
		
		//要素の表示
		foreach (var v in _values.ToArray())//エラー回避する為にToArrayに
		{
			v.Target = (GameObject) EditorGUILayout.ObjectField(v.Target, typeof(GameObject), true);
			hasError = hasError || v.DoCut && !v.CapMaterial || v.DoAnimation && ( !v.Target || !v.Directory || v.Name == "" );//すでにエラーが出ている||ターゲットがない||ディレクトリがない||名前がない||Materialがない

			if (!(v.IsFold = EditorGUILayout.Foldout(v.IsFold, "Settings"))) continue;
			
			
			v.DoCut = EditorGUILayout.ToggleLeft("Cutting", v.DoCut);
			if (v.DoCut)
			{
				v.CapMaterial =
					(Material) EditorGUILayout.ObjectField("    Cap Material", v.CapMaterial, typeof(Material), true);
				v.Fineness = EditorGUILayout.IntField("    Fineness", v.Fineness);
				EditorGUILayout.Space();
			}

			v.DoAnimation = EditorGUILayout.ToggleLeft("Animation", v.DoAnimation);
			if (v.DoAnimation)
			{
				v.Directory =
					(DefaultAsset) EditorGUILayout.ObjectField("    Generating Directory", v.Directory, typeof(DefaultAsset), true);

				v.Name = EditorGUILayout.TextField("    Generating Name", v.Name);
				v.Interval = EditorGUILayout.Slider("    Interval", v.Interval, 0.01f, 10f);
				v.Tag = EditorGUILayout.TagField("    Trigger Tag", v.Tag);
			}
			
			//要素の削除
			if (GUILayout.Button("Remove") && _values.Count > 1) _values.Remove(v);
		}
		EditorGUILayout.EndScrollView();
		
		//警告文の表示
		EditorGUILayout.BeginVertical();
		if (hasError) EditorGUILayout.HelpBox("There are some errors",MessageType.Error);
		EditorGUILayout.EndVertical();
		
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Apply Component") && !hasError) ApplyComponent();
		if (GUILayout.Button("Reset All")) ResetList();
		GUILayout.EndHorizontal();
	}
}
