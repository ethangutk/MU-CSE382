using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project3Calculator
{
    public partial class MainPage : ContentPage
    {
        // Variables
        string currentOperation = "";
        int currentSavedNumForOperation = 0;
        int numInMemory = 0;

        int startingAmount = 0;
        int years = 30;
        int rateOfReturn = 5; // Percent as an int
        int regularInvestment = 500;
        string freqOfInvestment = "MONTHLY";

        public MainPage()
        {
            InitializeComponent();
        }

        private void numberButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (currentNumLabel.Text.Equals("0"))
            {
                currentNumLabel.Text = b.Text;
            }
            else
            {
                currentNumLabel.Text += b.Text;
            }
        }

        private void buttonplusminus_Clicked(object sender, EventArgs e)
        {
            if (currentNumLabel.Text.ElementAt(0).Equals('-') && !currentNumLabel.Text.Equals("0"))
            {
                currentNumLabel.Text = currentNumLabel.Text.Substring(1);
            } else if (!currentNumLabel.Text.Equals("0"))
            {
                currentNumLabel.Text = "-" + currentNumLabel.Text;
            }
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            currentOperation = "";
            currentSavedNumForOperation = 0;
            currentNumLabel.Text = "0";
        }

        private void operationButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            currentOperation = b.Text;
            currentSavedNumForOperation = Int32.Parse(currentNumLabel.Text);
            currentNumLabel.Text = "0";
        }

        private void equalsButton_Clicked(object sender, EventArgs e)
        {
            if (!currentOperation.Equals(""))
            {
                if (currentOperation.Equals("+"))
                {
                    currentNumLabel.Text = (currentSavedNumForOperation + Int32.Parse(currentNumLabel.Text)).ToString();
                    currentOperation = "";
                    currentSavedNumForOperation = 0;
                }
                else if (currentOperation.Equals("-"))
                {
                    currentNumLabel.Text = (currentSavedNumForOperation - Int32.Parse(currentNumLabel.Text)).ToString();
                    currentOperation = "";
                    currentSavedNumForOperation = 0;
                }
                else if (currentOperation.Equals("X"))
                {
                    currentNumLabel.Text = (currentSavedNumForOperation * Int32.Parse(currentNumLabel.Text)).ToString();
                    currentOperation = "";
                    currentSavedNumForOperation = 0;
                }
                else if (currentOperation.Equals("/"))
                {
                    currentNumLabel.Text = (currentSavedNumForOperation / Int32.Parse(currentNumLabel.Text)).ToString();
                    currentOperation = "";
                    currentSavedNumForOperation = 0;
                }
            }
        }

        private void memoryManip_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text.Equals("M+"))
            {
                numInMemory += Int32.Parse(currentNumLabel.Text);
                currentNumLabel.Text = "0";
            } else if (b.Text.Equals("M-"))
            {
                numInMemory -= Int32.Parse(currentNumLabel.Text);
                currentNumLabel.Text = "0";
            }
            else if (b.Text.Equals("MR"))
            {
                currentNumLabel.Text = numInMemory.ToString();
            }
            else
            {
                numInMemory = 0;
            }
        }
        private async void freqButtonClicked()
        {
            string result = await DisplayActionSheet("Action Title", null, null,
                "ANNUALLY", "QUARTERLY", "MONTHLY");
            if (result != null)
            {
                freqOfInvestmentLabel.Text = result;
                freqOfInvestment = result;
            }
        }

        private void investButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text.Equals("START"))
            {
                startingAmount = Int32.Parse(currentNumLabel.Text);
                startingAmountLabel.Text = "$" + startingAmount;
            } else if (b.Text.Equals("YEARS"))
            {
                years = Int32.Parse(currentNumLabel.Text);
                yearsLabel.Text = years.ToString();
            }
            else if (b.Text.Equals("RATE"))
            {
                rateOfReturn = Int32.Parse(currentNumLabel.Text);
                rateOfReturnLabel.Text = rateOfReturn.ToString() + "%";
            }
            else if (b.Text.Equals("INVEST"))
            {
                regularInvestment = Int32.Parse(currentNumLabel.Text);
                regularInvestmentLabel.Text = "$" + regularInvestment.ToString();
            }
            else if (b.Text.Equals("FREQ"))
            {
                freqButtonClicked();
            }
        }

        private void finalButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int final;
            if (freqOfInvestment.Equals("ANNUALLY"))
            {
                finalBalanceLabel.Text =
                    (years * ((regularInvestment) + ((0.01 * rateOfReturn) * startingAmount)) + startingAmount).ToString();
            } else if (freqOfInvestment.Equals("QUARTERLY"))
            {
                finalBalanceLabel.Text =
                (years * ((regularInvestment * 4) + ((0.01 * rateOfReturn) * startingAmount) * 4) + startingAmount).ToString();
            }
            else if (freqOfInvestment.Equals("MONTHLY"))
            {
                finalBalanceLabel.Text =
                (years * ((regularInvestment * 12) + ((0.01 * rateOfReturn) * startingAmount) * 12) + startingAmount).ToString();
            }
            // (Reg investment * freq) + (percent * starting amount)
        }
    }
}
