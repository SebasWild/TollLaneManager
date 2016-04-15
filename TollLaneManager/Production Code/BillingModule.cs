using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//This module is used to bill each car that passes through the tolling system either directly though the drivers smart card (SRS Functional Requirements 4.2) 
	//or indirectly through the driver's license plate number (SRS Functional Requirements 4.3).
	public class BillingModule
	{
        public List<SmartCard> smartcards;
        public List<Account> accounts;

		//Takes the driver’s smart card number and charges the value of the toll.
		//Parameter: smart card number
		//Returns: a string representation of the balance of the cardholder. 
		public String chargeSmartCard(String smartCardNumber, decimal amountToCharge)
		{
            SmartCard cardToCharge = getCardByNum(smartCardNumber);
            return (String)chargeAccount(cardToCharge.getAccount(), amountToCharge);
        }
        public SmartCard getCardByNum(String num)
        {
            foreach (SmartCard card in this.smartcards)
            {
                if (card.getSerialNumber() == smartCardNumber)
                {
                    return card;
                }
            }
        }
        public decimal chargeAccount(Account account, decimal amountToCharge)
        {
             return account.subtractFunds(amountToCharge);
        }
        //Sends the plate off to a billing site to charge the plate holder the toll.
        //Parameter: license plate number
        //returns: a string representation of the balance of the plateholder. 
        public String chargePlateHolder(String plateNumber, decimal amountToCharge)
		{
            chargeAccount(getAccountByPlate(plateNumber), amountToCharge);
            return (String)plateNumber;
		}
        public Account getAccountByPlate(String plateNum)
        {
            foreach (Account account in this.accounts)
            {
                if (account.getPlate() == plateNum)
                {
                    return account;
                }
            }
        }
	}
}