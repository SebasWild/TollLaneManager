using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;
using TollLaneManager;

namespace AutomatedRoadTollingSystem
{
	
	/// <summary>
    ///     This module is used to bill each car that passes through the tolling system either directly though the drivers smart card (SRS Functional Requirements 4.2) 
	///     or indirectly through the driver's license plate number (SRS Functional Requirements 4.3).
    /// </summary>
    public class BillingModule
	{
        public List<SmartCard> smartcards;
        public List<Account> accounts;


        /// <summary>
        ///     Takes the driver’s smart card number and charges the value of the toll.
        ///     Parameter: smart card number
        ///     Returns: a string representation of the balance of the cardholder.
        /// </summary>
        /// <param name="smartCardNumber"></param>
        /// <param name="amountToCharge"></param>
        /// <returns></returns>
        public String chargeSmartCard(String smartCardNumber, decimal amountToCharge)
		{
            SmartCard cardToCharge = getCardByNum(smartCardNumber);
            return chargeAccount(cardToCharge.getAccount(), amountToCharge).ToString();
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public SmartCard getCardByNum(String smartCardNumber)
        {
            SmartCard smartCard = new SmartCard();

            foreach (SmartCard card in this.smartcards)
            {
                if (card.getSerialNumber() == smartCardNumber)
                {
                    smartCard = card;
                }
            }

            return smartCard;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amountToCharge"></param>
        /// <returns></returns>
        public decimal chargeAccount(Account account, decimal amountToCharge)
        {
             return account.subtractFunds(amountToCharge);
        }
        
        /// <summary>
        ///     Sends the plate off to a billing site to charge the plate holder the toll.
        ///     Parameter: license plate number
        ///     returns: a string representation of the balance of the plateholder. 
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <param name="amountToCharge"></param>
        /// <returns></returns>
        public String chargePlateHolder(String plateNumber, decimal amountToCharge)
		{
            chargeAccount(getAccountByPlate(plateNumber), amountToCharge);
            return (String)plateNumber;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plateNum"></param>
        /// <returns></returns>
        public Account getAccountByPlate(String plateNum)
        {
            Account account = new Account();

            foreach (Account a in this.accounts)
            {
                if (a.getPlate() == plateNum)
                {
                    account = a;
                }
            }

            return account;
        }
	}
}