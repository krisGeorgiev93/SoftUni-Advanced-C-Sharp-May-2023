using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullname, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullname;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }


        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public List<Stock> Portfolio { get; set; }


        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            //add a single stock of the given company if the stock’s market capitalization is bigger than $10000 and the investor has enough money. 
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                //Then reduce the MoneyToInvest by the price of the stock.
                MoneyToInvest -= stock.PricePerShare;
            }
            //If a stock cannot be bought the method should not do anything.
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stock = this.Portfolio.First(x => x.CompanyName == companyName);
            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";

        }

        public Stock FindStock(string companyName) // returns a Stock with the given company name.If it doesn't exist, return null
        {
            return Portfolio.Find(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany() // returns the Stock with the biggest market capitalization.If there are no stocks in the portfolio, the method should return null. 
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
        public string InvestorInformation() // returns information about the Investor and his portfolio in the following format:
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, Portfolio)}";
        }
    }
}
