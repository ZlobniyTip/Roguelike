using System.Collections;
using Assets.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class LootPiece : MonoBehaviour
    {
        [SerializeField] private GameObject _statue;
        [SerializeField] private GameObject _pickupFxPrefab;
        [SerializeField] private GameObject _pickupPopup;
        [SerializeField] private TMP_Text _lootText;

        private Loot _loot;
        private bool _picked;
        private WorldData _worldData;
        private float _delay = 1.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (!_picked)
            {
                PickUp();
                _picked = true;
            }
        }

        public void Construct(WorldData worldData) => _worldData = worldData;

        public void Initialize(Loot loot) => _loot = loot;

        private void PickUp()
        {
            UpdateWorldData();
            HideStatue();
            PlayPickupFx();
            ShowText();

            StartCoroutine(StartDestroyTimer());
        }

        private void UpdateWorldData() => _worldData.LootData.Collect(_loot);

        private void HideStatue() => _statue.SetActive(false);

        private void PlayPickupFx() => Instantiate(_pickupFxPrefab, transform.position, Quaternion.identity);

        private IEnumerator StartDestroyTimer()
        {
            yield return new WaitForSeconds(_delay);

            Destroy(gameObject);
        }


        private void ShowText()
        {
            _lootText.text = $"{_loot.Value}";
            _pickupPopup.SetActive(true);
        }
    }
}