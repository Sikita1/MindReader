using UnityEngine;
using YG;

public class ADS : MonoBehaviour
{
    [SerializeField] private Secret _secretPanel;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    public void LearnSecret() =>
        OpenRewardAd(0);

    public void HidePanel() =>
        _secretPanel.gameObject.SetActive(false);

    public void Show() =>
        YandexGame.FullscreenShow();

    private void Rewarded(int obj) =>
        _secretPanel.gameObject.SetActive(true);

    private void OpenRewardAd(int id) =>
        YandexGame.RewVideoShow(id);
}
