using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTrigger : MonoBehaviour
{
	public PhysicsAnimConvertor Convertor { get; set; }
	public string TargetTag { get; set; }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag(TargetTag) && !Convertor.IsRecording)
		{
			Convertor.StartRecorder();
		}
	}
}
