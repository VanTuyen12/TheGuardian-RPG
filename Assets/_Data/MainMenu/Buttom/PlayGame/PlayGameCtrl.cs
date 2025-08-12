using UnityEngine;

public class PlayGameCtrl : ToggleAbstractUI<PlayGameCtrl>
{
   [SerializeField] protected Btn_Continue _btnContinue;
   public Btn_Continue BtnContinue => _btnContinue;
   [SerializeField] protected Btn_NewGame _btnNewGame;
   public Btn_NewGame BtnNewGame => _btnNewGame;
   [SerializeField] protected Animator _animator;
   public Animator Animator => _animator;
   protected override void HotkeyToogleUI(){}
   
   protected override void LoadComponents()
   {
      base.LoadComponents();
      LoadBtn_Continue();
      LoadBtn_NewGame();
      LoadAnimator();

   }
   protected virtual void LoadAnimator()
   {
      if(_animator != null) return;
      _animator = GetComponent<Animator>();
      Debug.Log(transform.name + " :LoadAnimator",gameObject);
   }
   protected virtual void LoadBtn_Continue()
   {
      if(_btnContinue != null) return;
      _btnContinue = GetComponentInChildren<Btn_Continue>();
      Debug.Log(transform.name + " :LoadBtn_Continue",gameObject);
   }
   protected virtual void LoadBtn_NewGame()
   {
      if(_btnNewGame != null) return;
      _btnNewGame = GetComponentInChildren<Btn_NewGame>();
      Debug.Log(transform.name + " :LoadBtn_NewGame",gameObject);
   }
}
