using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CarSpecs",menuName = "ScriptableObjects/CarSpecification")]
public class SpeedSetting : ScriptableObject
{
    public float acceleration = 1000f;
    public float breakingForce = 500f;
    public float maxTurnAngle = 45f;
}
