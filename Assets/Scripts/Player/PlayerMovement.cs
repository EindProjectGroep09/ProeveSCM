using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Components")]
	private Rigidbody _rb;

	[Header("Layer Masks")]
	[SerializeField]
	private LayerMask _groundLayer;

	[Header("Movement Variables")]
	[SerializeField]
	private float _movementAcceleration;

	[SerializeField]
	private float _maxMoveSpeed;

	[SerializeField]
	public float _GroundLinearDrag;

	private float _horizontalDirection;

	[Header("Jump Variables")]
	[SerializeField]
	private float _jumpForce = 12f;

	[SerializeField]
	private float _airLinearDrag = 2.5f;

	[SerializeField]
	private float _fallMultiplier = 8f;

	[SerializeField]
	private float _lowJumpFallMultiplier = 5f;

	[Header("Ground Collision Variables")]
	[SerializeField]
	private float _groundRaycastLength;

	[SerializeField]
	private Vector3 _groundRayCastOffset1;
	[SerializeField]
	private Vector3 _groundRayCastOffset;

	[SerializeField]
	private bool _onGround;

	[Header("Knockback Variables")]
	[SerializeField]
	private float _upKnockbackForce = 1.5f;

	[SerializeField]
	private float _sideWaysKnockbackForce = 3f;

	private float _resetDistance = -10f;

	private int _hitCount = 0;

	//Knockback base multiplier per hit (10%)
	[SerializeField]
	private float _KnockbackMult = 0.10f;

	private bool _canPlay = true;

	private bool _resetKnockback = true;

	public bool _hasKnockback = false;

	[SerializeField]
	private TextMesh Name;
	[SerializeField]
	private Transform NamePos;


	private bool _changingDirection => (_rb.velocity.x > 0f && _horizontalDirection < 0f) || (_rb.velocity.x < 0f && _horizontalDirection > 0f);

	private bool _canJump => Input.GetButtonDown("Jump") && _onGround;


	public int inputX;


	private void Awake()
	{
		GetComponent<Rigidbody>().gravityScale = 0f;
		//GetComponent<PlayerMovement2D>().enabled = false;
		GetComponent<Rigidbody>().bodyType = RigidbodyType2D.Static;
		gameObject.layer = 8;
	}

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}


	private void Update()
	{

		Name.transform.position = NamePos.transform.position;
		
		_horizontalDirection = GetInput().x;
		if (_canJump)
		{
			Jump();
		}
		if (transform.position.y <= _resetDistance || transform.position.y >= 0f - _resetDistance)
		{
			_hitCount = 0;
		}
	}

	private void FixedUpdate()
	{
		MoveCharacter();
		if (_onGround)
		{
			ApplyGroundLinearDrag();
			return;
		}
		ApplyAirLinearDrag();
		FallMultiplier();
	}

	private Vector2 GetInput()
	{

		if (Input.GetButtonDown("Left"))
		{
			inputX = -1;
		}
		else if (Input.GetButtonDown("Right"))
		{
			inputX = 1;
		}
		else
		{
			inputX = 0;
		}
		return new Vector2(inputX, Input.GetAxisRaw("Vertical"));
	}

	private void MoveCharacter()
	{
		_rb.AddForce(new Vector2(inputX, 0f) * _movementAcceleration);
		if (Mathf.Abs(_rb.velocity.x) > _maxMoveSpeed && !_hasKnockback)
		{
			_rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _maxMoveSpeed, _rb.velocity.y);
		}
	}

	private void ApplyGroundLinearDrag()
	{
		if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
		{
			_rb.drag = _GroundLinearDrag;
		}
		else
		{
			_rb.drag = 0f;
		}
	}

	private void ApplyAirLinearDrag()
	{
		_rb.drag = _airLinearDrag;
	}

	public void Jump(float boost = 1)
	{
		_rb.velocity = new Vector2(_rb.velocity.x, 0f);
		_rb.AddForce((Vector2.up * _jumpForce) * boost, ForceMode2D.Impulse);
		//audio here
	}

	private void FallMultiplier()
	{
		if (_rb.velocity.y < 0f)
		{
			_rb.gravityScale = _fallMultiplier;
		}
		else if (_rb.velocity.y > 0f && !Input.GetButtonDown("Jump"))
		{
			_rb.gravityScale = _lowJumpFallMultiplier;
		}
		else
		{
			_rb.gravityScale = 1f;
		}
	}


}
