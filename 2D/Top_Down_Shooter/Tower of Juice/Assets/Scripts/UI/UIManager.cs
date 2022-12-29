using Godot;
using System;

public class UIManager : CanvasLayer{
	private Control shopUI;
	private Control gameUI;

    private RichTextLabel hp;
    private RichTextLabel token;

    private GlobalPlayer playerData = GD.Load<GlobalPlayer>("res://Assets/Resources/PlayerData.tres");
    
    private PackedScene shopItemButtonPrefab = GD.Load<PackedScene>("res://Assets/Prefabs/UI/ShopButton.tscn");
    
    private GridContainer shopItemsContainer;

	public override void _Ready(){
        shopItemsContainer = GetNode<GridContainer>("Shop/Items");
        shopUI = GetNode<Control>("Shop");
        hp = GetNode<RichTextLabel>("GUI/Hp");
        token = GetNode<RichTextLabel>("GUI/Token");
        UpdateHpUI();
		UpdateTokenUI();
	}

    public void UpdateHpUI(){
        hp.Text = playerData.hp.ToString();
    }

    public void UpdateTokenUI(){
        token.Text = playerData.token.ToString();
    }

    public void OpenShop(){
        shopUI.Visible = true;
    }

    public void CloseShop(){
        shopUI.Visible = false;
    }

    public void CreateShopItemButton(ShopItem item, Shop shop){
        var button = (Button)shopItemButtonPrefab.Instance();
        button.Connect("pressed", shop, "TryBuyItem", new Godot.Collections.Array(){item.name});
        button.Icon = item.icon;
        shopItemsContainer.AddChild(button);
    }

    public void ClearShopItemButton(){
        foreach (Node item in shopItemsContainer.GetChildren()){
            shopItemsContainer.RemoveChild(item);
            item.QueueFree();
        }
    }
}
