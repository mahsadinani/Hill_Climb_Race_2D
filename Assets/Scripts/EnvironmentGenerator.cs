using System;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode] 
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _SpriteShapeController;
    [SerializeField, Range(3f,100f)] private int _LevelLength = 50 ; 
    [SerializeField, Range(1f,50f)] private float _xMultiplier = 2f ; 
    [SerializeField, Range(1f,50f)] private float _yMultiplier = 2f ; 
    [SerializeField, Range(0f,1f)] private float _CurveSmoothness = 0.5f ;  // narm boodan monhani ha
    [SerializeField] private float _NoiseStep = 0.5f; // mizan pasti bolandi 
    [SerializeField] private float _Bottom = 10f;

    private Vector3 _LastPos; 

    private void OnValidate()
    {
        _SpriteShapeController.spline.Clear(); // spline is for create shape and clear is like reset at the begining 

        for (int i=0; i<_LevelLength;i++)
        {
            _LastPos = transform.position + new Vector3(i * _xMultiplier , Mathf.PerlinNoise(0,i*_NoiseStep)*_yMultiplier);
            _SpriteShapeController.spline.InsertPointAt(i,_LastPos); // baraye tarsim khat 

            if(i != 0 && i != _LevelLength - 1 )  // if it wasnt in the biginning or end of the road , make it curve
            {
                _SpriteShapeController.spline.SetTangentMode(i,ShapeTangentMode.Continuous); // peyvaste = continuous 
                _SpriteShapeController.spline.SetLeftTangent(i,Vector3.left * _xMultiplier * _CurveSmoothness);
                _SpriteShapeController.spline.SetRightTangent(i,Vector3.right * _xMultiplier * _CurveSmoothness);

            }
        }

        _SpriteShapeController.spline.InsertPointAt(_LevelLength, new Vector3(_LastPos.x , transform.position.y - _Bottom));
        _SpriteShapeController.spline.InsertPointAt(_LevelLength + 1 , new Vector3(transform.position.x , transform.position.y - _Bottom));

    }


}
