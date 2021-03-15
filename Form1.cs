//Author: Tyler Henry
//Last Modified: March 14 2021
//Title: Lab 4
//Description: Allows the user to input car information into an object filled array and edit each object entered

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_TylerHenry
{
    public partial class formCarInventory : Form
    {
        private List<Cars> carsList = new List<Cars>();
        // This flag is used to indicate whether the program is checking boxes as opposed to a human.
        private bool isAutomated = false;
        // Variable representing the current selected index in the ListView.
       
        private int selectedIndex = -1;
        public formCarInventory()
        {
            InitializeComponent();
        }
        #region Event Handlers
        /// <summary>
        /// Processes inputed information, adds or edits objects into list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Empties the output label
            labelOutput.Text = String.Empty;

            // Check if the car is valid
            if (IsCarValid(comboBoxMake.Text, textBoxModel.Text, textBoxPrice.Text ))
            {
                decimal.TryParse(textBoxPrice.Text, out decimal validPrice);
                int validYear = Convert.ToInt32(numericUpDownYear.Value);
                // creates new car object
                Cars newCarToAdd = new Cars(comboBoxMake.Text, textBoxModel.Text, validYear, validPrice, checkBoxNew.Checked);

                // If a car is selected
                if (selectedIndex >= 0)
                {
                    // Replaces old values with current values
                    carsList[selectedIndex] = newCarToAdd;
                }
                else
                {
                    // If not adds new car object
                    carsList.Add(newCarToAdd);
                }

                // Refresh the entire listView.
                PopulateListView(carsList);

                // Reset the form to allow new entries.
                SetDefaults();
            }
        }

        /// <summary>
        /// Resets the form when activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// Closes the program when activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sets clicked cars information into input fields for editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewCarInventory_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewCarInventory.Items.Count > 0 && listViewCarInventory.FocusedItem != null)
            {
                //Fills in input fields with current cars information
                comboBoxMake.Text = listViewCarInventory.FocusedItem.SubItems[2].Text;
                textBoxModel.Text = listViewCarInventory.FocusedItem.SubItems[3].Text;
                numericUpDownYear.Text = listViewCarInventory.FocusedItem.SubItems[4].Text;
                textBoxPrice.Text = listViewCarInventory.FocusedItem.SubItems[5].Text;
                checkBoxNew.Checked = listViewCarInventory.FocusedItem.Checked;

                // Set the selectedIndex to match the listView.
                selectedIndex = listViewCarInventory.FocusedItem.Index;
            }
            else
            {
                // If nothing is selected, set the selectedIndex to -1.
                selectedIndex = -1;
            }
        }
        #endregion
        #region Functions
        /// <summary>
        /// When a checkbox in the ListView is checked, say no and don't let the user change it.
        /// </summary>
        private void PreventCheck(object sender, ItemCheckEventArgs e)
        {
            // Only prevent checking if it's being done by the user.
            if (!isAutomated)
            {
                // Change the new value of the checkbox equal to the old state of the checkbox.
                e.NewValue = e.CurrentValue;
            }
        }

        /// <summary>
        /// Converts the customer passed in to a ListViewItem and adds it to listViewEntries
        /// </summary>
        /// <param name="newCars"></param>
        private void PopulateListView(List<Cars> carsList)
        {
            // Clear the listView
            listViewCarInventory.Items.Clear();

            foreach (Cars newCars in carsList)
            {
                // Declare and instantiate a new ListViewItem.
                ListViewItem carsItem = new ListViewItem();

                //Convert int and decimals to strings
                int year = newCars.Year;
                decimal price = newCars.Price;
                int Id = newCars.IdentificationNumber;

                //Modifity listview text
                isAutomated = true;
                carsItem.Checked = newCars.NewStatus;
                carsItem.SubItems.Add(Id.ToString());
                carsItem.SubItems.Add(newCars.Make);
                carsItem.SubItems.Add(newCars.Model);
                carsItem.SubItems.Add(year.ToString());
                carsItem.SubItems.Add(price.ToString());

                // Add carItem to list
                listViewCarInventory.Items.Add(carsItem);

                // Disallow the user from modifying the ListView's checkboxes.
                isAutomated = false;
            }
        }

        /// <summary>
        /// Function to set form to default, won't clear list box
        /// </summary>
        private void SetDefaults()
        {
            // Resets fields to default state.
            comboBoxMake.SelectedIndex = -1;
            textBoxModel.Clear();
            textBoxPrice.Clear();
            checkBoxNew.Checked = false;
            labelOutput.Text = String.Empty;
            selectedIndex = -1;

            // Set a default focus.
            comboBoxMake.Focus();
        }

        /// <summary>
        /// Checks whether the input related to a car is valid
        /// </summary>
        /// <param name="make">The car's make as a string</param>
        /// <param name="model">The car's model as a string</param>
        /// <param name="price">The price of the vehicle as a decimal</param>
        /// <returns></returns>
        private bool IsCarValid(string make, string model, string price)
        {
            // Assume the input is valid.
            bool isValid = true;

            //variable for tryparse
            decimal validPrice = 0;
          
            // Check the first input.
            if (make == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                labelOutput.Text += "You must select a model.\n";
            }
            // Check the second input.
            if (model == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                labelOutput.Text += "You must enter a car model.\n";
            }
            // Check the third input.
            if (decimal.TryParse(price, out validPrice))
            {
                //If third input is a valid number
                if(validPrice < 0)
                {
                    // If it's not valid, set isValid = false and write an error message.
                    isValid &= false;
                    labelOutput.Text += "You must enter a postive number for the price";
                }              
            }
            //If third input is not a valid number
            else
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                labelOutput.Text += "You must enter a number for the price";
            }

            return isValid;
        }

        #endregion
    }
}
