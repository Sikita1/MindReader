using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cloud : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimationHide() =>
        _animator.SetTrigger("Hide");

    public void Hide() =>
        gameObject.SetActive(false);
}
