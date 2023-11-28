using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.ProgDec.BL.Models
{
    public class ShoppingCart
    {
        // Declaration application specific - Declaration Cost 
        const double ITEM_COST = 120.03;
        const double TAX_VALUE = 0.055;

        public List<Declaration> Items { get; set; } = new List<Declaration>();
        public int NumberOfItems { get {  return Items.Count; } }

        [DisplayFormat(DataFormatString ="{0:C")]
        public double SubTotal { get { return Items.Count * ITEM_COST; } } // In DVDCentral use a Lambda expression. Items.Sum 

        public double Tax { get { return SubTotal * TAX_VALUE; } }

        [DisplayFormat(DataFormatString = "{0:C")]
        public double Total { get { return SubTotal + Tax; } }
    }
}
