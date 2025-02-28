using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;
using UnityEngine;

[ExecuteAlways]
public class SkeletonReference : MonoBehaviour
{
    public static SkeletonReference Instance;
    
    private Transform[] _skeletonBones;

    public Transform[] SkeletonBones
    {
        get
        {
            if (_skeletonBones == null || _skeletonBones.Length < 9)
                _skeletonBones = GetComponentsInChildren<Transform>();
            return _skeletonBones;
        }
    }

    private void Update()
    {
        if (!Instance)
            Instance = this;
    }

    public static Transform GetClosestSkeletonBone(Transform objectToCheck)
    {
        float closestDistance = Mathf.Infinity;
        Transform closestBone = Instance.SkeletonBones[0];
        foreach (Transform bone in Instance.SkeletonBones)
        {
            if (Vector3.Distance(objectToCheck.position, bone.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(objectToCheck.position, bone.position);
                closestBone = bone;
            }
        }
        return closestBone;
    }

    public static Transform GetHeadBone => Instance.SkeletonBones[2];

    public static Transform GetBodyBone => Instance.SkeletonBones[1];
}
