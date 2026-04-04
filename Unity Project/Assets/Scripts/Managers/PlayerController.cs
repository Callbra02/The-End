using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    private PlayerSprite _playerSprite;
    
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerSprite = GetComponent<PlayerSprite>();
    }

    private void Update()
    {
        
    }
}
