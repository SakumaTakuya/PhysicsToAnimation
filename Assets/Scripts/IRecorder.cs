using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public interface IRecorder
{
    float Interval { get; set; }
    AnimationClip Animclip { get; }

    IEnumerator RegisterKey();
    void EndRegistration();
}


public class PosXRecorder : IRecorder
{
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;

    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {        
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalPosition.x"
        };

        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localPosition.x);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public PosXRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}

public class PosYRecorder : IRecorder
{
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;

    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalPosition.y"
        };
        
        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localPosition.y);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public PosYRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}

public class PosZRecorder : IRecorder
{
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;

    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalPosition.z"
        };
        
        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localPosition.z);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public PosZRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}

public class RoteXRecorder : IRecorder
{
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;

    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalRotation.x"
        };
        
        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localRotation.x);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public RoteXRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
    
}

public class RoteYRecorder : IRecorder
{
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;
    
    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;   
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalRotation.y"
        };
        
        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localRotation.y);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public RoteYRecorder(float interval, AnimationClip animclip, Transform targetTransform) 
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}

public class RoteZRecorder : IRecorder
{   
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;
    
    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalRotation.z"
        };
        
        while (_isRegistering)
        {
            Debug.Log(TargetTransform.localRotation.z);
            curve.AddKey(time, TargetTransform.localRotation.z);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public RoteZRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}

public class RoteWRecorder : IRecorder
{   
    public Transform TargetTransform { get; protected set; }
    public float Interval { get; set; }
    public AnimationClip Animclip { get; private set; }

    private bool _isRegistering;
    
    public void EndRegistration()
    {
        _isRegistering = false;
    }
    
    public IEnumerator RegisterKey()
    {
        _isRegistering = true;
        
        var time = 0.0f;
        var curve = new AnimationCurve();
        var curveBinding = new EditorCurveBinding
        {
            path = HierarchyObject.GetObjectPath(TargetTransform),
            type = typeof(Transform),
            propertyName = "m_LocalRotation.w"
        };
        
        while (_isRegistering)
        {
            curve.AddKey(time, TargetTransform.localRotation.w);
            yield return new WaitForSeconds(Interval);
			
            time += Interval;
        }
        
        AnimationUtility.SetEditorCurve(Animclip, curveBinding, curve);
    }

    public RoteWRecorder(float interval, AnimationClip animclip, Transform targetTransform)
    {
        Interval = interval;
        Animclip = animclip;
        TargetTransform = targetTransform;
    }
}