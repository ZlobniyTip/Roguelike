using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Services.SaveLoad;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    private ISaveLoadService _saveLoadService;

    private void Awake()
    {
        _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _saveLoadService.SaveProgress();
        Debug.Log("Progress Saved");
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if (!_collider)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
    }
}