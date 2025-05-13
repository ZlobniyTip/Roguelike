using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _imageCurent;

        public void SetValue(float current, float max) =>
            _imageCurent.fillAmount = current / max;
    }
}