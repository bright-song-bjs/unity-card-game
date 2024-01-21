using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardBase: MonoBehaviour {
  [SerializeField]
  private CardStyleSO cardStyleSO;

  [SerializeField]
  private Image cardBackImage;

  [SerializeField]
  private TextMeshProUGUI cardNameTMP;

  [SerializeField]
  private TextMeshProUGUI cardDescriptionTMP;

  private void Awake() {
    cardBackImage.sprite = cardStyleSO.cardBackSprite;
    cardNameTMP.text = cardStyleSO.cardName;
    cardDescriptionTMP.text = cardStyleSO.cardDescription;
  }

  public abstract void Cast(Caster caster);
}
