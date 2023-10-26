using UnityEngine;

public class Flotando : MonoBehaviour {

  public float amplitude = 0.5f;
  public float frequency = 1f;
  
  Vector3 startPosition;
  
  void Start() {
    startPosition = transform.position; 
  }
  
  void Update() {
    Vector3 pos = startPosition;
    pos.y += Mathf.Sin(Time.time * frequency) * amplitude; 
    transform.position = pos;
  }

}