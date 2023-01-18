using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 3.0f;

	Vector3 _destPos;

    void Start()
    {
		Managers.Input.KeyAction -= OnKeyboard;
		Managers.Input.KeyAction += OnKeyboard;		
	}

	public enum PlayerState
	{
		Die,
		Moving,
		Idle,
	}

	PlayerState _state = PlayerState.Idle;

	void UpdateDie()
	{
		// 아무것도 못함

	}

	void UpdateMoving()
	{
		Vector3 dir = _destPos - transform.position;
		if (dir.magnitude < 0.0001f)
		{
			_state = PlayerState.Idle;
		}
		else
		{
			float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
			transform.position += dir.normalized * moveDist;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
		}
	}

	void UpdateIdle()
	{
		
	}

	void Update()
    {
		switch (_state)
		{
			case PlayerState.Die:
				UpdateDie();
				break;
			case PlayerState.Moving:
				UpdateMoving();
				break;
			case PlayerState.Idle:
				UpdateIdle();
				break;
		}
	}

	void OnKeyboard()
	{
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
		float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
		transform.Translate(moveHorizontal,moveVertical,0);
		if (Input.GetKey(KeyCode.A))
		{
			transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		}

	}
	void OnMouseClicked(Define.MouseEvent evt)
	{
		if (_state == PlayerState.Die)
			return;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
		{
			_destPos = hit.point;
			_state = PlayerState.Moving;
		}
	}
}
