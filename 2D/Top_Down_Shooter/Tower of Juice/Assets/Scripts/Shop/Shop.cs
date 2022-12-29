using Godot;
using System;
using System.Collections.Generic;

public class Shop : Node2D{
	private UIManager UI;
	private Dictionary<string, ShopItem> shopItemsData = new Dictionary<string, ShopItem>();
	private GlobalPlayer playerData = GD.Load<GlobalPlayer>("res://Assets/Resources/PlayerData.tres");
	private string pathToShopItem = "res://Assets/Resources/Jsons/ShopItemList.json";
	private bool isLoaded;
	private string pathToTexture= "res://Assets/Sprites/Weapons/";

	public override void _Ready(){
		UI = GetTree().CurrentScene.GetNode<UIManager>("CanvasLayer");
		UI.ClearShopItemButton();
		LoadShopItems();
		CreateShopItems();
	}

	private void LoadShopItems(){
		JSONParseResult jsonData;
   		File fileData = new File();

   	 	fileData.Open(pathToShopItem, File.ModeFlags.Read);
    	jsonData = JSON.Parse(fileData.GetAsText());
    	fileData.Close();
        var foo = (Godot.Collections.Dictionary)jsonData.Result;

		foreach (System.Collections.DictionaryEntry item in foo){
			var foofoo = (Godot.Collections.Dictionary)item.Value;
			var name = item.Key.ToString();
			var description = foofoo["Description"].ToString();
			var type = foofoo["Type"];
			var cost = Int32.Parse(foofoo["Cost"].ToString());
			var texture =  ResourceLoader.Load(pathToTexture + name + ".png") as Texture;
			ShopItem maybeItem = null;
			switch(type){
				case "Weapon":
					maybeItem = new ShopWeaponItem(name, description, texture,cost);
					break;
			}
			
			shopItemsData.Add(name ,maybeItem);
		}
	}

	private void CreateShopItems(){
		foreach (var item in shopItemsData){
			UI.CreateShopItemButton(item.Value, this);
		}
	}
	
	public void TryBuyItem(string itemName){
		if(!shopItemsData.ContainsKey(itemName)) return;
		var item = shopItemsData[itemName];
		if(!item.IsAbleToBuy(playerData.token)) {
			return;
		}
		playerData.SetToken(playerData.token - item.cost);
		UI.UpdateTokenUI();
		item.Buy();
	}

	private void EnterShop(Node body){
		UI.OpenShop();
	}

	private void ExitShop(Node body){
		UI.CloseShop();
	}
}
