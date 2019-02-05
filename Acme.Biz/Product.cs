using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages product carried in inventory.
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;


        #region Constructors

        public Product()
        {

            //Console.WriteLine("Product instance created");
            this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tools";

            #region PracticeArrays

            //var colorOptions = new string[4];
            //colorOptions[0] = "Red";
            //colorOptions[1] = "Espresso";
            //colorOptions[2] = "White";
            //colorOptions[3] = "Navy";

            //string[] colorOptions = { "Red", "Espresso", "White", "Navy" };

            //var brownIndex = Array.IndexOf(colorOptions, "Espresso");

            //colorOptions.SetValue("Blue", 3);

            //for (int i = 0; i < colorOptions.Length; i++)
            //{
            //    colorOptions[i] = colorOptions[i].ToLower();
            //}

            //foreach (var color in colorOptions)
            //{
            //    Console.WriteLine($"The color is {color}");
            //}

            //Console.WriteLine(colorOptions[1]);

            #endregion

            #region PracticeLists

            //var colorOptions = new List<string>();
            //colorOptions.Add("Red");
            //colorOptions.Add("Espresso");
            //colorOptions.Add("White");
            //colorOptions.Add("Navy");

            var colorOptions = new List<string>() { "Red", "Espresso", "White", "Navy" };

            colorOptions.Insert(2, "Purple");
            colorOptions.Remove("White");

            Console.WriteLine(colorOptions);

            #endregion

            #region Generic Dictionaries

            var states = new Dictionary<string, string>()
            {
                { "CA", "California"} ,
                { "WA", "Washington"} ,
                { "NY", "New York"} ,
            };

            Console.WriteLine(states);

            #endregion
        }

        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }

            Console.WriteLine("Product instance has a name: " + ProductName);

        }



        #endregion

        #region Properties

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public decimal Cost { get; set; }

        private string productName;

        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue; }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return ProductVendor; }
            set { productVendor = value; }
        }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => $"{this.Category}-{this.SequenceNumber:0000}";

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price.
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";

            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(value, message);
            return operationResult;
        }

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                this.ProductName, "sales@abc.com");

            var result = LogAction("saying Hello");

            return "Hello " + ProductName +
                    " (" + ProductId + "): " +
                    Description +
                    " Available on: " +
                    AvailabilityDate?.ToShortDateString();
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.productId + ")";
        }


    }
}
