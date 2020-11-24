using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

	// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
	public class IAPManager : MonoBehaviour, IStoreListener
	{

		public static IAPManager Instance{ set; get;}
		private static IStoreController m_StoreController;          // The Unity Purchasing system.
		private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

		public static string MODIFIED_M4A1 = "modified_m4a1";   
		public static string REVOLVER = "revolver";
		public static string KALASHNIKOV = "kalashnikov"; 
		public static string MODIFIED_RIFLE = "modified_rifle";   
		public static string MP5 = "mp5";
		public static string MACHINEGUN = "machinegun";

	void Awake ()
	{
		Instance = this;
	}
		private void Start()
		{
			// If we haven't set up the Unity Purchasing reference
			if (m_StoreController == null)
			{
				// Begin to configure our connection to Purchasing
				InitializePurchasing();
			}
		}

		public void InitializePurchasing() 
		{
			// If we have already connected to Purchasing ...
			if (IsInitialized())
			{
				// ... we are done here.
				return;
			}

			// Create a builder, first passing in a suite of Unity provided stores.
			var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
			builder.AddProduct(MODIFIED_M4A1, ProductType.NonConsumable);
			builder.AddProduct(REVOLVER, ProductType.NonConsumable);
			builder.AddProduct(MACHINEGUN, ProductType.NonConsumable);
			builder.AddProduct(KALASHNIKOV, ProductType.NonConsumable);
			builder.AddProduct(MP5, ProductType.NonConsumable);
			builder.AddProduct(MODIFIED_RIFLE, ProductType.NonConsumable);
			UnityPurchasing.Initialize(this, builder);
		}


		private bool IsInitialized()
		{
			
			return m_StoreController != null && m_StoreExtensionProvider != null;
		}


		public void Modified_Rifle()
		{
			
			BuyProductID(MODIFIED_RIFLE);
		}
		
		public void Modified_M4a1()
		{

			BuyProductID(MODIFIED_M4A1);
		}

		public void Revolver()
		{
			BuyProductID(REVOLVER);
		}

		public void Machinegun()
		{

			BuyProductID(MACHINEGUN);
		}

		public void Mp5()
		{

			BuyProductID(MP5);
		}

		public void Kalashnikov()
		{

			BuyProductID(KALASHNIKOV);
		}


		private void BuyProductID(string productId)
		{
			// If Purchasing has been initialized ...
			if (IsInitialized())
			{
				// ... look up the Product reference with the general product identifier and the Purchasing 
				// system's products collection.
				Product product = m_StoreController.products.WithID(productId);

				// If the look up found a product for this device's store and that product is ready to be sold ... 
				if (product != null && product.availableToPurchase)
				{
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
					// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
					// asynchronously.
					m_StoreController.InitiatePurchase(product);
				}
				// Otherwise ...
				else
				{
					// ... report the product look-up failure situation  
					Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
				}
			}
			// Otherwise ...
			else
			{
				// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
				// retrying initiailization.
				Debug.Log("BuyProductID FAIL. Not initialized.");
			}
		}

		public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
		{
			// Purchasing has succeeded initializing. Collect our Purchasing references.
			Debug.Log("OnInitialized: PASS");

			// Overall Purchasing system, configured with products for this application.
			m_StoreController = controller;
			// Store specific subsystem, for accessing device-specific store features.
			m_StoreExtensionProvider = extensions;
		}


		public void OnInitializeFailed(InitializationFailureReason error)
		{
			// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
			Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		}


		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
		{
			// A consumable product has been purchased by this user.
			if (String.Equals (args.purchasedProduct.definition.id, MODIFIED_RIFLE, StringComparison.Ordinal)) {
				Debug.Log ("You've got the rifle.");
			} else if (String.Equals (args.purchasedProduct.definition.id, MODIFIED_M4A1, StringComparison.Ordinal)) {
				Debug.Log ("You've got the m4a1.");
			} else if (String.Equals (args.purchasedProduct.definition.id, KALASHNIKOV, StringComparison.Ordinal)) {
				Debug.Log ("You've got the kalashnikov.");
			} else if (String.Equals (args.purchasedProduct.definition.id, MACHINEGUN, StringComparison.Ordinal)) {
				Debug.Log ("You've got the machinegun.");
			} else if (String.Equals (args.purchasedProduct.definition.id, REVOLVER, StringComparison.Ordinal)) {
				Debug.Log("You've got the revolver.");
			} else if (String.Equals (args.purchasedProduct.definition.id, MP5, StringComparison.Ordinal)) {
				Debug.Log("You've got the mp5.");
			}
			// Or ... an unknown product has been purchased by this user. Fill in additional products here....
			else 
			{
				Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			}

			// Return a flag indicating whether this product has completely been received, or if the application needs 
			// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
			// saving purchased products to the cloud, and when that save is delayed. 
			return PurchaseProcessingResult.Complete;
		}


		public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
		{
			// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
			// this reason with the user to guide their troubleshooting actions.
			Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		}
	}